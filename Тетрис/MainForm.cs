using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Media;

namespace Тетрис
{
    public delegate void MethodToConfirm();

    public partial class FTetris : Form
    {
        int rows;             //кол-во строк
        int cells;            //кол-во столбцов
        int cellInterval = 0; // интервал между клетками
        int startSpeed = 200;
        int movingSpeed = 100;
        int increasingSpeed = 15;
        byte plCount;         /*кол-во игроков*/
        byte interval;        //расстояние между элементами формы
        bool singlePlayer;
        bool movingLeft = false;
        bool movingRight = false;
        public bool cellTextureFill { get; set; }
        bool fun;
        /******/
        int[] score;          //очки. Начисляются за уничтоженную линию
        int[] records;        //массив рекордов
        uint[] statistics;    //статистика всех фигур
        byte[][,] matrix;     //основная матрица из класса Matrix
        byte[] next;          //следующая фигура
        string[][] keys;      //бинд клавиш для игроков (мультиплеер)
        string[] keysSingle;  //бинд клавиш для одиночной игры
        string[] recNicks;    //массив имен рекордсменов
        bool[] gameOver;      //конец игры
        int[] pausedPlayers;
        /******/
        PictureBox[][] pixels;//массив "пикселей" для удобства вывода
        Matrix[] matrixObj;   //объект класса массив
        Figure[] figure;      //в классе фигура производятся все манипуляции с фигуркой
        Label[] labelScore;   //массив label'ов для вывода рекорда
        DateTime[] recDate;   //массив дата постановки рекорда
        System.Windows.Forms.Timer[] gameTimer;    //массив таймеров
        System.Windows.Forms.Timer[] movingLeftTimer;
        System.Windows.Forms.Timer[] movingRightTimer;
        Color clr, clrI, clrJ, clrL, clrO, clrS, clrT, clrZ; //цвета фигурок
        ColorDialog cd;       //для выбора фона
        SettingsForm settingsForm; //настройки
        FiguresColorsForm fc;    //дочерняя форма, на которой можно изменить цвета фигурок
        public FRecords recForm;//форма рекордов
        StatisticsForm statForm; //статистика
        HotKeysForm hotKeys;     //горячие клавиши
        FConfirm confirm;     //форма подтверждения выбора
        FNickEnter enterNick; //форма ввода имена нового рекордсмена
        Size cellSize;        //размер пикселя
        Size elementOriginalSize;
        Random random = new Random();
        //SoundPlayer sp = new SoundPlayer("sound.wav");

        public FTetris()
        {
            InitializeComponent();
            rows = 20;
            cells = 10;
            interval = 10;
            cellSize = new Size(25, 25);
            clr = Color.Black;
            cellTextureFill = true;
            LoadColors();
            LoadRecords();
            LoadStatistics();
            LoadKeys();
            LoadKeysSingle();

            settingsForm = new SettingsForm(this);
        }

