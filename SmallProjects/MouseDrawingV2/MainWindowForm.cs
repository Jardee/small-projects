using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseDrawingV2
{
    public partial class MainWindowForm : Form
    {
        ConcurrentBag<Imgs> refToBagWithImgs;

        public MainWindowForm()
        {
            InitializeComponent();
            DownloadImgs();
            TopMost = true;
        }

        public void DownloadImgs() => refToBagWithImgs = Database.GetImages();

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new SettingsForm(this).Show();
        }

        private void addNewImageButton_Click(object sender, EventArgs e)
        {
            new AddNewImageForm().Show();
        }

        private void downloadedItemsTimer_Tick(object sender, EventArgs e)
        {
            downloadedItemsLabel.Text = refToBagWithImgs.Count.ToString();
        }

        private void tagsTextBox_TextChanged(object sender, EventArgs e)
        {
            imagesPanel.Controls.Clear();
            if (!String.IsNullOrEmpty(tagsTextBox.Text))
            {
                var result = refToBagWithImgs.AsParallel().Where(x => x.Tags.Contains(tagsTextBox.Text));

                foreach (var x in result.Take(10))
                {
                    PictureBox imgOnScreen = new PictureBox
                    {
                        Width = 50,
                        Height = 50,
                        Image = Util.resizeImage(Util.BitArrayTo256x256Image(x.Image), new Size(50, 50)),
                        Tag = x
                    };
                    imgOnScreen.MouseDown += imgMouseDown;
                    imagesPanel.Controls.Add(imgOnScreen);
                }
            }
        }

        private void imgMouseDown(object sender, MouseEventArgs e)
        {
            //show preview new form 65% opacity 
            var imageStruct = (Imgs)((PictureBox)sender).Tag;
            OpacityDrawImageForm preview = new OpacityDrawImageForm(imageStruct)
            {
                Width = 256,
                Height = 256,
                BackgroundImage = Util.BitArrayTo256x256Image(imageStruct.Image)
            };

            preview.Show();
        }
    }
}
