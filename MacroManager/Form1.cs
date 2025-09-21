using MacroManager;
using System.Text.Json;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Bespoke.Osc;
using System.Net.Sockets;
using System.Net;


namespace MacroManager
{
    public partial class Form1 : Form
    {

        private GlobalKeyboardHook _keyboardHook = new GlobalKeyboardHook();
        private List<Song> _songs;
        private int _currentIndex = 0;
        private ContextMenuStrip contextMenu;
        private bool muted = true;

        //X32 stuffs
        //private const string X32_IP = "192.168.1.2"; // Replace with your X32's IP
        private const int X32_PORT = 10023; // Standard OSC port for X32
        private const int LOCAL_PORT = 9001; // A local port for your app

        private Dictionary<string, bool> _channelStates = new Dictionary<string, bool>();
        private string _filePath;

        //virtual key codes for F14-F23, just easier to track this way
        const int F14 = 125;
        const int F15 = 126;
        const int F16 = 127;
        const int F17 = 128;
        const int F18 = 129;
        const int F19 = 130;
        const int F20 = 131;
        const int F21 = 132;
        const int F22 = 133;
        const int F23 = 134;

        //Play pause key code
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;

        public static void PressMediaPlayPause()
        {
            // Simulate key down
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);

            // Simulate key up
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENTEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
        }

        public Form1()
        {
            InitializeComponent();
            _keyboardHook.SetHook();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
            _keyboardHook.KeyPressed += KeyboardHook_KeyPressed;

            // Initialize NotifyIcon and ContextMenu
            InitializeTrayComponents();
            _filePath = Path.Combine(Application.UserAppDataPath, "channel_states.json");
            _channelStates = LoadChannelStates();
        }

        private void InitializeTrayComponents()
        {
            // Create the NotifyIcon
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = this.Icon;
            notifyIcon.Visible = true;
            notifyIcon.Text = "MacroManager"; //Tooltip text

            // Create the ContextMenuStrip
            contextMenu = new ContextMenuStrip();
            var showMenuItem = new ToolStripMenuItem("Show");
            var exitMenuItem = new ToolStripMenuItem("Exit");
            contextMenu.Items.Add(showMenuItem);
            contextMenu.Items.Add(exitMenuItem);

            // Assign event handlers
            showMenuItem.Click += (sender, e) => ShowForm();
            exitMenuItem.Click += (sender, e) =>
            {
                Application.Exit();
            };

            notifyIcon.ContextMenuStrip = contextMenu;

            notifyIcon.DoubleClick += (sender, e) => ShowForm();
        }

