using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseDrawingV2
{
    public partial class SettingsForm : Form
    {
        MainWindowForm _refTomainWindow;

        public SettingsForm(MainWindowForm refTomainWindow)
        {
            InitializeComponent();
            _refTomainWindow = refTomainWindow;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            pixelSkipTextBox.Text = Properties.Settings.Default.PixelSkip.ToString();
            delayTextBox.Text = Properties.Settings.Default.Delay.ToString();
            experimentalCheckBox.Checked = Properties.Settings.Default.Experimental;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (byte.TryParse(pixelSkipTextBox.Text, out byte tmpresult1)) Properties.Settings.Default.PixelSkip = tmpresult1;
            if (byte.TryParse(delayTextBox.Text, out byte tmpresult2)) Properties.Settings.Default.Delay = tmpresult2;
            Properties.Settings.Default.Experimental = experimentalCheckBox.Checked;

            Properties.Settings.Default.Save();
            MessageBox.Show("Settings Saved!");
        }

        private void refreshDatabaseButton_Click(object sender, EventArgs e)
        {
            _refTomainWindow.DownloadImgs();
        }
    }
}
