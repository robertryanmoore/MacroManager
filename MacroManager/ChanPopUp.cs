using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroManager
{
    public partial class ChanPopUp : Form
    {

        public Dictionary<string, bool> ChannelStates { get; private set; }

        public ChanPopUp(Dictionary<string, bool> initialStates)
        {
            InitializeComponent();
            ChannelStates = initialStates ?? new Dictionary<string, bool>();
            PopulateChecklist();

            // Set the DialogResult of the button that closes the form
            btnSave.DialogResult = DialogResult.OK;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PopulateChecklist()
        {
            // Clear any existing items
            checkedListBox1.Items.Clear();

            // Populate the list from Ch1 to Ch32
            for (int i = 1; i <= 32; i++)
            {
                string channelName = $"Ch{i}";
                bool isChecked = false;
                // Check if the channel state exists in the dictionary and use it
                if (ChannelStates.ContainsKey(channelName))
                {
                    isChecked = ChannelStates[channelName];
                }

                checkedListBox1.Items.Add(channelName, isChecked);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update the dictionary with the current checked states before the form closes
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string channelName = checkedListBox1.Items[i].ToString();
                ChannelStates[channelName] = checkedListBox1.GetItemChecked(i);
            }
        }
    }
}
