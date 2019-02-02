namespace MouseDrawingV2
{
    partial class AddNewImageForm
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
            this.loadFromFileButton = new System.Windows.Forms.Button();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.actualGroupBox2 = new System.Windows.Forms.GroupBox();
            this.actualPictureBox = new System.Windows.Forms.PictureBox();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.previewGroupBox.SuspendLayout();
            this.actualGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actualPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Enabled = false;
            this.loadFromFileButton.Location = new System.Drawing.Point(12, 12);
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(123, 23);
            this.loadFromFileButton.TabIndex = 0;
            this.loadFromFileButton.Text = "Load from file...";
            this.loadFromFileButton.UseVisualStyleBackColor = true;
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.Location = new System.Drawing.Point(6, 19);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(227, 181);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPictureBox.TabIndex = 1;
            this.previewPictureBox.TabStop = false;
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Controls.Add(this.previewPictureBox);
            this.previewGroupBox.Location = new System.Drawing.Point(262, 87);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(239, 206);
            this.previewGroupBox.TabIndex = 2;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // actualGroupBox2
            // 
            this.actualGroupBox2.Controls.Add(this.actualPictureBox);
            this.actualGroupBox2.Location = new System.Drawing.Point(12, 87);
            this.actualGroupBox2.Name = "actualGroupBox2";
            this.actualGroupBox2.Size = new System.Drawing.Size(244, 206);
            this.actualGroupBox2.TabIndex = 3;
            this.actualGroupBox2.TabStop = false;
            this.actualGroupBox2.Text = "Actual";
            // 
            // actualPictureBox
            // 
            this.actualPictureBox.Location = new System.Drawing.Point(6, 19);
            this.actualPictureBox.Name = "actualPictureBox";
            this.actualPictureBox.Size = new System.Drawing.Size(227, 181);
            this.actualPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.actualPictureBox.TabIndex = 2;
            this.actualPictureBox.TabStop = false;
            // 
            // tagsLabel
            // 
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.Location = new System.Drawing.Point(15, 60);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(34, 13);
            this.tagsLabel.TabIndex = 4;
            this.tagsLabel.Text = "Tags:";
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Location = new System.Drawing.Point(56, 57);
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.Size = new System.Drawing.Size(445, 20);
            this.tagsTextBox.TabIndex = 5;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(418, 296);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(83, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // AddNewImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 331);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.tagsTextBox);
            this.Controls.Add(this.tagsLabel);
            this.Controls.Add(this.actualGroupBox2);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.loadFromFileButton);
            this.KeyPreview = true;
            this.Name = "AddNewImageForm";
            this.Text = "AddNewImageForm";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddNewImageForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.previewGroupBox.ResumeLayout(false);
            this.actualGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.actualPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadFromFileButton;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.GroupBox previewGroupBox;
        private System.Windows.Forms.GroupBox actualGroupBox2;
        private System.Windows.Forms.PictureBox actualPictureBox;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.Button sendButton;
    }
}