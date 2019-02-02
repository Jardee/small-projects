using System;
using System.Collections;
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
    public partial class AddNewImageForm : Form
    {
        Image _OriginalImage;

        public AddNewImageForm()
        {
            InitializeComponent();
        }

        private void AddNewImageForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.V | Keys.Control)) // ctrl + v
            {
                _OriginalImage = Clipboard.GetImage();
                actualPictureBox.Image = Util.resizeImage(_OriginalImage, new Size(256, 256));
                previewPictureBox.Image = Util.BitArrayTo256x256Image(Util.Image256x256ToBitArray(Util.resizeImage(_OriginalImage, new Size(256, 256))));
                e.Handled = true;

            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tagsTextBox.Text) && _OriginalImage != null)
            {
                var bitArrayToSend = Util.Image256x256ToBitArray(Util.resizeImage(_OriginalImage, new Size(256, 256)));

                if(Database.SendNewImage(tagsTextBox.Text, bitArrayToSend))
                    MessageBox.Show("Pomyślnie wysłano grafikę na serwer !");
                else
                    MessageBox.Show("Podczas wysyłania grafiki wystąpił błąd nie zostało wysłane na serwer");
            }
            else
            {
                MessageBox.Show("Brak tagów lub dodanego zdjęcia");
            }
        }

        

    }
}
