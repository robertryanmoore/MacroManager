using MacroManager;
using System.Text.Json;
using System.IO;
using System.Reflection.Emit;

namespace MacroManager
{
    public partial class Form1 : Form
    {

        private GlobalKeyboardHook _keyboardHook = new GlobalKeyboardHook();
        private List<Song> _songs;
        private int _currentIndex = 0;
        int count = 0;


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;
            _keyboardHook.KeyPressed += KeyboardHook_KeyPressed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _keyboardHook.SetHook();
            cmbMode.SelectedIndex = cmbMode.Items.IndexOf(Properties.Settings.Default["Mode"].ToString());
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
                }
                catch (JsonException)
                {
                    MessageBox.Show("An error occurred while parsing the JSON file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //disable song buttons and labels
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

            if (Properties.Settings.Default["Mode"].Equals("Home"))
            {
                pnlSong.Visible = false;
                pnlNext.Visible = false;
                btnPrev.Visible = false;
                btnNext.Visible = false;
            }


        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _keyboardHook.UnsetHook();
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
                    // Handle unknown mode or do nothing
                    break;
            }

        }

        private void HandleCampModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case 125:
                    MessageBox.Show("Mute group1, hopefully");
                    break;
                case 126:
                    MessageBox.Show("F15 Lasers!");
                    break;
                case 127:
                    MessageBox.Show("F16 Left Laser!");
                    break;
                case 128:
                    MessageBox.Show("F17 Right Laser!");
                    break;
                case 129:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case 130:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case 131:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case 132:
                    btnPrev.Focus();
                    btnPrev.PerformClick();
                    break;
                case 133:
                    btnNext.Focus();
                    btnNext.PerformClick();
                    break;
                case 134:
                    MessageBox.Show("F22 was pressed!");
                    break;
            }
        }

        private void HandleSundayModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case 125:
                    MessageBox.Show("F14 was pressed!");
                    break;
                case 126:
                    MessageBox.Show("F15 was pressed!");
                    break;
                case 127:
                    MessageBox.Show("F16 was pressed!");
                    break;
                case 128:
                    MessageBox.Show("F17 was pressed!");
                    break;
                case 129:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case 130:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case 131:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case 132:
                    //services prev
                    SendKeys.Send("{Left}");
                    break;
                case 133:
                    //services next
                    SendKeys.Send("{Right}");
                    break;
                case 134:
                    MessageBox.Show("F22 was pressed!");
                    break;
            }
        }

        private void HandleHomeModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case 125:
                    MessageBox.Show("F14 was pressed!");
                    break;
                case 126:
                    MessageBox.Show("F15 was pressed!");
                    break;
                case 127:
                    MessageBox.Show("F16 was pressed!");
                    break;
                case 128:
                    MessageBox.Show("F17 was pressed!");
                    break;
                case 129:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case 130:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case 131:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case 132:
                    MessageBox.Show("F21 was pressed!");
                    break;
                case 133:
                    MessageBox.Show("F21 was pressed!");
                    break;
                case 134:
                    MessageBox.Show("F22 was pressed!");
                    break;
            }
        }

        private void HandleHBCModeKeyPress(int vkCode)
        {
            switch (vkCode)
            {
                case 125:
                    MessageBox.Show("F14 was pressed!");
                    break;
                case 126:
                    MessageBox.Show("F15 was pressed!");
                    break;
                case 127:
                    MessageBox.Show("F16 was pressed!");
                    break;
                case 128:
                    MessageBox.Show("F17 was pressed!");
                    break;
                case 129:
                    MessageBox.Show("F18 was pressed!");
                    break;
                case 130:
                    MessageBox.Show("F19 was pressed!");
                    break;
                case 131:
                    MessageBox.Show("F20 was pressed!");
                    break;
                case 132:
                    MessageBox.Show("F21 was pressed!");
                    break;
                case 133:
                    MessageBox.Show("F21 was pressed!");
                    break;
                case 134:
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

            // Assuming your labels are named lblSong, lblLeader, lblIntro, and lblSet
            // Update labels in the "CURRENT" group
            lblSong.Text = $"Song: {currentSong.song}";
            lblLeader.Text = $"Leader: {currentSong.leader}";
            lblIntro.Text = $"Intro: {currentSong.intro}";
            lblSet.Text = $"Set: {currentSong.set}";

            // Handle the "NEXT" song display
            if (_currentIndex + 1 < _songs.Count)
            {
                Song nextSong = _songs[_currentIndex + 1];
                // Assuming your labels are named lblNextSong, etc.
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
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
