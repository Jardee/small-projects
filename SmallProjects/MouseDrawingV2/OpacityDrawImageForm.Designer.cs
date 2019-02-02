namespace MouseDrawingV2
{
    partial class OpacityDrawImageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mouseTracktimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // mouseTracktimer
            // 
            this.mouseTracktimer.Enabled = true;
            this.mouseTracktimer.Interval = 50;
            this.mouseTracktimer.Tick += new System.EventHandler(this.mouseTracktimer_Tick);
            // 
            // OpacityDrawImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(287, 231);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpacityDrawImageForm";
            this.Opacity = 0.6D;
            this.Text = "OpacityDrawImageForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpacityDrawImageForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer mouseTracktimer;
    }
}