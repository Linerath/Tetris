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
    public partial class FRecords : Form
    {
        bool newRecord;
        int[] records;
        string[] recNicks;
        DateTime[] recDate;
        FTetris mainForm;
        FConfirm confirm;

        public FRecords()
        {
            InitializeComponent();
        }

        public FRecords(FTetris _mainForm)
        {
            mainForm = _mainForm;
            InitializeComponent();
        }

        public FRecords(FTetris _mainForm, int position)
        {
            InitializeComponent();
            string str;
            newRecord = true;
            mainForm = _mainForm;

            //выделение красным нового рекорда
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                try
                {
                    str = lbl.Name.Remove(0, 4);
                    if (Int32.Parse(str) == position + 1)
                    {
                        lbl.ForeColor = Color.Red;
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        void ShowRecord(int i)
        {
            string str;

            if (i > 10) return;

            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                try
                {
                    str = lbl.Name.Remove(0, 4);
                    if (Int32.Parse(str) == i)
                    {
                        lbl.Text = i.ToString() + ". " + records[i - 1];
                        if (records[i - 1] > 0)
                            lbl.Text += " - " + recNicks[i - 1] + "   (" + recDate[i - 1].ToString() + ")";
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        void ShowRecords()
        {
            //lRec1.Text = "1. " + records[0].ToString();
            //lRec2.Text = "2. " + records[1].ToString();
            //lRec3.Text = "3. " + records[2].ToString();
            //lRec4.Text = "4. " + records[3].ToString();
            //lRec5.Text = "5. " + records[4].ToString();
            //lRec6.Text = "6. " + records[5].ToString();
            //lRec7.Text = "7. " + records[6].ToString();
            //lRec8.Text = "8. " + records[7].ToString();
            //lRec9.Text = "9. " + records[8].ToString();
            //lRec10.Text = "10. " + records[9].ToString();
            for (int i = 1; i <= 10; i++)
            {
                ShowRecord(i);
            }
        }

        void Reset()
        {
            mainForm.ResetRecords();
            records = mainForm.GetRecords();
            recNicks = mainForm.GetRecNics();
            recDate = mainForm.GetRecDate();
            ShowRecords();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            records = mainForm.GetRecords();
            recNicks = mainForm.GetRecNics();
            recDate = mainForm.GetRecDate();
            ShowRecords();
            string name;
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                name = lbl.Name;
                if (name.Length > 4)
                {
                    name = lbl.Name.Remove(4);
                    if (name == "lRec")
                    {
                        if (this.Width < lbl.Location.X + lbl.Width + 10)
                            this.Width = lbl.Location.X + lbl.Width + 10;
                    }
                }
            }
            this.BackColor = mainForm.BackColor;
        }

        private void Records_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                if (lbl.BackColor == Color.Red)
                {
                    mainForm.Enabled = true;
                    return;
                }
            }
            mainForm.Enabled = true;
            mainForm.Resume();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            MethodToConfirm mtc = new MethodToConfirm(Reset);
            confirm = new FConfirm(this, mtc, "Вы действительно хотите\nсбросить все рекорды?");
            confirm.Show(this);
        }

        private void FRecords_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}