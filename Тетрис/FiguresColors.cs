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
    public partial class FiguresColorsForm : Form
    {
        bool changed = false;
        FTetris mainForm;
        Color clr, clrI, clrJ, clrL, clrO, clrS, clrT, clrZ;
        PictureBox[] pixels;
        ColorDialog cd = new ColorDialog();

        public FiguresColorsForm()
        {
            InitializeComponent();
            int i = 0;
            pixels = new PictureBox[56];
            foreach (PictureBox pic in this.Controls.OfType<PictureBox>())
                pixels[i++] = pic;
            cd.FullOpen = true;
        }

        public FiguresColorsForm(FTetris _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            int i = 0;
            pixels = new PictureBox[56];
            foreach (PictureBox pic in this.Controls.OfType<PictureBox>())
                pixels[i++] = pic;
            cd.FullOpen = true;
        }

        void ShowColors()
        {
            //Background
            this.BackColor = clr;
            //I
            pI1.BackColor = clrI; pI2.BackColor = clrI; pI3.BackColor = clrI; pI4.BackColor = clrI;
            //J
            pJ1.BackColor = clrJ; pJ2.BackColor = clrJ; pJ3.BackColor = clrJ; pJ4.BackColor = clrJ;
            //L
            pL1.BackColor = clrL; pL2.BackColor = clrL; pL3.BackColor = clrL; pL4.BackColor = clrL;
            //O
            pO1.BackColor = clrO; pO2.BackColor = clrO; pO3.BackColor = clrO; pO4.BackColor = clrO; 
            //S
            pS1.BackColor = clrS; pS2.BackColor = clrS; pS3.BackColor = clrS; pS4.BackColor = clrS;
            //T
            pT1.BackColor = clrT; pT2.BackColor = clrT; pT3.BackColor = clrT; pT4.BackColor = clrT;
            //Z
            pZ1.BackColor = clrZ; pZ2.BackColor = clrZ; pZ3.BackColor = clrZ; pZ4.BackColor = clrZ;
        }

        private void FiguresColors_Load(object sender, EventArgs e)
        {
            mainForm.GetColors(out clr, out clrI, out clrJ, out clrL, out clrO, out clrS, out clrT, out clrZ);
            ShowColors();
        }

        private void FiguresColors_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
                MessageBox.Show("Изменения сохранены не будут.", "Уведомление");
            mainForm.Enabled = true;
            mainForm.Resume();
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

        private void bOk_Click(object sender, EventArgs e)
        {
            changed = false;
            mainForm.SetNewColor(clr, clrI, clrJ, clrL, clrO, clrS, clrT, clrZ);
            this.Close();
        }

        private void FiguresColors_Click(object sender, EventArgs e)
        {
            cd.Color = clr;
            cd.ShowDialog();
            clr = cd.Color;
            changed = true;
            ShowColors();
        }
        private void pI1_Click(object sender, EventArgs e)
        {
            cd.Color = clrI;
            cd.ShowDialog();
            clrI = cd.Color;
            changed = true;
            ShowColors();
        }
        private void pJ1_Click(object sender, EventArgs e)
        {
            cd.Color = clrJ;
            cd.ShowDialog();
            clrJ = cd.Color;
            changed = true;
            ShowColors();
        }
        private void pL1_Click(object sender, EventArgs e)
        {
            cd.Color = clrL;
            cd.ShowDialog();
            clrL = cd.Color;
            changed = true;
            ShowColors();
        }
        private void pO1_Click(object sender, EventArgs e)
        {
            cd.Color = clrO;
            cd.ShowDialog();
            clrO = cd.Color;
            changed = true;
            ShowColors();
        }
        private void pS1_Click(object sender, EventArgs e)
        {
            cd.Color = clrS;
            cd.ShowDialog();
            clrS = cd.Color;
            changed = true;
            ShowColors();
        }
        private void pT1_Click(object sender, EventArgs e)
        {
            cd.Color = clrT;
            cd.ShowDialog();
            clrT = cd.Color;
            changed = true;
            ShowColors();
        }
        private void pZ1_Click(object sender, EventArgs e)
        {
            cd.Color = clrZ;
            cd.ShowDialog();
            clrZ = cd.Color;
            changed = true;
            ShowColors();
        }
    }
}