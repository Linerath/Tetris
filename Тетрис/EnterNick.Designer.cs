namespace Тетрис
{
    partial class FNickEnter
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
            this.lEnter = new System.Windows.Forms.Label();
            this.tNick = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lEnter
            // 
            this.lEnter.AutoSize = true;
            this.lEnter.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lEnter.Location = new System.Drawing.Point(12, 19);
            this.lEnter.Name = "lEnter";
            this.lEnter.Size = new System.Drawing.Size(126, 28);
            this.lEnter.TabIndex = 0;
            this.lEnter.Text = "Введите имя:";
            // 
            // tNick
            // 
            this.tNick.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tNick.Location = new System.Drawing.Point(144, 17);
            this.tNick.MaxLength = 15;
            this.tNick.Name = "tNick";
            this.tNick.Size = new System.Drawing.Size(191, 30);
            this.tNick.TabIndex = 1;
            // 
            // bOk
            // 
            this.bOk.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOk.Location = new System.Drawing.Point(341, 17);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 30);
            this.bOk.TabIndex = 2;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(142, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 11);
            this.label1.TabIndex = 3;
            this.label1.Text = "*не более 15 символов";
            // 
            // FNickEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 73);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tNick);
            this.Controls.Add(this.lEnter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FNickEnter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lEnter;
        private System.Windows.Forms.TextBox tNick;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Label label1;
    }
}