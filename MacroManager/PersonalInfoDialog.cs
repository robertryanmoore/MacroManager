using System;
using System.Windows.Forms;

namespace MacroManager
{
    public partial class PersonalInfoDialog : Form
    {
        public PersonalInfoDialog()
        {
            InitializeComponent();
        }

        private void PersonalInfoDialog_Load(object sender, EventArgs e)
        {
            txtEmailPersonal.Text = Properties.Settings.Default.EmailPersonal;
            txtPhonePersonal.Text = Properties.Settings.Default.PhonePersonal;
            txtIdNumber.Text = Properties.Settings.Default.IdNumber;
            txtEmailHome.Text = Properties.Settings.Default.EmailHome;
            txtEmailWork.Text = Properties.Settings.Default.EmailWork;
            txtPhoneWork.Text = Properties.Settings.Default.PhoneWork;
            txtLaserLeftUrl.Text = Properties.Settings.Default.LaserLeftUrl;
            txtLaserRightUrl.Text = Properties.Settings.Default.LaserRightUrl;
            txtBackupSharePath.Text = Properties.Settings.Default.BackupSharePath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EmailPersonal = txtEmailPersonal.Text;
            Properties.Settings.Default.PhonePersonal = txtPhonePersonal.Text;
            Properties.Settings.Default.IdNumber = txtIdNumber.Text;
            Properties.Settings.Default.EmailHome = txtEmailHome.Text;
            Properties.Settings.Default.EmailWork = txtEmailWork.Text;
            Properties.Settings.Default.PhoneWork = txtPhoneWork.Text;
            Properties.Settings.Default.LaserLeftUrl = txtLaserLeftUrl.Text;
            Properties.Settings.Default.LaserRightUrl = txtLaserRightUrl.Text;
            Properties.Settings.Default.BackupSharePath = txtBackupSharePath.Text;
            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
