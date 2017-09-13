namespace Тетрис
{
    partial class GameModeForm
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
            this.bSingle = new System.Windows.Forms.Button();
            this.b2Pl = new System.Windows.Forms.Button();
            this.lText = new System.Windows.Forms.Label();
            this.bFun = new System.Windows.Forms.Button();
            this.b3Pl = new System.Windows.Forms.Button();
            this.b4Pl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bSingle
            // 
            this.bSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSingle.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSingle.Location = new System.Drawing.Point(100, 63);
            this.bSingle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSingle.Name = "bSingle";
            this.bSingle.Size = new System.Drawing.Size(171, 38);
            this.bSingle.TabIndex = 0;
            this.bSingle.Text = "Одиночный";
            this.bSingle.UseVisualStyleBackColor = true;
            this.bSingle.Click += new System.EventHandler(this.bSingle_Click);
            // 
            // b2Pl
            // 
            this.b2Pl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b2Pl.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b2Pl.Location = new System.Drawing.Point(100, 108);
            this.b2Pl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b2Pl.Name = "b2Pl";
            this.b2Pl.Size = new System.Drawing.Size(171, 38);
            this.b2Pl.TabIndex = 1;
            this.b2Pl.Text = "2 игрока";
            this.b2Pl.UseVisualStyleBackColor = true;
            this.b2Pl.Click += new System.EventHandler(this.b2Pl_Click);
            // 
            // lText
            // 
            this.lText.AutoSize = true;
            this.lText.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lText.Location = new System.Drawing.Point(49, 11);
            this.lText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(261, 35);
            this.lText.TabIndex = 2;
            this.lText.Text = "Выберите режим игры:";
            // 
            // bFun
            // 
            this.bFun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFun.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bFun.Location = new System.Drawing.Point(100, 245);
            this.bFun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bFun.Name = "bFun";
            this.bFun.Size = new System.Drawing.Size(171, 38);
            this.bFun.TabIndex = 3;
            this.bFun.Text = "Fun";
            this.bFun.UseVisualStyleBackColor = true;
            this.bFun.Click += new System.EventHandler(this.bFun_Click);
            // 
            // b3Pl
            // 
            this.b3Pl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b3Pl.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b3Pl.Location = new System.Drawing.Point(100, 154);
            this.b3Pl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b3Pl.Name = "b3Pl";
            this.b3Pl.Size = new System.Drawing.Size(171, 38);
            this.b3Pl.TabIndex = 5;
            this.b3Pl.Text = "3 игрока";
            this.b3Pl.UseVisualStyleBackColor = true;
            this.b3Pl.Click += new System.EventHandler(this.b3Pl_Click);
            // 
            // b4Pl
            // 
            this.b4Pl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b4Pl.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b4Pl.Location = new System.Drawing.Point(100, 199);
            this.b4Pl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.b4Pl.Name = "b4Pl";
            this.b4Pl.Size = new System.Drawing.Size(171, 38);
            this.b4Pl.TabIndex = 6;
            this.b4Pl.Text = "4 игрока";
            this.b4Pl.UseVisualStyleBackColor = true;
            this.b4Pl.Click += new System.EventHandler(this.b4Pl_Click);
            // 
            // GameModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(379, 306);
            this.Controls.Add(this.b4Pl);
            this.Controls.Add(this.b3Pl);
            this.Controls.Add(this.bFun);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.b2Pl);
            this.Controls.Add(this.bSingle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameModeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FGameMode_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSingle;
        private System.Windows.Forms.Button b2Pl;
        private System.Windows.Forms.Label lText;
        private System.Windows.Forms.Button bFun;
        private System.Windows.Forms.Button b3Pl;
        private System.Windows.Forms.Button b4Pl;
    }
}