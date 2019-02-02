namespace MouseDrawingV2
{
    partial class SettingsForm
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
            this.delayLabel = new System.Windows.Forms.Label();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.experimentalCheckBox = new System.Windows.Forms.CheckBox();
            this.pixelSkipTextBox = new System.Windows.Forms.TextBox();
            this.pixelSkipLabel = new System.Windows.Forms.Label();
            this.refreshDatabaseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(12, 9);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(59, 13);
            this.delayLabel.TabIndex = 0;
            this.delayLabel.Text = "Delay (ms):";
            // 
            // delayTextBox
            // 
            this.delayTextBox.Location = new System.Drawing.Point(74, 6);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(100, 20);
            this.delayTextBox.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(158, 84);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // experimentalCheckBox
            // 
            this.experimentalCheckBox.AutoSize = true;
            this.experimentalCheckBox.Enabled = false;
            this.experimentalCheckBox.Location = new System.Drawing.Point(15, 58);
            this.experimentalCheckBox.Name = "experimentalCheckBox";
            this.experimentalCheckBox.Size = new System.Drawing.Size(125, 17);
            this.experimentalCheckBox.TabIndex = 3;
            this.experimentalCheckBox.Text = "Experimental Feature";
            this.experimentalCheckBox.UseVisualStyleBackColor = true;
            // 
            // pixelSkipTextBox
            // 
            this.pixelSkipTextBox.Location = new System.Drawing.Point(74, 32);
            this.pixelSkipTextBox.Name = "pixelSkipTextBox";
            this.pixelSkipTextBox.Size = new System.Drawing.Size(100, 20);
            this.pixelSkipTextBox.TabIndex = 5;
            // 
            // pixelSkipLabel
            // 
            this.pixelSkipLabel.AutoSize = true;
            this.pixelSkipLabel.Location = new System.Drawing.Point(12, 35);
            this.pixelSkipLabel.Name = "pixelSkipLabel";
            this.pixelSkipLabel.Size = new System.Drawing.Size(56, 13);
            this.pixelSkipLabel.TabIndex = 4;
            this.pixelSkipLabel.Text = "Pixel Skip:";
            // 
            // refreshDatabaseButton
            // 
            this.refreshDatabaseButton.Location = new System.Drawing.Point(12, 84);
            this.refreshDatabaseButton.Name = "refreshDatabaseButton";
            this.refreshDatabaseButton.Size = new System.Drawing.Size(113, 23);
            this.refreshDatabaseButton.TabIndex = 6;
            this.refreshDatabaseButton.Text = "Refresh Database";
            this.refreshDatabaseButton.UseVisualStyleBackColor = true;
            this.refreshDatabaseButton.Click += new System.EventHandler(this.refreshDatabaseButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 112);
            this.Controls.Add(this.refreshDatabaseButton);
            this.Controls.Add(this.pixelSkipTextBox);
            this.Controls.Add(this.pixelSkipLabel);
            this.Controls.Add(this.experimentalCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.delayLabel);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox experimentalCheckBox;
        private System.Windows.Forms.TextBox pixelSkipTextBox;
        private System.Windows.Forms.Label pixelSkipLabel;
        private System.Windows.Forms.Button refreshDatabaseButton;
    }
}