        #region Методы
        #region Манипуляции с фигурой
        public void SpawnFigure(int player)
        {
            if (gameOver[player]) return;
            if (fun)
            {
                figure[0] = new Fig_I(matrix[player]);
                if (IsPlayerGameOver(0))
                {
                    PlayerStopGame(0);
                    gameOver[0] = true;
                    return;
                }
                next[0] = 1;
                figure[0].OnMatrix();
                ShowMatrix(player);
                ShowNext(player, next[0]);
                return;
            }
            try
            {
                switch (next[player])
                {
                    case 1:
                        figure[player] = new Fig_I(matrix[player]);
                        statistics[0]++;
                        break;
                    case 2:
                        figure[player] = new Fig_J(matrix[player]);
                        statistics[1]++;
                        break;
                    case 3:
                        figure[player] = new Fig_L(matrix[player]);
                        statistics[2]++;
                        break;
                    case 4:
                        figure[player] = new Fig_O(matrix[player]);
                        statistics[3]++;
                        break;
                    case 5:
                        figure[player] = new Fig_S(matrix[player]);
                        statistics[4]++;
                        break;
                    case 6:
                        figure[player] = new Fig_T(matrix[player]);
                        statistics[5]++;
                        break;
                    case 7:
                        figure[player] = new Fig_Z(matrix[player]);
                        statistics[6]++;
                        break;
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Счет одной из фигур дошел до предела. Статистика сброшена. Просим извинения за предоставленные неудобства", "Предупреждение");
                ResetStatistics();
            }
            next[player] = GetRandomForm();
            if (IsPlayerGameOver(player))
            {
                PlayerStopGame(player);
                gameOver[player] = true;
                return;
            }
            figure[player].OnMatrix();
            ShowMatrix(player);
            ShowNext(player, next[player]);
        }
        public void FigureLeft(int player)
        {
            if (gameOver[player]) return;
            try
            {
                figure[player].Left();
                ShowMatrix(player);
            }
            catch { }
        }
        public void FigureRight(int player)
        {
            if (gameOver[player]) return;
            try
            {
                figure[player].Right();
                ShowMatrix(player);
            }
            catch { }
        }
        public void FigureInstant(int player)
        {
            if (gameOver[player]) return;
            try
            {
                while (true)
                {
                    figure[player].Down();
                }
            }
            catch
            {

                int count;
                count = matrixObj[player].DestructedCount();
                if (count > 0 && !fun)
                {
                    string oldScore = score[player].ToString();
                    if (Int32.Parse(oldScore[oldScore.Length-1].ToString()) + count >= 10)
                    {
                        labelScore[player].Text += "\nInc";
                        PlayerIncreaseSpeed(player);
                    }
                        score[player] += count;
                    ShowScore(player);
                }
                SpawnFigure(player);
            }
        }
        public void FigureTurn(int player)
        {
            if (gameOver[player]) return;
            try
            {
                figure[player].Turn();
            }
            catch { }
            ShowMatrix(player);
        }
        public void FigureIncSpeed(int player)
        {
            if (gameOver[player]) return;
            try
            {
                if (gameTimer[player].Interval > 40)
                {
                    gameTimer[player].Interval = 40;
                    ShowMatrix(player);
                }
            }
            catch { }
        }
        public void FigureDecSpeed(int player)
        {
            if (gameOver[player]) return;
            try
            {
                gameTimer[player].Interval = startSpeed;
                ShowMatrix(player);
            }
            catch { }
        }
        private void PlayerIncreaseSpeed(int player)
        {
            if (gameOver[player]) return;
            try
            {
                if (gameTimer[player].Interval > increasingSpeed)
                    gameTimer[player].Interval -= increasingSpeed;
            }
            catch { }
        }
        byte GetRandomForm()
        {
            return (byte)(random.Next(7) + 1);
        }
        #endregion

        #region Запись, загрузка и инициализация необходимых данных (цвета, рекорды, бинды)
        void LoadColors()
        {
            BinaryReader br = null;
            try
            {
                br = new BinaryReader(new FileStream("colors.tet", FileMode.OpenOrCreate));
                this.BackColor = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clr = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clrI = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clrJ = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clrL = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clrO = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clrS = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clrT = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
                clrZ = Color.FromArgb(br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadByte());
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }
        void LoadRecords()
        {
            BinaryReader br = null;
            try
            {
                records = new int[10];
                recNicks = new string[10];
                recDate = new DateTime[10];
                br = new BinaryReader(new FileStream("records.tet", FileMode.OpenOrCreate));
                for (int i = 0; i < records.Length; i++)
                {
                    records[i] = br.ReadInt32();
                    recNicks[i] = br.ReadString();
                    recDate[i] = new DateTime(br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }
        void LoadStatistics()
        {
            BinaryReader br = null;
            try
            {
                statistics = new uint[7];
                br = new BinaryReader(new FileStream("statistics.tet", FileMode.OpenOrCreate));
                for (int i = 0; i < statistics.Length; i++)
                {
                    statistics[i] = br.ReadUInt32();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }
        void LoadKeys()
        {
            BinaryReader br = null;
            try
            {
                keys = new string[4][];
                for (int i = 0; i < 4; i++)
                {
                    keys[i] = new string[4];
                }

                br = new BinaryReader(new FileStream("keys.tet", FileMode.OpenOrCreate));
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        keys[i][j] = br.ReadString();
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }
        void LoadKeysSingle()
        {
            BinaryReader br = null;
            try
            {
                keysSingle = new string[4];

                br = new BinaryReader(new FileStream("keysSingle.tet", FileMode.OpenOrCreate));
                for (int i = 0; i < 4; i++)
                {

                    keysSingle[i] = br.ReadString();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }
        void WriteColors()
        {
            BinaryWriter bw = null;
            try
            {
                bw = new BinaryWriter(new FileStream("colors.tet", FileMode.Create));
                bw.Write(this.BackColor.A); bw.Write(this.BackColor.R); bw.Write(this.BackColor.G); bw.Write(this.BackColor.B);
                bw.Write(clr.A); bw.Write(clr.R); bw.Write(clr.G); bw.Write(clr.B);
                bw.Write(clrI.A); bw.Write(clrI.R); bw.Write(clrI.G); bw.Write(clrI.B);
                bw.Write(clrJ.A); bw.Write(clrJ.R); bw.Write(clrJ.G); bw.Write(clrJ.B);
                bw.Write(clrL.A); bw.Write(clrL.R); bw.Write(clrL.G); bw.Write(clrL.B);
                bw.Write(clrO.A); bw.Write(clrO.R); bw.Write(clrO.G); bw.Write(clrO.B);
                bw.Write(clrS.A); bw.Write(clrS.R); bw.Write(clrS.G); bw.Write(clrS.B);
                bw.Write(clrT.A); bw.Write(clrT.R); bw.Write(clrT.G); bw.Write(clrT.B);
                bw.Write(clrZ.A); bw.Write(clrZ.R); bw.Write(clrZ.G); bw.Write(clrZ.B);
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }
        void WriteRecords()
        {
            BinaryWriter bw = null;
            try
            {
                bw = new BinaryWriter(new FileStream("records.tet", FileMode.Create));
                for (int i = 0; i < records.Length; i++)
                {
                    bw.Write(records[i]);
                    bw.Write(recNicks[i]);

                    bw.Write(recDate[i].Year);
                    bw.Write(recDate[i].Month);
                    bw.Write(recDate[i].Day);
                    bw.Write(recDate[i].Hour);
                    bw.Write(recDate[i].Minute);
                    bw.Write(recDate[i].Second);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }
        void WriteStatistics()
        {
            BinaryWriter bw = null;
            try
            {
                bw = new BinaryWriter(new FileStream("statistics.tet", FileMode.Create));
                foreach (uint u in statistics)
                {
                    bw.Write(u);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }
        void WriteKeys()
        {
            BinaryWriter bw = null;
            try
            {
                //keys = new string[4][];
                //for (int i = 0; i < 4; i++)
                //{
                //    keys[i] = new string[4];
                //}
                //keys[0][0] = "W";
                //keys[0][1] = "A";
                //keys[0][2] = "S";
                //keys[0][3] = "D";

                //keys[1][0] = "T";
                //keys[1][1] = "F";
                //keys[1][2] = "G";
                //keys[1][3] = "H";

                //keys[2][0] = "I";
                //keys[2][1] = "J";
                //keys[2][2] = "K";
                //keys[2][3] = "L";

                //keys[3][0] = "Up";
                //keys[3][1] = "Left";
                //keys[3][2] = "Down";
                //keys[3][3] = "Right";

                bw = new BinaryWriter(new FileStream("keys.tet", FileMode.Create));
                for (int i = 0; i < 4; i++)
                {
                    foreach (string s in keys[i])
                    {
                        bw.Write(s);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }
        void WriteKeysSingle()
        {
            BinaryWriter bw = null;
            try
            {
                //keysSingle = new string[4];
                //keysSingle[0] = "Up";
                //keysSingle[1] = "Left";
                //keysSingle[2] = "Down";
                //keysSingle[3] = "Right";

                bw = new BinaryWriter(new FileStream("keysSingle.tet", FileMode.Create));
                foreach (string s in keysSingle)
                    bw.Write(s);
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка чтения файла!", "Error");
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Error");
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }
        #endregion

        void ShowMatrix(int player)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    pixels[player][(i * cells) + j].BackgroundImage = null;
                    switch (matrix[player][i, j])
                    {
                        case 0:
                            pixels[player][(i * cells) + j].BackColor = clr;
                            break;
                        case 1:
                            if (cellTextureFill)
                                pixels[player][(i * cells) + j].BackgroundImage = Properties.Resources.aqua;
                            else
                                pixels[player][(i * cells) + j].BackColor = clrI;
                            break;
                        case 2:
                            if (cellTextureFill)
                                pixels[player][(i * cells) + j].BackgroundImage = Properties.Resources.blue;
                            else
                                pixels[player][(i * cells) + j].BackColor = clrJ;
                            break;
                        case 3:
                            if (cellTextureFill)
                                pixels[player][(i * cells) + j].BackgroundImage = Properties.Resources.orange;
                            else
                                pixels[player][(i * cells) + j].BackColor = clrL;
                            break;
                        case 4:
                            if (cellTextureFill)
                                pixels[player][(i * cells) + j].BackgroundImage = Properties.Resources.yellow;
                            else
                                pixels[player][(i * cells) + j].BackColor = clrO;
                            break;
                        case 5:
                            if (cellTextureFill)
                                pixels[player][(i * cells) + j].BackgroundImage = Properties.Resources.green;
                            else
                                pixels[player][(i * cells) + j].BackColor = clrS;
                            break;
                        case 6:
                            if (cellTextureFill)
                                pixels[player][(i * cells) + j].BackgroundImage = Properties.Resources.purple;
                            else
                                pixels[player][(i * cells) + j].BackColor = clrT;
                            break;
                        case 7:
                            if (cellTextureFill)
                                pixels[player][(i * cells) + j].BackgroundImage = Properties.Resources.red;
                            else
                                pixels[player][(i * cells) + j].BackColor = clrZ;
                            break;
                    }
                }
            }
        }
        void ShowNext(int player, int nxt)
        {
            int i;
            i = rows * cells;
            pixels[player][i++].BackgroundImage = null; pixels[player][i++].BackgroundImage = null;
            pixels[player][i++].BackgroundImage = null; pixels[player][i++].BackgroundImage = null;
            pixels[player][i++].BackgroundImage = null; pixels[player][i++].BackgroundImage = null;
            pixels[player][i++].BackgroundImage = null; pixels[player][i++].BackgroundImage = null;
            i = rows * cells;
            switch (nxt)
            {
                case 1:
                    pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                    pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                    if (cellTextureFill)
                    {
                        pixels[player][i++].BackgroundImage = Properties.Resources.aqua; pixels[player][i++].BackgroundImage = Properties.Resources.aqua;
                        pixels[player][i++].BackgroundImage = Properties.Resources.aqua; pixels[player][i++].BackgroundImage = Properties.Resources.aqua;
                    }
                    else
                    {
                        pixels[player][i++].BackColor = clrI; pixels[player][i++].BackColor = clrI;
                        pixels[player][i++].BackColor = clrI; pixels[player][i++].BackColor = clrI;
                    }
                    break;
                case 2:
                    if (cellTextureFill)
                    {
                        pixels[player][i++].BackgroundImage = Properties.Resources.blue; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackgroundImage = Properties.Resources.blue; pixels[player][i++].BackgroundImage = Properties.Resources.blue;
                        pixels[player][i++].BackgroundImage = Properties.Resources.blue; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    else
                    {
                        pixels[player][i++].BackColor = clrJ; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = clrJ; pixels[player][i++].BackColor = clrJ;
                        pixels[player][i++].BackColor = clrJ; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    break;
                case 3:
                    if (cellTextureFill)
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackgroundImage = Properties.Resources.orange; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackgroundImage = Properties.Resources.orange; pixels[player][i++].BackgroundImage = Properties.Resources.orange;
                        pixels[player][i++].BackgroundImage = Properties.Resources.orange; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    else
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = clrL; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = clrL; pixels[player][i++].BackColor = clrL;
                        pixels[player][i++].BackColor = clrL; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    break;
                case 4:
                    if (cellTextureFill)
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackgroundImage = Properties.Resources.yellow;
                        pixels[player][i++].BackgroundImage = Properties.Resources.yellow; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackgroundImage = Properties.Resources.yellow;
                        pixels[player][i++].BackgroundImage = Properties.Resources.yellow; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    else
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = clrO;
                        pixels[player][i++].BackColor = clrO; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = clrO;
                        pixels[player][i++].BackColor = clrO; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    break;
                case 5:
                    if (cellTextureFill)
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackgroundImage = Properties.Resources.green;
                        pixels[player][i++].BackgroundImage = Properties.Resources.green; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackgroundImage = Properties.Resources.green; pixels[player][i++].BackgroundImage = Properties.Resources.green;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    else
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = clrS;
                        pixels[player][i++].BackColor = clrS; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = clrS; pixels[player][i++].BackColor = clrS;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    break;
                case 6:
                    if (cellTextureFill)
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackgroundImage = Properties.Resources.purple;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackgroundImage = Properties.Resources.purple; pixels[player][i++].BackgroundImage = Properties.Resources.purple;
                        pixels[player][i++].BackgroundImage = Properties.Resources.purple; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    else
                    {
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = clrT;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = clrT; pixels[player][i++].BackColor = clrT;
                        pixels[player][i++].BackColor = clrT; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    break;
                case 7:
                    if (cellTextureFill)
                    {
                        pixels[player][i++].BackgroundImage = Properties.Resources.red; pixels[player][i++].BackgroundImage = Properties.Resources.red;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackgroundImage = Properties.Resources.red;
                        pixels[player][i++].BackgroundImage = Properties.Resources.red; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    else
                    {
                        pixels[player][i++].BackColor = clrZ; pixels[player][i++].BackColor = clrZ;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = Color.Transparent;
                        pixels[player][i++].BackColor = Color.Transparent; pixels[player][i++].BackColor = clrZ;
                        pixels[player][i++].BackColor = clrZ; pixels[player][i++].BackColor = Color.Transparent;
                    }
                    break;
            }
        }
        void ShowScore(int player)
        {
            if (fun) return;
            labelScore[player].Text = "Score: " + score[player].ToString();
            //labelScore[player].Location = new Point(labelScore[player].Location.X + 15, labelScore[player].Location.Y + 15);
        }

        void NewGame()
        {
            gameOver = new bool[plCount];
            score = new int[plCount];
            matrixObj = new Matrix[plCount];
            matrix = new byte[plCount][,];
            figure = new Figure[plCount];
            next = new byte[plCount];
            for (int i = 0; i < plCount; i++)
            {
                matrixObj[i] = new Matrix(rows, cells);
                matrix[i] = matrixObj[i].GetMatrix();
                figure[i] = new Figure(matrix[i]);
                next[i] = GetRandomForm();
                gameTimer[i].Interval = startSpeed;
                ShowNext(i, next[i]);
                ShowScore(i);
            }

            for (int i = 0; i < plCount; i++)
            {
                ShowMatrix(i);
                //ShowScore();
                SpawnFigure(i);
            }

            //Поехали!
            for (int i = 0; i < plCount; i++)
                gameTimer[i].Enabled = true;
            //sp.PlayLooping();
        }

        public void Pause()
        {
            Array.Resize<int>(ref pausedPlayers, 0);
            for (int i = 0; i < plCount; i++)
            {
                if (gameTimer[i].Enabled)
                {
                    Array.Resize<int>(ref pausedPlayers, pausedPlayers.Length + 1);
                    pausedPlayers[pausedPlayers.Length - 1] = i;
                }
                gameTimer[i].Enabled = false;
            }
        }
        public void Resume()
        {
            foreach (int i in pausedPlayers)
            {
                gameTimer[i].Enabled = true;
            }
        }

        public void SinglePlayerMode(bool fun = false)
        {
            this.fun = fun;
            plCount = 1;
            singlePlayer = true;
            MainMenu.Visible = false;
            Font groupBFont = new Font("Segoe Print", 18, FontStyle.Bold);

            pixels = new PictureBox[1][];
            gameTimer = new System.Windows.Forms.Timer[1];
            movingLeftTimer = new System.Windows.Forms.Timer[1];
            movingRightTimer = new System.Windows.Forms.Timer[1];
            labelScore = new Label[1];
            for (int  i = 0; i < pixels.GetLongLength(0); i++)
            {
                pixels[i] = new PictureBox[rows * cells + 8];
                gameTimer[i] = new System.Windows.Forms.Timer()
                {
                    Tag = "timer" + i.ToString(),
                    Interval = startSpeed,
                    Enabled = false
            };
                movingLeftTimer[i] = new System.Windows.Forms.Timer()
                {
                    Tag = "timer" + i.ToString(),
                    Interval = movingSpeed,
                    Enabled = false

                };
                movingRightTimer[i] = new System.Windows.Forms.Timer()
                {
                    Tag = "timer" + i.ToString(),
                    Interval = movingSpeed,
                    Enabled = false
                };
                gameTimer[i].Tick += new EventHandler(GameTimer_Tick);
                movingLeftTimer[i].Tick += new EventHandler(MovingLeftTimer_Tick);
                movingRightTimer[i].Tick += new EventHandler(MovingRightTimer_Tick);
            }

            string groupBText = "Next";
            string labelText = "Score: ";
            Size groupBSize = new Size(200, 114);
            Size labelSize = new Size(101, 43);
            Point point;
            // Создание экрана.
            Panel panel = new Panel()
            {
                Size = new Size(cells * cellSize.Width + cells * cellInterval + cellSize.Width * 2, rows * cellSize.Height + rows * cellInterval + cellSize.Height * 2),
                Location = new Point(interval, interval)
            };    
            this.Controls.Add(panel);
            CreateMainField(pixels[0], panel);
            // Создание GroupBox'а.
            point = new Point(interval + panel.Width + interval * 2, bClose.Location.Y + bClose.Size.Height + interval);
            GroupBox gb;
            gb = CreateGroupBox(groupBText, groupBFont, groupBSize, point);
            CreateNextField(pixels[0], gb);
            // Создание Label'а.
            if (!fun)
            {
                point = new Point(gb.Location.X, gb.Location.Y + gb.Size.Height + interval * 2);
                labelScore[0] = CreateLabel(labelText, groupBFont, labelSize, point);
                point.X = point.X + cells * cellSize.Width + interval;
            }
            //размер формы
            this.ClientSize = new Size(gb.Location.X + gb.Size.Width + interval, panel.Location.Y + panel.Size.Height + interval);
        }
        public void XPlayersMode(byte count)
        {
            if (count < 2) return;

            plCount = count;
            singlePlayer = false;
            int i;
            Font groupBFont = new Font("Segoe Print", 18, FontStyle.Bold);

            bOptions.Visible = false;
            bStatistics.Visible = false;
            bRecords.Visible = false;
            nfbNewGame.Visible = false;

            pixels = new PictureBox[plCount][];
            gameTimer = new System.Windows.Forms.Timer[plCount];
            movingLeftTimer = new System.Windows.Forms.Timer[plCount];
            movingRightTimer = new System.Windows.Forms.Timer[plCount];
            labelScore = new Label[plCount];
            for (i = 0; i < pixels.GetLongLength(0); i++)
            {
                pixels[i] = new PictureBox[rows * cells + 8];
                gameTimer[i] = new System.Windows.Forms.Timer()
                {
                    Tag = "timer" + i.ToString(),
                    Interval = startSpeed,
                    Enabled = false
                };
                movingLeftTimer[i] = new System.Windows.Forms.Timer()
                {
                    Tag = "timer" + i.ToString(),
                    Interval = movingSpeed,
                    Enabled = false

                };
                movingRightTimer[i] = new System.Windows.Forms.Timer()
                {
                    Tag = "timer" + i.ToString(),
                    Interval = movingSpeed,
                    Enabled = false
                };
                gameTimer[i].Tick += new EventHandler(GameTimer_Tick);
                movingLeftTimer[i].Tick += new EventHandler(MovingLeftTimer_Tick);
                movingRightTimer[i].Tick += new EventHandler(MovingRightTimer_Tick);
            }

            string groupBText = "Next";
            string labelText = "Score: ";
            Size groupBSize = new Size(200, 114);
            Size labelSize = new Size(101, 43);
            Point point;
            //создание GroupBox'ов
            point = new Point(interval, MainMenu.Height);
            GroupBox gb;
            for (i = 0; i < plCount; i++)
            {
                gb = CreateGroupBox(groupBText, groupBFont, groupBSize, point);
                CreateNextField(pixels[i], gb);
                point.X = point.X + cells * cellSize.Width + interval;
            }
            //создание Label'ов
            point = new Point(interval, MainMenu.Height + groupBSize.Height);
            for (i = 0; i < plCount; i++)
            {
                labelScore[i] = CreateLabel(labelText, groupBFont, labelSize, point);
                point.X = point.X + cells * cellSize.Width + interval;
            }
            //создание экранов
            point = new Point(interval, MainMenu.Height + groupBSize.Height + interval + labelSize.Height);
            for (i = 0; i < count; i++)
            {
                CreateMainField(pixels[i], point);
                point.X = point.X + cells * cellSize.Width + interval;
            }
            //размер формы
            this.ClientSize = new Size(interval + cells * cellSize.Width * plCount + interval * plCount, MainMenu.Height + groupBSize.Height + interval + rows * cellSize.Height + interval + labelSize.Height);
        }

        GroupBox CreateGroupBox(string text, Font font, Size size, Point loc)
        {
            GroupBox gb = new GroupBox()
            {
                Text = text,
                Font = font,
                BackColor = Color.Transparent,
                Size = size,
                Location = loc
            };
            this.Controls.Add(gb);
            return gb;
        }
        Label CreateLabel(string text, Font font, Size size, Point loc)
        {
            Label lb = new Label()
            {
                Text = text,
                Font = font,
                BackColor = Color.Transparent,
                Location = loc,
                Size = size,
                AutoSize = true
            };
            this.Controls.Add(lb);
            return lb;
        }
        void CreateMainField(PictureBox[] pixs, Point loc)
        {
            Point point = new Point(loc.X, loc.Y);
            PictureBox pixel;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    pixel = new PictureBox()
                    {
                        Size = cellSize,
                        BackColor = clr,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    if (i + j != 0 && j != 0)
                        point = new Point(Controls[Controls.Count - 1].Location.X + cellSize.Width, point.Y);
                    pixel.Location = point;
                    pixs[(i * cells + j)] = pixel;
                    this.Controls.Add(pixs[(i * cells + j)]);
                }
                point = new Point(loc.X, Controls[Controls.Count - 1].Location.Y + cellSize.Height);
            }
        }
        void CreateMainField(PictureBox[] pixs, Panel panel, bool border = true)
        {
            PictureBox pixel;
            Point point = new Point(0, 0);
            if (border)
            {
                for (int i = 0; i < (cells + 2); i++)
                {
                    pixel = new PictureBox()
                    {
                        Size = cellSize,
                        BackgroundImage = Properties.Resources.gray,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    if (i != 0)
                    {
                        point.X += cellSize.Width;
                        point.Y = 0;
                    }
                    pixel.Location = point;
                    panel.Controls.Add(pixel);

                    pixel = new PictureBox()
                    {
                        Size = cellSize,
                        BackgroundImage = Properties.Resources.gray,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    point.Y = (rows + 1) * cellSize.Height;
                    pixel.Location = point;
                    panel.Controls.Add(pixel);
                }
                point = new Point(0, cellSize.Height);
                for (int i = 0; i < rows; i++)
                {
                    pixel = new PictureBox()
                    {
                        Size = cellSize,
                        BackgroundImage = Properties.Resources.gray,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    if (i != 0)
                    {
                        point.X = 0;
                        point.Y += cellSize.Height;
                    }
                    pixel.Location = point;
                    panel.Controls.Add(pixel);

                    pixel = new PictureBox()
                    {
                        Size = cellSize,
                        BackgroundImage = Properties.Resources.gray,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    point.X = (cells + 1) * cellSize.Width;
                    pixel.Location = point;
                    panel.Controls.Add(pixel);
                }
            }
            point = new Point(cellSize.Width, cellSize.Height);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    pixel = new PictureBox()
                    {
                        Size = cellSize,
                        BackColor = clr,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    if (i + j != 0 && j != 0)
                        point = new Point(panel.Controls[panel.Controls.Count - 1].Location.X + cellSize.Width + cellInterval, point.Y);
                    pixel.Location = point;
                    pixs[(i * cells + j)] = pixel;
                    panel.Controls.Add(pixs[(i * cells + j)]);
                }
                if (border)
                    point = new Point(cellSize.Width, panel.Controls[panel.Controls.Count - 1].Location.Y + cellSize.Height + cellInterval);
                else
                    point = new Point(0, panel.Controls[panel.Controls.Count - 1].Location.Y + cellSize.Height + cellInterval);
            }
        }
        void CreateNextField(PictureBox[] pixs, GroupBox gb)
        {
            Point point = new Point(gb.Width / 2 - 50, gb.Height / 2 - 15);
            PictureBox pixel;
            int k = rows * cells;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    pixel = new PictureBox()
                    {
                        Size = cellSize,
                        BackColor = Color.Transparent,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                    if (i + j != 0 && j != 0)
                        point = new Point(gb.Controls[gb.Controls.Count - 1].Location.X + cellSize.Width + cellInterval, point.Y);
                    pixel.Location = point;
                    pixs[k] = pixel;
                    gb.Controls.Add(pixs[k++]);
                }
                point = new Point(gb.Width / 2 - 50, gb.Controls[gb.Controls.Count - 1].Location.Y + cellSize.Height + cellInterval);
            }
        }

        void AnimationMouseDown(Control element, double percent = 0.8)
        {
            if (element == null || percent < 0.1) return;

            elementOriginalSize = new Size(element.Size.Width, element.Size.Height);
            element.Size = new Size((int)(element.Size.Width * percent), (int)(element.Size.Height * percent));
            int widthDifference = elementOriginalSize.Width - element.Size.Width;
            int heightDifference = elementOriginalSize.Height - element.Size.Height;
            element.Location = new Point(element.Location.X + widthDifference / 2, element.Location.Y + heightDifference / 2);
        }
        void AnimationMouseUp(Control element)
        {
            if (element == null) return;

            int widthDifference = elementOriginalSize.Width - element.Size.Width;
            int heightDifference = elementOriginalSize.Height - element.Size.Height;
            element.Size = new Size(elementOriginalSize.Width, elementOriginalSize.Height);
            element.Location = new Point(element.Location.X - widthDifference / 2, element.Location.Y - heightDifference / 2);
        }

        int NewRecord()
        {
            for (int i = 0; i < records.Length; i++)
            {
                if (records[i] < score[0])
                {
                    if (i == records.Length - 1)
                    {
                        records[i] = score[0];
                    }
                    else
                    {
                        for (int j = records.Length - 1; j > i; j--)
                        {
                            records[j] = records[j - 1];
                            recNicks[j] = recNicks[j - 1];
                            recDate[j] = recDate[j - 1];
                        }
                        records[i] = score[0];
                    }
                    return i;
                }
            }
            return -1;
        }
        public void ResetRecords()
        {
            for (int i = 0; i < records.Length; i++)
            {
                records[i] = 0;
                recNicks[i] = "";
                recDate[i] = new DateTime(1, 1, 1, 0, 0, 0);
            }
        }
        public void ResetStatistics()
        {
            for (int i = 0; i < statistics.Length; i++)
            {
                statistics[i] = 0;
            }
        }

        public void GetColors(out Color _clr, out Color _clrI, out Color _clrJ, out Color _clrL, out Color _clrO, out Color _clrS, out Color _clrT, out Color _clrZ)
        {
            _clr = clr;
            _clrI = clrI;
            _clrJ = clrJ;
            _clrL = clrL;
            _clrO = clrO;
            _clrS = clrS;
            _clrT = clrT;
            _clrZ = clrZ;
        }
        public int[] GetRecords()
        {
            //возвращает копию массива рекордов
            int[] temp = new int[10];
            Array.Copy(records, temp, records.Length);
            return temp;
        }
        public string[] GetRecNics()
        {
            //возвращает копию массива ников рекордсменов
            string[] temp = new string[10];
            Array.Copy(recNicks, temp, recNicks.Length);
            return temp;
        }
        public DateTime[] GetRecDate()
        {
            //возвращает копию массива даты установки рекордов
            DateTime[] temp = new DateTime[10];
            Array.Copy(recDate, temp, recNicks.Length);
            return temp;
        }
        public uint[] GetStatistics()
        {
            //возвращает копию массива статистики
            uint[] temp = new uint[7];
            Array.Copy(statistics, temp, statistics.Length);
            return temp;
        }
        public string[][] GetKeys()
        {
            // Возвращает копию массива горячих клавиш.
            string[][] temp = new string[4][];
            Array.Copy(keys, temp, keys.Length);
            return temp;
        }
        public string[] GetKeysSingle()
        {
            string[] temp = new string[4];
            Array.Copy(keysSingle, temp, keysSingle.Length);
            return temp;
        }
        public byte GetPlayersCount()
        {
            return plCount;
        }
        public void SetNewColor(Color _clr, Color _clrI, Color _clrJ, Color _clrL, Color _clrO, Color _clrS, Color _clrT, Color _clrZ)
        {
            clr = _clr;
            clrI = _clrI;
            clrJ = _clrJ;
            clrL = _clrL;
            clrO = _clrO;
            clrS = _clrS;
            clrT = _clrT;
            clrZ = _clrZ;
        }
        public void SetRecNick(int i, string name)
        {
            recNicks[i] = name;
        }
        public void SetRecDate(int i)
        {
            recDate[i] = DateTime.Now;
        }
        public void SetKey(int i, int j, string value)
        {
            if ((value == "Up" || value == "Left" || value == "Down" || value == "Right") ||
                (Char.Parse(value) >= 48 && Char.Parse(value) <= 57) ||
               (Char.Parse(value) >= 65 && Char.Parse(value) <= 90) ||
               (Char.Parse(value) >= 97 && Char.Parse(value) <= 122))
                keys[i][j] = value;
        }
        public void SetKeySingle(int i, string value)
        {
            if ((value == "Up" || value == "Left" || value == "Down" || value == "Right") ||
                (Char.Parse(value) >= 48 && Char.Parse(value) <= 57) ||
               (Char.Parse(value) >= 65 && Char.Parse(value) <= 90) ||
               (Char.Parse(value) >= 97 && Char.Parse(value) <= 122))
                keysSingle[i] = value;
        }
        public void DefaultKeys()
        {
            keys[0][0] = "W";
            keys[0][1] = "A";
            keys[0][2] = "S";
            keys[0][3] = "D";

            keys[1][0] = "T";
            keys[1][1] = "F";
            keys[1][2] = "G";
            keys[1][3] = "H";

            keys[2][0] = "I";
            keys[2][1] = "J";
            keys[2][2] = "K";
            keys[2][3] = "L";

            keys[3][0] = "Up";
            keys[3][1] = "Left";
            keys[3][2] = "Down";
            keys[3][3] = "Right";
        }

        bool IsPlayerGameOver(int player)
        {
            figure[player].GetBone(out byte x1, out byte x2, out byte x3, out byte x4, out byte y1, out byte y2, out byte y3, out byte y4);

            if (matrix[player][x1, y1] != 0 || matrix[player][x2, y2] != 0 || matrix[player][x3, y3] != 0 || matrix[player][x4, y4] != 0)
                return true;
            else
                return false;
        }
        void PlayerStopGame(int player)
        {
            gameOver[player] = true;
            gameTimer[player].Enabled = false;
            if (plCount == 1)
            {
                int newRecord;
                newRecord = NewRecord();
                //MessageBox.Show(message, "Tetris");
                if (newRecord >= 0)
                {
                    this.Enabled = false;
                    MessageBox.Show("New Record!", "Tetris");
                    enterNick = new FNickEnter(this, newRecord);
                    enterNick.Show(this);
                }
                else
                {
                    if (fun)
                        MessageBox.Show("Game Over!", "Tetris", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show("Game Over!\nYour score: " + score[player].ToString(), "Tetris", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            //мультиплеер
            else
            {
                int i;
                byte countSurvivors = 0;
                for (i = 0; i < plCount; i++)
                {
                    if (gameOver[i] == false)
                    {
                        countSurvivors++;
                    }
                }
                if (countSurvivors == 1)
                {
                    for (i = 0; i < plCount; i++)
                    {
                        if (gameOver[i] == false)
                        {
                            gameOver[i] = true;
                            gameTimer[i].Enabled = false;
                            MessageBox.Show("Player " + (i+1).ToString() + " win!", "Tetris");
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        #region События Формы
        private void FTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver == null) return;
            byte countSurvivors = 0;
            for (int i = 0; i < plCount; i++)
            {
                if (gameOver[i] == false)
                    countSurvivors++;
            }
            if (!((plCount == 1 && countSurvivors == 1) || (plCount >= 2 && countSurvivors >= 2)))
            {
                return;
            }
            if (singlePlayer)
            {
                if (movingLeftTimer[0].Enabled && movingRightTimer[0].Enabled) return;
                if (keysSingle[0] == e.KeyData.ToString()) FigureTurn(0);
                else if (keysSingle[1] == e.KeyData.ToString())
                {
                    movingLeftTimer[0].Start();
                    FigureLeft(0);
                }
                else if (keysSingle[2] == e.KeyData.ToString()) FigureIncSpeed(0);
                else if (keysSingle[3] == e.KeyData.ToString())
                {
                    movingRightTimer[0].Start();
                    FigureRight(0);
                }
            }
            else
            {
                for (int i = 0; i < plCount; i++)
                {
                    if (keys[i][0] == e.KeyData.ToString())
                    {
                        FigureTurn(i);
                    }
                    else if (keys[i][1] == e.KeyData.ToString())
                    {
                        //movingLeftTimer[i].Start();
                        FigureLeft(i);
                    }
                    else if (keys[i][2] == e.KeyData.ToString())
                    {
                        FigureIncSpeed(i);
                    }
                    else if (keys[i][3] == e.KeyData.ToString())
                    {
                        //movingRightTimer[i].Start();
                        FigureRight(i);
                    }
                }
            }
        }
        private void FTetris_KeyUp(object sender, KeyEventArgs e)
        {
            if (singlePlayer)
            {
                if (keysSingle[1] == e.KeyData.ToString())
                    movingLeftTimer[0].Stop();
                //movingLeftTimer[0].Enabled = false;
                else if (keysSingle[3] == e.KeyData.ToString())
                    movingRightTimer[0].Stop();
                    //movingRightTimer[0].Enabled = false;
                else if (keysSingle[2] == e.KeyData.ToString())
                    FigureDecSpeed(0);
            }
            else
            {
                for (int i = 0; i < plCount; i++)
                {
                    if (keys[i][1] == e.KeyData.ToString())
                        movingLeftTimer[i].Stop();
                    if (keys[i][2] == e.KeyData.ToString())
                        FigureDecSpeed(i);
                    else if (keys[i][3] == e.KeyData.ToString())
                        movingRightTimer[i].Stop();
                }
            }
        }

        private void FTetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteColors();
            WriteRecords();
            WriteStatistics();
            WriteKeys();
            WriteKeysSingle();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            int player = 0;
            try
            {
                string name = ((System.Windows.Forms.Timer)sender).Tag.ToString();
                player = Int32.Parse(name.Substring(5));
            }
            catch
            {
                MessageBox.Show("Критическая ошибка!\nПожалуйста, закройте приложение или обратитесь к разработчику", "Ошибка");
                Application.Exit();
            }

            try
            {
                figure[player].Down();
                ShowMatrix(player);
            }
            catch
            {
                int count;
                count = matrixObj[player].DestructedCount();
                if (count > 0 && !fun)
                {
                    string oldScore = score[player].ToString();
                    if (Int32.Parse(oldScore[oldScore.Length - 1].ToString()) + count >= 10)
                    {
                        labelScore[player].Text += "\nInc";
                        PlayerIncreaseSpeed(player);
                    }
                    score[player] += count;
                    ShowScore(player);
                }
                ShowMatrix(player);
                SpawnFigure(player);
            }
        }
        private void MovingLeftTimer_Tick(object sender, EventArgs e)
        {
            int player = 0;
            try
            {
                string name = ((System.Windows.Forms.Timer)sender).Tag.ToString();
                player = Int32.Parse(name.Substring(5));
            }
            catch
            {
                MessageBox.Show("Критическая ошибка!\nПожалуйста, закройте приложение или обратитесь к разработчику", "Ошибка");
                Application.Exit();
            }

            FigureLeft(0);
            //figure[player].Left();
        }
        private void MovingRightTimer_Tick(object sender, EventArgs e)
        {
            int player = 0;
            try
            {
                string name = ((System.Windows.Forms.Timer)sender).Tag.ToString();
                player = Int32.Parse(name.Substring(5));
            }
            catch
            {
                MessageBox.Show("Критическая ошибка!\nПожалуйста, закройте приложение или обратитесь к разработчику", "Ошибка");
                Application.Exit();
            }
            FigureRight(0);
            //figure[player].Right();
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button element = sender as Button;
            if (element == null) return;
            AnimationMouseDown(element);
        }
        private void bButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button element = sender as Button;
            if (element == null) return;
            AnimationMouseUp(element);
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            if (pausedPlayers.Length > 0)
            {
                this.Enabled = false;
                MethodToConfirm mtc = new MethodToConfirm(NewGame);
                confirm = new FConfirm(this, mtc, "Начать новую игру?\nТекущая игра будет завершена\nбез сохранения результатов");
                confirm.Show(this);
            }
            else
            {
                NewGame();
            }
        }
        private void таблицаРекордовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            recForm = new FRecords(this);
            this.Enabled = false;
            recForm.Show(this);
        }
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            statForm = new StatisticsForm(statistics, this);
            this.Enabled = false;
            statForm.Show(this);
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nfbNewGame_Click(object sender, EventArgs e)
        {
            Pause();
            if (pausedPlayers.Length > 0)
            {
                this.Enabled = false;
                MethodToConfirm mtc = new MethodToConfirm(NewGame);
                confirm = new FConfirm(this, mtc, "Начать новую игру?\nТекущая игра будет завершена\nбез сохранения результатов");
                confirm.Show(this);
            }
            else
            {
                NewGame();
            }
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cd = new ColorDialog();
            cd.Color = this.BackColor;
            cd.FullOpen = true;
            cd.ShowDialog();
            this.BackColor = cd.Color;
            this.BackgroundImage = null;
        }
        private void цветаФигурокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            fc = new FiguresColorsForm(this);
            fc.Show(this);
            this.Enabled = false;
        }
        private void горячиеКлавишиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pause();
            hotKeys = new HotKeysForm(this);
            hotKeys.Show(this);
        }

        private void bOptions_Click(object sender, EventArgs e)
        {
            Pause();
            settingsForm.Show();
            this.Enabled = false;
        }
        private void bStatistics_Click(object sender, EventArgs e)
        {
            Pause();
            statForm = new StatisticsForm(statistics, this);
            this.Enabled = false;
            statForm.Show(this);
        }
        private void bRecords_Click(object sender, EventArgs e)
        {
            Pause();
            recForm = new FRecords(this);
            this.Enabled = false;
            recForm.Show(this);
        }
        #endregion

        private void FTetris_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }

    
}