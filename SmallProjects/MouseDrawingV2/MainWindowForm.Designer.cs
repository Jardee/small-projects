namespace MouseDrawingV2
{
    partial class MainWindowForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.settingsButton = new System.Windows.Forms.Button();
            this.TagsLabel = new System.Windows.Forms.Label();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.imagesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addNewImageButton = new System.Windows.Forms.Button();
            this.downloadedItemsLabel = new System.Windows.Forms.Label();
            this.downloadedItemsTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(12, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(107, 23);
            this.settingsButton.TabIndex = 0;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // TagsLabel
            // 
            this.TagsLabel.AutoSize = true;
            this.TagsLabel.Location = new System.Drawing.Point(9, 44);
            this.TagsLabel.Name = "TagsLabel";
            this.TagsLabel.Size = new System.Drawing.Size(31, 13);
            this.TagsLabel.TabIndex = 1;
            this.TagsLabel.Text = "Tagi:";
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Location = new System.Drawing.Point(46, 41);
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.Size = new System.Drawing.Size(188, 20);
            this.tagsTextBox.TabIndex = 2;
            this.tagsTextBox.TextChanged += new System.EventHandler(this.tagsTextBox_TextChanged);
            // 
            // imagesPanel
            // 
            this.imagesPanel.Location = new System.Drawing.Point(12, 67);
            this.imagesPanel.Name = "imagesPanel";
            this.imagesPanel.Size = new System.Drawing.Size(222, 360);
            this.imagesPanel.TabIndex = 3;
            // 
            // addNewImageButton
            // 
            this.addNewImageButton.Location = new System.Drawing.Point(125, 12);
            this.addNewImageButton.Name = "addNewImageButton";
            this.addNewImageButton.Size = new System.Drawing.Size(109, 23);
            this.addNewImageButton.TabIndex = 4;
            this.addNewImageButton.Text = "Add New Image";
            this.addNewImageButton.UseVisualStyleBackColor = true;
            this.addNewImageButton.Click += new System.EventHandler(this.addNewImageButton_Click);
            // 
            // downloadedItemsLabel
            // 
            this.downloadedItemsLabel.AutoSize = true;
            this.downloadedItemsLabel.Location = new System.Drawing.Point(12, 430);
            this.downloadedItemsLabel.Name = "downloadedItemsLabel";
            this.downloadedItemsLabel.Size = new System.Drawing.Size(0, 13);
            this.downloadedItemsLabel.TabIndex = 5;
            // 
            // downloadedItemsTimer
            // 
            this.downloadedItemsTimer.Enabled = true;
            this.downloadedItemsTimer.Tick += new System.EventHandler(this.downloadedItemsTimer_Tick);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 450);
            this.Controls.Add(this.downloadedItemsLabel);
            this.Controls.Add(this.addNewImageButton);
            this.Controls.Add(this.imagesPanel);
            this.Controls.Add(this.tagsTextBox);
            this.Controls.Add(this.TagsLabel);
            this.Controls.Add(this.settingsButton);
            this.Name = "MainWindowForm";
            this.Text = "MouseDrawing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Label TagsLabel;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.FlowLayoutPanel imagesPanel;
        private System.Windows.Forms.Button addNewImageButton;
        private System.Windows.Forms.Label downloadedItemsLabel;
        private System.Windows.Forms.Timer downloadedItemsTimer;
    }
}

