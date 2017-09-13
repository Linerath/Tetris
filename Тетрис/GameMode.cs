//#define OldVersion
#define NewVersion

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
    public partial class GameModeForm : Form
    {
        FTetris mainForm = new FTetris();

        public GameModeForm()
        {
            InitializeComponent();

            mainForm.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        private void bSingle_Click(object sender, EventArgs e)
        {
            mainForm.SinglePlayerMode();
            mainForm.Show();
            this.Hide();
        }
        private void b2Pl_Click(object sender, EventArgs e)
        {
            mainForm.XPlayersMode(2);
            mainForm.Show();
            this.Hide();
        }
        private void b3Pl_Click(object sender, EventArgs e)
        {
            mainForm.XPlayersMode(3);
            mainForm.Show();
            this.Hide();
        }
        private void b4Pl_Click(object sender, EventArgs e)
        {
            mainForm.XPlayersMode(4);
            mainForm.Show();
            this.Hide();
        }

        private void bFun_Click(object sender, EventArgs e)
        {
            mainForm.SinglePlayerMode(true);
            mainForm.Show();
            this.Hide();
        }

        private void FGameMode_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}