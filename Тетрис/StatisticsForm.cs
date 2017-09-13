using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace Тетрис
{
    public partial class StatisticsForm : Form
    {
        uint fullCount;
        int freq;
        uint[] statistics;
        double[] statPerc;
        FTetris mainForm;
        Color clr, clrI, clrJ, clrL, clrO, clrS, clrT, clrZ;
        FConfirm confirm;

        public StatisticsForm()
        {
            InitializeComponent();
        }

        public StatisticsForm(uint[] _statistics, FTetris _mainForm)
        {
            statistics = _statistics;
            mainForm = _mainForm;
            mainForm = _mainForm;
            fullCount = 0;

            InitializeComponent();
        }

        void ShowColors()
        {
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
        void ShowFreq()
        {
            pFreq1.BackgroundImage = null; pFreq2.BackgroundImage = null; pFreq3.BackgroundImage = null; pFreq4.BackgroundImage = null;
            pFreq5.BackgroundImage = null; pFreq6.BackgroundImage = null; pFreq7.BackgroundImage = null; pFreq8.BackgroundImage = null;
            switch (freq)
            {
                case 0:
                    if (mainForm.cellTextureFill)
                    {
                        pFreq5.BackgroundImage = Properties.Resources.aqua; pFreq6.BackgroundImage = Properties.Resources.aqua;
                        pFreq7.BackgroundImage = Properties.Resources.aqua; pFreq8.BackgroundImage = Properties.Resources.aqua;
                    }
                    else
                    {
                        pFreq5.BackColor = clrI; pFreq6.BackColor = clrI;
                        pFreq7.BackColor = clrI; pFreq8.BackColor = clrI;
                    }
                    break;
                case 1:
                    if (mainForm.cellTextureFill)
                    {
                        pFreq1.BackgroundImage = Properties.Resources.blue; pFreq5.BackgroundImage = Properties.Resources.blue;
                        pFreq6.BackgroundImage = Properties.Resources.blue; pFreq7.BackgroundImage = Properties.Resources.blue;
                    }
                    else
                    {
                        pFreq1.BackColor = clrJ; pFreq5.BackColor = clrJ;
                        pFreq6.BackColor = clrJ; pFreq7.BackColor = clrJ;
                    }
                    break;
                case 2:
                    if (mainForm.cellTextureFill)
                    {
                        pFreq2.BackgroundImage = Properties.Resources.orange; pFreq3.BackgroundImage = Properties.Resources.orange;
                        pFreq4.BackgroundImage = Properties.Resources.orange; pFreq6.BackgroundImage = Properties.Resources.orange;
                    }
                    else
                    {
                        pFreq2.BackColor = clrL; pFreq3.BackColor = clrL;
                        pFreq4.BackColor = clrL; pFreq6.BackColor = clrL;
                    }
                    break;
                case 3:
                    if (mainForm.cellTextureFill)
                    {
                        pFreq2.BackgroundImage = Properties.Resources.yellow; pFreq3.BackgroundImage = Properties.Resources.yellow;
                        pFreq6.BackgroundImage = Properties.Resources.yellow; pFreq7.BackgroundImage = Properties.Resources.yellow;
                    }
                    else
                    {
                        pFreq2.BackColor = clrO; pFreq3.BackColor = clrO;
                        pFreq6.BackColor = clrO; pFreq7.BackColor = clrO;
                    }
                    break;
                case 4:
                    if (mainForm.cellTextureFill)
                    {
                        pFreq3.BackgroundImage = Properties.Resources.green; pFreq4.BackgroundImage = Properties.Resources.green;
                        pFreq6.BackgroundImage = Properties.Resources.green; pFreq7.BackgroundImage = Properties.Resources.green;
                    }
                    else
                    {
                        pFreq3.BackColor = clrS; pFreq4.BackColor = clrS;
                        pFreq6.BackColor = clrS; pFreq7.BackColor = clrS;
                    }
                    break;
                case 5:
                    if (mainForm.cellTextureFill)
                    {
                        pFreq2.BackgroundImage = Properties.Resources.purple; pFreq5.BackgroundImage = Properties.Resources.purple;
                        pFreq6.BackgroundImage = Properties.Resources.purple; pFreq7.BackgroundImage = Properties.Resources.purple;
                    }
                    else
                    {
                        pFreq2.BackColor = clrT; pFreq5.BackColor = clrT;
                        pFreq6.BackColor = clrT; pFreq7.BackColor = clrT;
                    }
                    break;
                case 6:
                    if (mainForm.cellTextureFill)
                    {
                        pFreq1.BackgroundImage = Properties.Resources.red; pFreq2.BackgroundImage = Properties.Resources.red;
                        pFreq6.BackgroundImage = Properties.Resources.red; pFreq7.BackgroundImage = Properties.Resources.red;
                    }
                    else
                    {
                        pFreq1.BackColor = clrZ; pFreq2.BackColor = clrZ;
                        pFreq6.BackColor = clrZ; pFreq7.BackColor = clrZ;
                    }
                    break;
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InRTB(RichTextBox rtb, int index)
        {
            string str = (statPerc[index] * 100).ToString();
            if (str.Length >= 7)
                str = str.Remove(6);

            str = (Math.Round(Double.Parse(str), 2)).ToString();
            rtb.Text = "Количество появлений: " + statistics[index] + "\nПроцент выпадения: " + str + "%";
            //Math.Round((Convert.ToDouble(str)))
        }

        void ShowStatistics()
        {
            InRTB(rtbI, 0);
            InRTB(rtbJ, 1);
            InRTB(rtbL, 2);
            InRTB(rtbO, 3);
            InRTB(rtbS, 4);
            InRTB(rtbT, 5);
            InRTB(rtbZ, 6);
            lFull.Text = "Общее количество всех фигур: " + fullCount;
        }

        private void FStatistics_Load(object sender, EventArgs e)
        {
            mainForm.GetColors(out clr, out clrI, out clrJ, out clrL, out clrO, out clrS, out clrT, out clrZ);
            statistics = mainForm.GetStatistics();
            statPerc = new double[statistics.Length];
            try
            {
                for (int i = 0; i < statistics.Length; i++)
                {
                    fullCount += statistics[i];
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("Счет фигур дошел до предела. Статистика сброшена. Просим извинения за предоставленные неудобства", "Предупреждение");
                mainForm.ResetStatistics();
            }
            double temp = statPerc[0];
            freq = 0;
            for (int i = 0; i < statistics.Length; i++)
            {
                statPerc[i] = (statistics[i]+0.0) / fullCount;
                if (statPerc[i] > temp)
                {
                    temp = statPerc[i];
                    freq = i;
                }
            }
            if (mainForm.cellTextureFill)
                ShowTextures();
            else
                ShowColors();
            ShowStatistics();
            ShowFreq();
            this.BackColor = mainForm.BackColor;
        }

        void Reset()
        {
            mainForm.ResetStatistics();
            statistics = mainForm.GetStatistics();
            ShowStatistics();
        }

        private void FStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
            mainForm.Resume();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            MethodToConfirm mtc = new MethodToConfirm(Reset);
            confirm = new FConfirm(this, mtc, "Вы действительно хотите\nсбросить всю статистику?");
            confirm.Show(this);
        }

        private void StatisticsForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}