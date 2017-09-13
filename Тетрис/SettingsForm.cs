using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Тетрис
{
    public partial class SettingsForm : Form
    {
        FTetris mainForm;

        public SettingsForm()
        {
            InitializeComponent();
        }
        public SettingsForm(FTetris _mainForm)
        {
            InitializeComponent();

            mainForm = _mainForm;

            // Фигуры.
            int i = 0;
            pixels = new PictureBox[56];
            foreach (PictureBox pic in this.Controls.OfType<PictureBox>())
                pixels[i++] = pic;
            mainForm.GetColors(out clr, out clrI, out clrJ, out clrL, out clrO, out clrS, out clrT, out clrZ);
            if (mainForm.cellTextureFill)
            {
                rbTexture.Checked = true;
                rbFill.Checked = false;
                ShowTextures();
            }
            else
            {
                rbTexture.Checked = false;
                rbFill.Checked = true;
                ShowColors();
            }

            // Горячие клавиши.
            keysSingle = mainForm.GetKeysSingle();
            ShowKeys();
        }

        #region Фон
        int selectedPicture;
        List<PictureBox> pictures = new List<PictureBox>();

        private void AddPicture(string path)
        {
            if (!File.Exists(path)) return;

            Size pictureSize = new Size(110, 70);
            Point startPoint = new Point(10, 40);
            int intervalBetweenPictures = 10;

            PictureBox pbPicture = new PictureBox();

            pbPicture.Size = pictureSize;

            Point location;
            if (pictures.Count < 1)
            {
                location = startPoint;
                pbPicture.Name = "picture0";
            }
            else
            {
                location = new Point(pictures[pictures.Count - 1].Location.X + pictures[pictures.Count - 1].Size.Width + intervalBetweenPictures,
                    startPoint.Y);
                pbPicture.Name = "picture" + (pictures.Count);
            }

            pbPicture.Location = location;

            pbPicture.Image = Image.FromFile(path);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            pbPicture.Click += new EventHandler(picture_Click);

            pictures.Add(pbPicture);
            this.pPictures.Controls.Add(pbPicture);
        }
        private void SelectPicture(PictureBox picture)
        {
            string name = picture.Name;
            if (("picture" + selectedPicture) == name) return;

            // Возвращаем предыдущую выбранную картинку.
            if (selectedPicture >= 0)
            {
                pictures[selectedPicture].Size = new Size(pictures[selectedPicture].Size.Width - 10, pictures[selectedPicture].Size.Height - 10);
                pictures[selectedPicture].Location = new Point(pictures[selectedPicture].Location.X + 5, pictures[selectedPicture].Location.Y + 5);
            }
            // Увеличиваем новоиспеченную.
            picture.Size = new Size(picture.Size.Width + 10, picture.Size.Height + 10);
            picture.Location = new Point(picture.Location.X - 5, picture.Location.Y - 5);

            selectedPicture = Int32.Parse(picture.Name.Substring(7));
        }
        private void SelectPicture(int index)
        {
            if (index < 0) return;
            PictureBox picture = null;

            foreach (PictureBox pic in pictures)
            {
                if ("picture" + index == pic.Name)
                {
                    picture = pic;
                    break;
                }
            }
            if (picture == null) return;

            SelectPicture(picture);
        }

        // Загрузка картинок из папки с программой.
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            pbColor.BackColor = mainForm.BackColor;

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());//, "(background)", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                if (Path.GetFileName(file).StartsWith("background"))
                    AddPicture(file);
            }
            if (pictures.Count > 0)
            {
                selectedPicture = -1;
                SelectPicture(0);
            }
        }

        private void picture_Click(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            if (picture == null) return;

            SelectPicture(picture);
            rbPicture.Checked = true;
        }

        private void pbColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = pbColor.BackColor;
            cd.FullOpen = true;
            cd.ShowDialog();
            pbColor.BackColor = cd.Color;
            rbColorFill.Checked = true;
        }

        private void rbPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPicture.Checked) rbColorFill.Checked = false;
        }
        private void rbColorFill_CheckedChanged(object sender, EventArgs e)
        {
            if (rbColorFill.Checked) rbPicture.Checked = false;
        }
        #endregion

        #region Фигуры
        Color clr, clrI, clrJ, clrL, clrO, clrS, clrT, clrZ;
        PictureBox[] pixels;
        bool colorChanged = false;

        void ShowColors()
        {
            this.pFigures.BackColor = clr;
            pI1.BackgroundImage = null; pI2.BackgroundImage = null; pI3.BackgroundImage = null; pI4.BackgroundImage = null;
            pJ1.BackgroundImage = null; pJ2.BackgroundImage = null; pJ3.BackgroundImage = null; pJ4.BackgroundImage = null;
            pL1.BackgroundImage = null; pL2.BackgroundImage = null; pL3.BackgroundImage = null; pL4.BackgroundImage = null;
            pO1.BackgroundImage = null; pO2.BackgroundImage = null; pO3.BackgroundImage = null; pO4.BackgroundImage = null;
            pS1.BackgroundImage = null; pS2.BackgroundImage = null; pS3.BackgroundImage = null; pS4.BackgroundImage = null;
            pT1.BackgroundImage = null; pT2.BackgroundImage = null; pT3.BackgroundImage = null; pT4.BackgroundImage = null;
            pZ1.BackgroundImage = null; pZ2.BackgroundImage = null; pZ3.BackgroundImage = null; pZ4.BackgroundImage = null;
            pI1.BackColor = clrI; pI2.BackColor = clrI; pI3.BackColor = clrI; pI4.BackColor = clrI;
            pJ1.BackColor = clrJ; pJ2.BackColor = clrJ; pJ3.BackColor = clrJ; pJ4.BackColor = clrJ;
            pL1.BackColor = clrL; pL2.BackColor = clrL; pL3.BackColor = clrL; pL4.BackColor = clrL;
            pO1.BackColor = clrO; pO2.BackColor = clrO; pO3.BackColor = clrO; pO4.BackColor = clrO;
            pS1.BackColor = clrS; pS2.BackColor = clrS; pS3.BackColor = clrS; pS4.BackColor = clrS;
            pT1.BackColor = clrT; pT2.BackColor = clrT; pT3.BackColor = clrT; pT4.BackColor = clrT;
            pZ1.BackColor = clrZ; pZ2.BackColor = clrZ; pZ3.BackColor = clrZ; pZ4.BackColor = clrZ;
        }
        void ShowTextures()
        {
            pI1.BackgroundImage = Properties.Resources.aqua; pI2.BackgroundImage = Properties.Resources.aqua;
            pI3.BackgroundImage = Properties.Resources.aqua; pI4.BackgroundImage = Properties.Resources.aqua;

            pJ1.BackgroundImage = Properties.Resources.blue; pJ2.BackgroundImage = Properties.Resources.blue;
            pJ3.BackgroundImage = Properties.Resources.blue; pJ4.BackgroundImage = Properties.Resources.blue;

            pL1.BackgroundImage = Properties.Resources.orange; pL2.BackgroundImage = Properties.Resources.orange;
            pL3.BackgroundImage = Properties.Resources.orange; pL4.BackgroundImage = Properties.Resources.orange;

            pO1.BackgroundImage = Properties.Resources.yellow; pO2.BackgroundImage = Properties.Resources.yellow;
            pO3.BackgroundImage = Properties.Resources.yellow; pO4.BackgroundImage = Properties.Resources.yellow;

            pS1.BackgroundImage = Properties.Resources.green; pS2.BackgroundImage = Properties.Resources.green;
            pS3.BackgroundImage = Properties.Resources.green; pS4.BackgroundImage = Properties.Resources.green;

            pT1.BackgroundImage = Properties.Resources.purple; pT2.BackgroundImage = Properties.Resources.purple;
            pT3.BackgroundImage = Properties.Resources.purple; pT4.BackgroundImage = Properties.Resources.purple;

            pZ1.BackgroundImage = Properties.Resources.red; pZ2.BackgroundImage = Properties.Resources.red;
            pZ3.BackgroundImage = Properties.Resources.red; pZ4.BackgroundImage = Properties.Resources.red;
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            clr = Color.FromArgb(255, 255, 255);
            clrI = Color.FromArgb(40, 241, 247);
            clrJ = Color.FromArgb(63, 72, 204);
            clrL = Color.FromArgb(225, 174, 0);
            clrO = Color.FromArgb(255, 242, 0);
            clrS = Color.FromArgb(64, 208, 2);
            clrT = Color.FromArgb(163, 73, 164);
            clrZ = Color.FromArgb(237, 28, 36);
            mainForm.SetNewColor(clr, clrI, clrJ, clrL, clrO, clrS, clrT, clrZ);
            ShowColors();
        }

        private void pFigures_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clr;
            cd.ShowDialog();
            clr = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void pI1_Click(object sender, EventArgs e)
        {
            if (rbTexture.Checked) return;
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clrI;
            cd.ShowDialog();
            clrI = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void pJ1_Click(object sender, EventArgs e)
        {
            if (rbTexture.Checked) return;
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clrJ;
            cd.ShowDialog();
            clrJ = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void pL1_Click(object sender, EventArgs e)
        {
            if (rbTexture.Checked) return;
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clrL;
            cd.ShowDialog();
            clrL = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void pO1_Click(object sender, EventArgs e)
        {
            if (rbTexture.Checked) return;
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clrO;
            cd.ShowDialog();
            clrO = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void pS1_Click(object sender, EventArgs e)
        {
            if (rbTexture.Checked) return;
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clrS;
            cd.ShowDialog();
            clrS = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void pT1_Click(object sender, EventArgs e)
        {
            if (rbTexture.Checked) return;
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clrT;
            cd.ShowDialog();
            clrT = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void pZ1_Click(object sender, EventArgs e)
        {
            if (rbTexture.Checked) return;
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.Color = clrZ;
            cd.ShowDialog();
            clrZ = cd.Color;
            colorChanged = true;
            ShowColors();
        }
        private void rbTexture_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTexture.Checked)
            {
                rbFill.Checked = false;
                ShowTextures();
            }
        }
        private void rbFill_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFill.Checked)
            {
                rbTexture.Checked = false;
                ShowColors();
            }
        }
        #endregion

        #region Горячие клавиши
        bool change;
        Button buttonChange = null;
        string[] keysSingle;

        void ShowKeys()
        {
            if (keysSingle == null) return;

            if (keysSingle[0] == "Up")
                nfbUp.Text = "↑";
            else
                nfbUp.Text = keysSingle[0];

            if (keysSingle[1] == "Left")
                nfbLeft.Text = "←";
            else
                nfbLeft.Text = keysSingle[1];

            if (keysSingle[2] == "Down")
                nfbDown.Text = "↓";
            else
                nfbDown.Text = keysSingle[2];

            if (keysSingle[3] == "Right")
                nfbRight.Text = "→";
            else
                nfbRight.Text = keysSingle[3];

        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyData.ToString());

            if (!change || buttonChange == null) return;

            // Только для английской клавиатуры.
            if (!(((char)e.KeyData >= 65 && (char)e.KeyData <= 90) ||
                ((char)e.KeyData >= 97 && (char)e.KeyData <= 122) ||
                (e.KeyData.ToString() == "Up" || e.KeyData.ToString() == "Left" ||
                e.KeyData.ToString() == "Down" || e.KeyData.ToString() == "Right")))
            {
                MessageBox.Show("Выберите другую клавишу", "Ошибка");
                return;
            }
            // Проверка, зарезервирована ли уже эта клавиша.
            /*for (int i = 0; i < 4; i++)
            {
                if (keysSingle[i] == (e.KeyData).ToString())
                {
                    foreach (NonFocusButton button in this.tabControl1.TabPages[2].Controls.OfType<NonFocusButton>())
                    {
                        if (button == buttonChange)
                            continue;
                        if (button.Name == (i.ToString() + "_" + j.ToString()))
                        {
                            button.Text = "?";
                            button.Name = "%" + button.Name;
                            keysSingle[i] = "%";
                            break;
                        }
                    }
                }
            }*/
            int index=-1;
            if (buttonChange.Name.EndsWith("Up"))
                index = 0;
            else if (buttonChange.Name.EndsWith("Left"))
                index = 1;
            else if (buttonChange.Name.EndsWith("Down"))
                index = 2;
            else if (buttonChange.Name.EndsWith("Right"))
                index = 3;
            if (e.KeyData.ToString() == "Up")
            {
                buttonChange.Text = "↑";
                keysSingle[index] = "Up";
            }
            else if (e.KeyData.ToString() == "Left")
            {
                buttonChange.Text = "←";
                keysSingle[index] = "Left";
            }
            else if (e.KeyData.ToString() == "Down")
            {
                buttonChange.Text = "↓";
                keysSingle[index] = "Down";
            }
            else if (e.KeyData.ToString() == "Right")
            {
                buttonChange.Text = "→";
                keysSingle[index] = "Right";
            }
            else
            {
                buttonChange.Text = (e.KeyData).ToString();
                keysSingle[index] = buttonChange.Text;
            }
            change = false;
            buttonChange = null;
        }

        private void bCancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bApply1_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void nfbUp_Click(object sender, EventArgs e)
        {
            if (change) return;
            change = true;
            buttonChange = sender as Button;
        }
        private void nfbLeft_Click(object sender, EventArgs e)
        {
            if (change) return;
            change = true;
            buttonChange = sender as Button;
        }
        private void nfbDown_Click(object sender, EventArgs e)
        {
            if (change) return;
            change = true;
            buttonChange = sender as Button;
        }
        private void nfbRight_Click(object sender, EventArgs e)
        {
            if (change) return;
            change = true;
            buttonChange = sender as Button;
        }
        #endregion

        private void Apply()
        {
            if (rbPicture.Checked)
            {
                if (pictures.Count == 0 || selectedPicture < 0)
                {
                    MessageBox.Show("Вы не выбрали ни одной картинки!", "Предупреждение");
                    return;
                }
                mainForm.BackgroundImage = pictures[selectedPicture].Image;
            }
            else if (rbColorFill.Checked)
            {
                mainForm.BackgroundImage = null;
                mainForm.BackColor = pbColor.BackColor;
            }

            if (rbTexture.Checked)
                mainForm.cellTextureFill = true;
            else if (rbFill.Checked)
                mainForm.cellTextureFill = false;
            if (colorChanged)
                mainForm.SetNewColor(clr, clrI, clrJ, clrL, clrO, clrS, clrT, clrZ);

            for (int i = 0; i < keysSingle.Length; i++)
                mainForm.SetKeySingle(i, keysSingle[i]);
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Apply();
            this.Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
            mainForm.Resume();
            e.Cancel = true;
            this.Hide();
        }
    }
}