namespace Тетрис
{
    partial class FTetris
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTetris));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаРекордовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.горячиеКлавишиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gNext = new System.Windows.Forms.GroupBox();
            this.lScore = new System.Windows.Forms.Label();
            this.lMode = new System.Windows.Forms.Label();
            this.lLevel = new System.Windows.Forms.Label();
            this.bRecords = new Тетрис.NonFocusButton();
            this.bStatistics = new Тетрис.NonFocusButton();
            this.bOptions = new Тетрис.NonFocusButton();
            this.bClose = new Тетрис.NonFocusButton();
            this.nfbNewGame = new Тетрис.NonFocusButton();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.свойстваToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(659, 28);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.таблицаРекордовToolStripMenuItem,
            this.статистикаToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // таблицаРекордовToolStripMenuItem
            // 
            this.таблицаРекордовToolStripMenuItem.Name = "таблицаРекордовToolStripMenuItem";
            this.таблицаРекордовToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.таблицаРекордовToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.таблицаРекордовToolStripMenuItem.Text = "Таблица рекордов";
            this.таблицаРекордовToolStripMenuItem.Click += new System.EventHandler(this.таблицаРекордовToolStripMenuItem_Click);
            // 
            // статистикаToolStripMenuItem
            // 
            this.статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this.статистикаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.статистикаToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.статистикаToolStripMenuItem.Text = "Статистика";
            this.статистикаToolStripMenuItem.Click += new System.EventHandler(this.статистикаToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(262, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(265, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // свойстваToolStripMenuItem
            // 
            this.свойстваToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.горячиеКлавишиToolStripMenuItem});
            this.свойстваToolStripMenuItem.Name = "свойстваToolStripMenuItem";
            this.свойстваToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.свойстваToolStripMenuItem.Text = "Настройки";
            // 
            // горячиеКлавишиToolStripMenuItem
            // 
            this.горячиеКлавишиToolStripMenuItem.Name = "горячиеКлавишиToolStripMenuItem";
            this.горячиеКлавишиToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.горячиеКлавишиToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.горячиеКлавишиToolStripMenuItem.Text = "Горячие клавиши";
            this.горячиеКлавишиToolStripMenuItem.Click += new System.EventHandler(this.горячиеКлавишиToolStripMenuItem_Click);
            // 
            // gNext
            // 
            this.gNext.BackColor = System.Drawing.Color.Transparent;
            this.gNext.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gNext.Location = new System.Drawing.Point(348, 142);
            this.gNext.Margin = new System.Windows.Forms.Padding(4);
            this.gNext.Name = "gNext";
            this.gNext.Padding = new System.Windows.Forms.Padding(4);
            this.gNext.Size = new System.Drawing.Size(267, 149);
            this.gNext.TabIndex = 403;
            this.gNext.TabStop = false;
            this.gNext.Text = "Next";
            this.gNext.Visible = false;
            // 
            // lScore
            // 
            this.lScore.AutoSize = true;
            this.lScore.BackColor = System.Drawing.Color.Transparent;
            this.lScore.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lScore.ForeColor = System.Drawing.Color.Black;
            this.lScore.Location = new System.Drawing.Point(340, 294);
            this.lScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lScore.Name = "lScore";
            this.lScore.Size = new System.Drawing.Size(126, 54);
            this.lScore.TabIndex = 404;
            this.lScore.Text = "Score: ";
            this.lScore.Visible = false;
            // 
            // lMode
            // 
            this.lMode.AutoSize = true;
            this.lMode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMode.Location = new System.Drawing.Point(372, 640);
            this.lMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lMode.Name = "lMode";
            this.lMode.Size = new System.Drawing.Size(0, 21);
            this.lMode.TabIndex = 405;
            // 
            // lLevel
            // 
            this.lLevel.AutoSize = true;
            this.lLevel.BackColor = System.Drawing.Color.Transparent;
            this.lLevel.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLevel.ForeColor = System.Drawing.Color.Black;
            this.lLevel.Location = new System.Drawing.Point(340, 347);
            this.lLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLevel.Name = "lLevel";
            this.lLevel.Size = new System.Drawing.Size(120, 54);
            this.lLevel.TabIndex = 406;
            this.lLevel.Text = "Level: ";
            this.lLevel.Visible = false;
            // 
            // bRecords
            // 
            this.bRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRecords.BackColor = System.Drawing.Color.Transparent;
            this.bRecords.BackgroundImage = global::Тетрис.Properties.Resources.records;
            this.bRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bRecords.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bRecords.FlatAppearance.BorderSize = 0;
            this.bRecords.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRecords.Location = new System.Drawing.Point(548, 747);
            this.bRecords.Margin = new System.Windows.Forms.Padding(4);
            this.bRecords.Name = "bRecords";
            this.bRecords.Size = new System.Drawing.Size(47, 43);
            this.bRecords.TabIndex = 412;
            this.bRecords.UseVisualStyleBackColor = false;
            this.bRecords.Click += new System.EventHandler(this.bRecords_Click);
            // 
            // bStatistics
            // 
            this.bStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bStatistics.BackColor = System.Drawing.Color.Transparent;
            this.bStatistics.BackgroundImage = global::Тетрис.Properties.Resources.statistics;
            this.bStatistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bStatistics.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.bStatistics.FlatAppearance.BorderSize = 0;
            this.bStatistics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bStatistics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStatistics.Location = new System.Drawing.Point(493, 747);
            this.bStatistics.Margin = new System.Windows.Forms.Padding(4);
            this.bStatistics.Name = "bStatistics";
            this.bStatistics.Size = new System.Drawing.Size(47, 43);
            this.bStatistics.TabIndex = 411;
            this.bStatistics.UseVisualStyleBackColor = false;
            this.bStatistics.Click += new System.EventHandler(this.bStatistics_Click);
            // 
            // bOptions
            // 
            this.bOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOptions.BackColor = System.Drawing.Color.Transparent;
            this.bOptions.BackgroundImage = global::Тетрис.Properties.Resources.options;
            this.bOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bOptions.FlatAppearance.BorderSize = 0;
            this.bOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOptions.Location = new System.Drawing.Point(603, 747);
            this.bOptions.Margin = new System.Windows.Forms.Padding(4);
            this.bOptions.Name = "bOptions";
            this.bOptions.Size = new System.Drawing.Size(47, 43);
            this.bOptions.TabIndex = 410;
            this.bOptions.UseVisualStyleBackColor = false;
            this.bOptions.Click += new System.EventHandler(this.bOptions_Click);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.BackColor = System.Drawing.Color.Transparent;
            this.bClose.BackgroundImage = global::Тетрис.Properties.Resources.close;
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bClose.FlatAppearance.BorderSize = 2;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Location = new System.Drawing.Point(616, 9);
            this.bClose.Margin = new System.Windows.Forms.Padding(4);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(33, 31);
            this.bClose.TabIndex = 409;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // nfbNewGame
            // 
            this.nfbNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nfbNewGame.BackColor = System.Drawing.Color.Transparent;
            this.nfbNewGame.BackgroundImage = global::Тетрис.Properties.Resources.newgame;
            this.nfbNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nfbNewGame.FlatAppearance.BorderSize = 4;
            this.nfbNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nfbNewGame.Location = new System.Drawing.Point(548, 9);
            this.nfbNewGame.Name = "nfbNewGame";
            this.nfbNewGame.Size = new System.Drawing.Size(61, 56);
            this.nfbNewGame.TabIndex = 414;
            this.nfbNewGame.UseVisualStyleBackColor = false;
            this.nfbNewGame.Click += new System.EventHandler(this.nfbNewGame_Click);
            // 
            // FTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(659, 802);
            this.Controls.Add(this.nfbNewGame);
            this.Controls.Add(this.bRecords);
            this.Controls.Add(this.bStatistics);
            this.Controls.Add(this.bOptions);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lLevel);
            this.Controls.Add(this.lMode);
            this.Controls.Add(this.lScore);
            this.Controls.Add(this.gNext);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FTetris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Tetris";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTetris_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTetris_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FTetris_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FTetris_MouseDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.GroupBox gNext;
        private System.Windows.Forms.Label lScore;
        private System.Windows.Forms.ToolStripMenuItem свойстваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаРекордовToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label lMode;
        private System.Windows.Forms.ToolStripMenuItem статистикаToolStripMenuItem;
        private System.Windows.Forms.Label lLevel;
        private System.Windows.Forms.ToolStripMenuItem горячиеКлавишиToolStripMenuItem;
        private NonFocusButton bClose;
        private NonFocusButton bOptions;
        private NonFocusButton bStatistics;
        private NonFocusButton bRecords;
        private NonFocusButton nfbNewGame;
    }
}

