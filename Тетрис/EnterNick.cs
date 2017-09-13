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
    public partial class FNickEnter : Form
    {
        FTetris mainForm;
        string name;
        int position;

        public FNickEnter()
        {
            InitializeComponent();
        }

        public FNickEnter(FTetris _mainForm, int _position)
        {
            mainForm = _mainForm;
            position = _position;
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            name = tNick.Text;
            if (name == "")
            {
                MessageBox.Show("Пожалуйста, введите имя", "Tetris");
                return;
            }
            mainForm.SetRecNick(position, name);
            mainForm.SetRecDate(position);
            mainForm.recForm = new FRecords(mainForm, position);
            mainForm.recForm.Show();
            this.Close();
        }
    }
}