        private void SaveChannelStates(Dictionary<string, bool> states)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(states);
                Directory.CreateDirectory(Application.UserAppDataPath); // Ensures the directory exists
                File.WriteAllText(_filePath, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving channel states: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, bool> LoadChannelStates()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<Dictionary<string, bool>>(jsonString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading channel states: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // If the file doesn't exist or an error occurred, return a new dictionary
            return new Dictionary<string, bool>();
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false; // Hide the tray icon
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMode.SelectedIndex = cmbMode.Items.IndexOf(Properties.Settings.Default["Mode"].ToString());
            //TODO: Refactor to swtich statement
            if (Properties.Settings.Default["Mode"].Equals("Camp"))
            {
                //load songs.json
                try
                {
                    string json = File.ReadAllText("songs.json");
                    _songs = JsonSerializer.Deserialize<List<Song>>(json);

                    DisplaySong();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("The songs.json file was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnPrev.Enabled = false;
                    btnNext.Enabled = false;
                    lblSong.Text = "Song:";
                    lblLeader.Text = "Leader:";
                    lblIntro.Text = "Intro:";
                    lblSet.Text = "Set:";
                    lblNextSong.Text = "Song:";
                    lblNextLeader.Text = "Leader:";
                    lblNextIntro.Text = "Intro:";
                    lblNextSet.Text = "Set:";
                }
                catch (JsonException)
                {
                    MessageBox.Show("An error occurred while parsing the JSON file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnPrev.Enabled = false;
                    btnNext.Enabled = false;
                    lblSong.Text = "Song:";
                    lblLeader.Text = "Leader:";
                    lblIntro.Text = "Intro:";
                    lblSet.Text = "Set:";
                    lblNextSong.Text = "Song:";
                    lblNextLeader.Text = "Leader:";
                    lblNextIntro.Text = "Intro:";
                    lblNextSet.Text = "Set:";
                }

                //explcitly enable camp mode controls
                pnlSong.Visible = true;
                pnlNext.Visible = true;
                btnPrev.Visible = true;
                btnNext.Visible = true;
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
                lblX32.Visible = true;
                tbxX32IP.Visible = true;
                lblX32pw.Visible = true;
                tbxPassword.Visible = true;
                btnMuteChans.Visible = true;
                btnMuteChans.Enabled = true;

                //disable other modes controls
                pnlMacro.Visible = false;
            }
            else
            {
                //disable camp mode controls
                pnlSong.Visible = false;
                pnlNext.Visible = false;
                btnPrev.Visible = false;
                btnPrev.Enabled = false;
                btnNext.Visible = false;
                btnNext.Enabled = false;
                lblX32.Visible = false;
                tbxX32IP.Visible = false;
                lblX32pw.Visible = false;
                tbxPassword.Visible = false;
                btnMuteChans.Visible = false;
                btnMuteChans.Enabled = false;

                //enable other modes controls
                pnlMacro.Visible = true;

                if (Properties.Settings.Default["Mode"].Equals("HBC"))
                {
                    btn1.Text = "Smoke";
                    btn2.Text = "Lasers";
                    btn3.Text = "Lasers L";
                    btn4.Text = "Lasers R";
                    btn5.Text = "Spots";
                    btn6.Text = "Spots 50%";
                    btn7.Text = "Spots 25%";
                    btn8.Text = "Previous";
                    btn9.Text = "Next";
                    btn10.Text = "unbound";
                }
                if (Properties.Settings.Default["Mode"].Equals("Sunday"))
                {
                    btn1.Text = "unbound";
                    btn2.Text = "unbound";
                    btn3.Text = "unbound";
                    btn4.Text = "unbound";
                    btn5.Text = "unbound";
                    btn6.Text = "unbound";
                    btn7.Text = "unbound";
                    btn8.Text = "Previous";
                    btn9.Text = "Next";
                    btn10.Text = "unbound";
                }
                if (Properties.Settings.Default["Mode"].Equals("Home"))
                {
                    btn1.Text = "Play/Pause";
                    btn2.Text = "Email";
                    btn3.Text = "Phone";
                    btn4.Text = "ID";
                    btn5.Text = "unbound";
                    btn6.Text = "unbound";
                    btn7.Text = "unbound";
                    btn8.Text = "unbound";
                    btn9.Text = "unbound";
                    btn10.Text = "unbound";
                }

            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevents the form from actually closing
                MinimizeToTray();
            }
            else
            {
                _keyboardHook.UnsetHook();
            }
        }

        private void MinimizeToTray()
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void KeyboardHook_KeyPressed(object sender, int vkCode)
        {

            switch (Properties.Settings.Default["Mode"])
            {
                case "Camp":
                    HandleCampModeKeyPress(vkCode);
                    break;
                case "Sunday":
                    HandleSundayModeKeyPress(vkCode);
                    break;
                case "Home":
                    HandleHomeModeKeyPress(vkCode);
                    break;
                case "HBC":
                    HandleHBCModeKeyPress(vkCode);
                    break;
                default:

                    break;
            }

        }

        private void HandleCampModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case F14:
                    //MessageBox.Show("Mute group1, hopefully");
                    string X32_IP = Properties.Settings.Default["X32IP"].ToString();
                    muted = !muted;

                    try
                    {
                        using (var udpClient = new UdpClient())
                        {
                            // Establish the connection ONCE before the loop
                            udpClient.Connect(IPAddress.Parse(X32_IP), X32_PORT);

                            // Create a local IPEndPoint for the source of the message
                            var sourceEndpoint = new IPEndPoint(IPAddress.Any, LOCAL_PORT);

                            foreach (var channel in _channelStates)
                            {
                                if (channel.Value) // If the channel is checked (true), mute it
                                {
                                    string chanNum = channel.Key.Substring(2);
                                    if (Int32.Parse(channel.Key.Substring(2)) < 10)
                                        chanNum = "0" + channel.Key.Substring(2);

                                    var message = new OscMessage(sourceEndpoint, $"/ch/{chanNum}/mix/on");
                                    message.Append(0); // 1 = Mute, 0 = Unmute

                                    // Send the message inside the loop
                                    byte[] messageBytes = message.ToByteArray();
                                    udpClient.Send(messageBytes, messageBytes.Length);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error sending OSC message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case F15:
                    MessageBox.Show("F15 Lasers!");
                    break;
                case F16:
                    MessageBox.Show("F16 Left Laser!");
                    break;
                case F17:
                    MessageBox.Show("F17 Right Laser!");
                    break;
                case F18:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case F19:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case F20:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case F21:
                    btnPrev.Focus();
                    btnPrev.PerformClick();
                    break;
                case F22:
                    btnNext.Focus();
                    btnNext.PerformClick();
                    break;
                case F23:
                    MessageBox.Show("F23 was pressed!");
                    break;
            }
        }

        private void HandleSundayModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case F14:
                    MessageBox.Show("F14 was pressed!");
                    break;
                case F15:
                    MessageBox.Show("F15 was pressed!");
                    break;
                case F16:
                    MessageBox.Show("F16 was pressed!");
                    break;
                case F17:
                    MessageBox.Show("F17 was pressed!");
                    break;
                case F18:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case F19:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case F20:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case F21:
                    //services prev
                    SendKeys.Send("{Left}");
                    break;
                case F22:
                    //services next
                    SendKeys.Send("{Right}");
                    break;
                case F23:
                    MessageBox.Show("F22 was pressed!");
                    break;
            }
        }

        private void HandleHomeModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case F14:
                    PressMediaPlayPause();
                    break;
                case F15:
                    SendKeys.Send("moore.robert.ryan@gmail.com");
                    break;
                case F16:
                    SendKeys.Send("0768514138");
                    break;
                case F17:
                    SendKeys.Send("9711265125081");
                    break;
                case F18:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case F19:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case F20:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case F21:
                    MessageBox.Show("F21 was pressed!");
                    break;
                case F22:
                    MessageBox.Show("F21 was pressed!");
                    break;
                case F23:
                    MessageBox.Show("F22 was pressed!");
                    break;
            }
        }

        private void HandleHBCModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case F14:
                    MessageBox.Show("F14 was pressed!");
                    break;
                case F15:
                    MessageBox.Show("F15 was pressed!");
                    break;
                case F16:
                    MessageBox.Show("F16 was pressed!");
                    break;
                case F17:
                    MessageBox.Show("F17 was pressed!");
                    break;
                case F18:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case F19:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case F20:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case F21:
                    //services prev
                    SendKeys.Send("{Left}");
                    break;
                case F22:
                    //services next
                    SendKeys.Send("{Right}");
                    break;
                case F23:
                    MessageBox.Show("F22 was pressed!");
                    break;
            }
        }

        private void DisplaySong()
        {
            if (_songs == null || _songs.Count == 0)
            {
                return;
            }

            Song currentSong = _songs[_currentIndex];

            lblSong.Text = $"Song: {currentSong.song}";
            lblLeader.Text = $"Leader: {currentSong.leader}";
            lblIntro.Text = $"Intro: {currentSong.intro}";
            lblSet.Text = $"Set: {currentSong.set}";

            // "NEXT" song
            if (_currentIndex + 1 < _songs.Count)
            {
                Song nextSong = _songs[_currentIndex + 1];
                lblNextSong.Text = $"Song: {nextSong.song}";
                lblNextLeader.Text = $"Leader: {nextSong.leader}";
                lblNextIntro.Text = $"Intro: {nextSong.intro}";
                lblNextSet.Text = $"Set: {nextSong.set}";
            }
            else
            {
                // Clear the "NEXT" labels if at the end of the list
                lblNextSong.Text = "Song:";
                lblNextLeader.Text = "Leader:";
                lblNextIntro.Text = "Intro:";
                lblNextSet.Text = "Set:";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_currentIndex + 1 < _songs.Count)
            {
                _currentIndex++;
                DisplaySong();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentIndex - 1 >= 0)
            {
                _currentIndex--;
                DisplaySong();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Mode"] = cmbMode.SelectedItem.ToString();
            Properties.Settings.Default["X32IP"] = tbxX32IP.Text;
            Properties.Settings.Default["X32PW"] = tbxPassword.Text;
            Properties.Settings.Default.Save();
            //0768514138MessageBox.Show("Settings saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1_Load(this, EventArgs.Empty);

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F14);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F15);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F16);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F17);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F18);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F19);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F20);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F21);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F22);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            KeyboardHook_KeyPressed(this, F23);
        }

        private void btnMuteChans_Click(object sender, EventArgs e)
        {
            ChanPopUp chanPopUp = new ChanPopUp(_channelStates);
            if (chanPopUp.ShowDialog() == DialogResult.OK)
            {
                // When the dialog closes, retrieve the updated states
                _channelStates = chanPopUp.ChannelStates;
                SaveChannelStates(_channelStates); // Save the updated states to the file
            }
        }
    }
}
