namespace MazeGeneratorVisual
{
    partial class MazeForm
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
            this.MazeVisual = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MazeVisual)).BeginInit();
            this.SuspendLayout();
            // 
            // MazeVisual
            // 
            this.MazeVisual.Location = new System.Drawing.Point(12, 12);
            this.MazeVisual.Name = "MazeVisual";
            this.MazeVisual.Size = new System.Drawing.Size(401, 401);
            this.MazeVisual.TabIndex = 0;
            this.MazeVisual.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 426);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MazeVisual);
            this.Name = "MazeForm";
            this.Text = "MazeGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.MazeVisual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MazeVisual;
        private System.Windows.Forms.Button button1;
    }
}

