namespace Тетрис
{
    partial class FConfirm
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
            this.lText = new System.Windows.Forms.Label();
            this.bNo = new System.Windows.Forms.Button();
            this.bYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lText.Location = new System.Drawing.Point(12, 9);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(23, 13);
            this.lText.TabIndex = 0;
            this.lText.Text = "а?";
            // 
            // bNo
            // 
            this.bNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bNo.Location = new System.Drawing.Point(82, 37);
            this.bNo.Name = "bNo";
            this.bNo.Size = new System.Drawing.Size(75, 23);
            this.bNo.TabIndex = 2;
            this.bNo.Text = "Нет";
            this.bNo.UseVisualStyleBackColor = true;
            this.bNo.Click += new System.EventHandler(this.bNo_Click);
            // 
            // bYes
            // 
            this.bYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bYes.Location = new System.Drawing.Point(1, 37);
            this.bYes.Name = "bYes";
            this.bYes.Size = new System.Drawing.Size(75, 23);
            this.bYes.TabIndex = 3;
            this.bYes.Text = "Да";
            this.bYes.UseVisualStyleBackColor = true;
            this.bYes.Click += new System.EventHandler(this.bYes_Click);
            // 
            // FConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 66);
            this.Controls.Add(this.bYes);
            this.Controls.Add(this.bNo);
            this.Controls.Add(this.lText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FConfirm_FormClosing);
            this.Load += new System.EventHandler(this.FConfirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lText;
        private System.Windows.Forms.Button bNo;
        private System.Windows.Forms.Button bYes;
    }
}