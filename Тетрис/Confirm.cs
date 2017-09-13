using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Тетрис
{
    public partial class FConfirm : Form
    {
        Form form;
        MethodToConfirm mtc;

        public FConfirm()
        {
            InitializeComponent();
        }

        public FConfirm(Form _form, MethodToConfirm _mtc, string labelText)
        {
            InitializeComponent();
            form = _form;
            mtc = _mtc;
            lText.Text = labelText;
        }

        void AlignForm()
        {
            Point p;

            //размеры формы. кнопки должны быть одинаковой высоты
            if (lText.Width > bYes.Width + bNo.Width)
            {
                this.Width = lText.Width + 30;
            }
            else
            {
                this.Width = bYes.Width + bNo.Width + 5 + 30;
            }
            this.Height = lText.Height + 10 + bYes.Width;

            //размещение label
            p = new Point()
            {
                X = ((this.Width - lText.Width) / 2),
                Y = 15
            };
            lText.Location = p;

            //размещение button1
            p = new Point()
            {
                X = Convert.ToInt32((this.Width / 2) - 2.5 - bYes.Width),
                Y = 15 + lText.Height + 10
            };
            bYes.Location = p;

            //размещение button2
            p = new Point();
            p.X = bYes.Location.X + bYes.Width + 5;
            p.Y = bYes.Location.Y;
            bNo.Location = p;
        }

        private void bYes_Click(object sender, EventArgs e)
        {
            mtc();
            form.Enabled = true;
            this.Close();
        }

        private void bNo_Click(object sender, EventArgs e)
        {
            form.Enabled = true;
            if (form is FTetris mainForm)
            {
                mainForm.Resume();
            }
            this.Close();
        }

        private void FConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Enabled = true;
        }

        private void FConfirm_Load(object sender, EventArgs e)
        {
            AlignForm();
        }
    }
}
