using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Тетрис
{
    public partial class HotKeysForm : Form
    {
        int keyI, keyJ;
        int time;
        byte plCount;
        bool change;
        //bool light;
        string[][] keys;
        NonFocusButton btnChange;
        NonFocusButton btnLight;
        System.Windows.Forms.Timer timer;
        FTetris mainForm;
        Size btnSize;
        Size gbSize;
        Font btnFont;
        Random random;

        public HotKeysForm()
        {
            InitializeComponent();
        }

        public HotKeysForm(FTetris _mainForm)
        {
            mainForm = _mainForm;
            change = false;
            time = 5;
            plCount = mainForm.GetPlayersCount();
            keys = mainForm.GetKeys();
            btnSize = new Size(75, 75);
            btnFont = new Font("Segoe Print", 18, FontStyle.Bold);
            random = new Random();
            InitializeComponent();
        }

        private void FHotKeys_Load(object sender, EventArgs e)
        {
            Point loc = new Point(10, 10 + MainMenu.Size.Height + 10);
            for (int i = 0; i < plCount; i++)
            {
                CreateKeys(i, keys[i], loc);
                loc.X = loc.X + gbSize.Width + 10;
            }
            this.ClientSize = new Size(gbSize.Width * plCount + 10 * plCount + 10, 10 + gbSize.Height + 10 + 20 + MainMenu.Size.Height);
            this.BackColor = mainForm.BackColor;
            this.Closing += new CancelEventHandler(FHotKeys_FormClosing);
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
        }

        void CreateKeys(int plNumber, string[] keys, Point point)
        {
            GroupBox gb = CreateKeyGroupBox("Player" + (plNumber + 1));
            gb.Location = point;
            gb.Font = new Font("Segoe Print", 18, FontStyle.Bold);
            gb.ClientSize = new Size(btnSize.Width * 3 + 20, btnSize.Height * 2 + 80);
            gbSize = gb.Size;
            this.Controls.Add(gb);

            NonFocusButton key;
            Point loc = new Point(gb.ClientSize.Width / 2 - btnSize.Width / 2, 50);
            key = CreateKeyButton(loc, keys[0], plNumber.ToString() + "_0");
            gb.Controls.Add(key);
            loc = new Point(loc.X - btnSize.Width, loc.Y + btnSize.Height);
            key = CreateKeyButton(loc, keys[1], plNumber.ToString() + "_1");
            gb.Controls.Add(key);
            loc.X = loc.X + btnSize.Width;
            key = CreateKeyButton(loc, keys[2], plNumber.ToString() + "_2");
            gb.Controls.Add(key);
            loc.X = loc.X + btnSize.Width;
            key = CreateKeyButton(loc, keys[3], plNumber.ToString() + "_3");
            gb.Controls.Add(key);
        }

        GroupBox CreateKeyGroupBox(string text)
        {
            GroupBox gb = new GroupBox() {Text = text};
            return gb;
        }
        NonFocusButton CreateKeyButton(Point point, string text, string name)
        {
            NonFocusButton btn = new NonFocusButton()
            {
                Size = btnSize,
                Font = btnFont,
                Location = point,
                Name = name
            };
            btn.MouseClick += new MouseEventHandler(ChangeKey_MouseDown);
            btn.KeyPress += new KeyPressEventHandler(ChangeKey_KeyPress);
            btn.BackColor = Color.White;
            if (text == "Up")
            {
                btn.Text = "↑";
            }
            else if (text == "Left")
            {
                btn.Text = "←";
            }
            else if (text == "Down")
            {
                btn.Text = "↓";
            }
            else if (text == "Right")
            {
                btn.Text = "→";
            }
            else
                btn.Text = text;
            return btn;
        }

        private void ChangeKey_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (change)
                    return;
                
                //foreach (Button b in this.Controls.OfType<Button>())
                //{
                //    b.TabStop = false;
                //}
                //foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
                //{
                //    foreach (Button b in gb.Controls.OfType<Button>())
                //    {
                //        b.TabStop = false;
                //    }
                //}
                //this.Focus();

                NonFocusButton btn = (NonFocusButton)sender;
                btnChange = btn;
                if (btn.Name[0] == '%')
                    btn.Name = btn.Name.Substring(1);
                keyI = Int32.Parse(btn.Name.Remove(btn.Name.IndexOf('_')));
                keyJ = Int32.Parse(btn.Name.Substring(btn.Name.IndexOf('_') + 1));
                //MessageBox.Show(i.ToString() + "   " + j.ToString());
                change = true;
                btn.Text = "_";
            }
            catch
            {
                MessageBox.Show("Критическая ошибка. Обратитесь к разработчику.", "Ошибка");
            }
        }

        private void ChangeKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FHotKeys_FormClosing(object sender, CancelEventArgs e)
        {
            try
            {
                for (int i = 0; i < plCount; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (keys[i][j][0] == '%')
                        {
                            MessageBox.Show("Пожалуйста, укажите все клавиши.", "Предупреждение");
                            CancelEventArgs cea = new CancelEventArgs(true);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                e.Cancel = false;
                for (int i = 0; i < plCount; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        mainForm.SetKey(i, j, keys[i][j]);
                    }
                }
                mainForm.Enabled = true;
                mainForm.Resume();
            }
            catch
            {
                MessageBox.Show("Критическая ошибка. Обратитесь к разработчику.", "Ошибка");
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
        }

        private void TLight_Tick(object sender, EventArgs e)
        {
            if (time>0&& btnLight != null)
            {
                btnLight.BackColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                time--;
            }
            else
            {
                time = 5;
                ((System.Windows.Forms.Timer)sender).Enabled = false;
                btnLight.BackColor = Color.White;
            }
        }

        private void bDefault_Click(object sender, EventArgs e)
        {
            
        }

        private void bArrows_Click(object sender, EventArgs e)
        {

        }

        private void FHotKeys_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (change)
                {
                    if ((((char)e.KeyData >= 1040 && (char)e.KeyData <= 1071) || ((char)e.KeyData >= 1072 && (char)e.KeyData <= 1103)))
                        return;
                    //только для английской клавиатуры
                    if (!(((char)e.KeyData >= 65 && (char)e.KeyData <= 90) ||
                        ((char)e.KeyData >= 97 && (char)e.KeyData <= 122) ||
                        (e.KeyData.ToString() == "Up" || e.KeyData.ToString() == "Left" ||
                        e.KeyData.ToString() == "Down" || e.KeyData.ToString() == "Right")))
                    {
                        MessageBox.Show("Выберите другую клавишу", "Ошибка");
                        return;
                    }
                    time = 0;
                    //проверка, зарезервирована ли уже эта клавиша
                    for (int i = 0; i < plCount; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (keys[i][j] == (e.KeyData).ToString())
                            {
                                foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
                                {
                                    foreach (NonFocusButton btn in gb.Controls.OfType<NonFocusButton>())
                                    {
                                        if (btn == btnChange)
                                            continue;
                                        if (btn.Name == (i.ToString() + "_" + j.ToString()))
                                        {
                                            btn.Text = "?";
                                            btn.Name = "%" + btn.Name;
                                            keys[i][j] = "%";
                                            goto next;
                                        }
                                    }
                                }
                            }
                        }
                    }
                next: change = false;
                    if (e.KeyData.ToString() == "Up")
                    {
                        btnChange.Text = "↑";
                        keys[keyI][keyJ] = "Up";
                    }
                    else if (e.KeyData.ToString() == "Left")
                    {
                        btnChange.Text = "←";
                        keys[keyI][keyJ] = "Left";
                    }
                    else if (e.KeyData.ToString() == "Down")
                    {
                        btnChange.Text = "↓";
                        keys[keyI][keyJ] = "Down";
                    }
                    else if (e.KeyData.ToString() == "Right")
                    {
                        btnChange.Text = "→";
                        keys[keyI][keyJ] = "Right";
                    }
                    else
                    {
                        btnChange.Text = (e.KeyData).ToString();
                        keys[keyI][keyJ] = btnChange.Text;
                    }
                }
                else
                {
                    //подстветка нажатых горячих клавиш
                    if (((char)e.KeyData >= 65 && (char)e.KeyData <= 90) ||
                        ((char)e.KeyData >= 97 && (char)e.KeyData <= 122) ||
                        e.KeyData.ToString() == "Up" || e.KeyData.ToString() == "Left" || e.KeyData.ToString() == "Down" || e.KeyData.ToString() == "Right")
                    {
                        time = 0;
                        for (int i = 0; i < plCount; i++)

                            for (int j = 0; j < 4; j++)
                            {
                                if (keys[i][j] == (e.KeyData).ToString())
                                {
                                    foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
                                    {
                                        foreach (NonFocusButton btn in gb.Controls.OfType<NonFocusButton>())
                                        {
                                            if (btn.Text == (e.KeyData).ToString() ||
                                                (btn.Text == "↑" && (e.KeyData).ToString() == "Up") ||
                                                (btn.Text == "←" && (e.KeyData).ToString() == "Left") ||
                                                (btn.Text == "↓" && (e.KeyData).ToString() == "Down") ||
                                                (btn.Text == "→" && (e.KeyData).ToString() == "Right"))
                                            {
                                                if (timer != null)
                                                {
                                                    TLight_Tick(timer, System.EventArgs.Empty);
                                                }
                                                timer = new System.Windows.Forms.Timer();
                                                timer.Interval = 10;
                                                timer.Tick += new EventHandler(TLight_Tick);
                                                btnLight = btn;
                                                timer.Enabled = true;
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Критическая ошибка. Обратитесь к разработчику.", "Ошибка");
            }
        }

        private void тестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mainForm.DefaultKeys();
                keys = mainForm.GetKeys();
                int i, j;
                foreach (GroupBox gb in this.Controls.OfType<GroupBox>())
                {
                    foreach (NonFocusButton btn in gb.Controls.OfType<NonFocusButton>())
                    {
                        if (btn.Name[0] == '%')
                            btn.Name = btn.Name.Substring(1);
                        i = Int32.Parse(btn.Name.Remove(btn.Name.IndexOf('_')));
                        j = Int32.Parse(btn.Name.Substring(btn.Name.IndexOf('_') + 1));
                        if (keys[i][j] == "Up")
                        {
                            btn.Text = "↑";
                        }
                        else if (keys[i][j] == "Left")
                        {
                            btn.Text = "←";
                        }
                        else if (keys[i][j] == "Down")
                        {
                            btn.Text = "↓";
                        }
                        else if (keys[i][j] == "Right")
                        {
                            btn.Text = "→";
                        }
                        else
                            btn.Text = keys[i][j];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Критическая ошибка. Обратитесь к разработчику.", "Ошибка");
            }
        }
    }

    class NonFocusButton : Button
    {
        public NonFocusButton()
        {
            this.SetStyle(ControlStyles.Selectable, false);
        }
    }
}