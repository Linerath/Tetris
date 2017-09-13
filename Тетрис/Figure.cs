using System;

namespace Тетрис
{
    class Figure
    {
        protected byte x1, x2, x3, x4, y1, y2, y3, y4; //координаты фигуры на матрице
        protected byte form; //вид фигуры. 1 - I, 2 - J, 3 - L, 4 - O, 5 - S, 6 - T, 7 - Z
        protected byte subform; //подвид фигуры
        protected byte[,] matrix;

        public Figure(byte[,] m)
        {
            matrix = m;
            subform = 1;
        }

        public void OnMatrix()
        {
            matrix[x1, y1] = form; matrix[x2, y2] = form;
            matrix[x3, y3] = form; matrix[x4, y4] = form;
        }

        public void Down()
        {
            matrix[x1, y1] = 0; matrix[x2, y2] = 0;
            matrix[x3, y3] = 0; matrix[x4, y4] = 0;

            //если внизу блок
            if ((x1 == 19 || x2 == 19 || x3 == 19 || x4 == 19) ||
                ((!(((matrix[x1 + 1, y1] == form) && (x1 + 1 == x2 && x1 + 1 == x3 && x1 + 1 == x4)) ||
                ((matrix[x2 + 1, y2] == form) && (x2 + 1 == x1 && x2 + 1 == x3 && x2 + 1 == x4)) ||
                ((matrix[x3 + 1, y3] == form) && (x3 + 1 == x1 && x3 + 1 == x2 && x3 + 1 == x4)) ||
                ((matrix[x4 + 1, y4] == form) && (x4 + 1 == x1 && x4 + 1 == x2 && x4 + 1 == x3)))) &&
                (matrix[x1 + 1, y1] != 0 || matrix[x2 + 1, y2] != 0 || matrix[x3 + 1, y3] != 0 || matrix[x4 + 1, y4] != 0)))
            {
                OnMatrix();
                throw new IndexOutOfRangeException();
            }
            else
            {
                x1++; x2++; x3++; x4++;
                OnMatrix();
            }
        }

        public void Left()
        {
            matrix[x1, y1] = 0; matrix[x2, y2] = 0;
            matrix[x3, y3] = 0; matrix[x4, y4] = 0;

            //если слева блок
            if ((y1 == 0 || y2 == 0 || y3 == 0 || y4 == 0) ||
                ((!(((matrix[x1, y1 - 1] == form) && (y1 - 1 == y2 && y1 - 1 == y3 && y1 - 1 == y4)) ||
                ((matrix[x2, y2 - 1] == form) && (y2 - 1 == y1 && y2 - 1 == y3 && y2 - 1 == y4)) ||
                ((matrix[x3, y3 - 1] == form) && (y3 - 1 == y1 && y3 - 1 == y2 && y3 - 1 == y4)) ||
                ((matrix[x4, y4 - 1] == form) && (y4 - 1 == y1 && y4 - 1 == y2 && y4 - 1 == y3)))) &&
                (matrix[x1, y1 - 1] != 0 || matrix[x2, y2 - 1] != 0 || matrix[x3, y3 - 1] != 0 || matrix[x4, y4 - 1] != 0)))
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                y1--; y2--; y3--; y4--;
                OnMatrix();
            }
        }

        public void Right()
        {
            matrix[x1, y1] = 0; matrix[x2, y2] = 0;
            matrix[x3, y3] = 0; matrix[x4, y4] = 0;

            //если справа блок
            if ((y1 == 9 || y2 == 9 || y3 == 9 || y4 == 9) ||
                ((!(((matrix[x1, y1 + 1] == form) && (y1 + 1 == y2 && y1 + 1 == y3 && y1 + 1 == y4)) ||
                ((matrix[x2, y2 + 1] == form) && (y2 + 1 == y1 && y2 + 1 == y3 && y2 + 1 == y4)) ||
                ((matrix[x3, y3 + 1] == form) && (y3 + 1 == y1 && y3 + 1 == y2 && y3 + 1 == y4)) ||
                ((matrix[x4, y4 + 1] == form) && (y4 + 1 == y1 && y4 + 1 == y2 && y4 + 1 == y3)))) &&
                (matrix[x1, y1 + 1] != 0 || matrix[x2, y2 + 1] != 0 || matrix[x3, y3 + 1] != 0 || matrix[x4, y4 + 1] != 0)))
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                y1++; y2++; y3++; y4++;
                OnMatrix();
            }
        }

        public void Turn()
        {
            // Ужасно. Захардкодил. Писалось очень давно, переделывать заново очень долго)
            byte X1, X2, X3, X4, Y1, Y2, Y3, Y4;
            X1 = x1; X2 = x2; X3 = x3; X4 = x4;
            Y1 = y1; Y2 = y2; Y3 = y3; Y4 = y4;

            matrix[x1, y1] = 0; matrix[x2, y2] = 0;
            matrix[x3, y3] = 0; matrix[x4, y4] = 0;

            switch (form)
            {
                case 1:
                    switch (subform)
                    {
                        case 1:
                            try
                            {
                                if (matrix[x1 - 1, y1 + 1] == 0 && matrix[x3 + 1, y3 - 1] == 0 && matrix[x4 + 2, y4 - 2] == 0)
                                {
                                    x1--; x3++; x4 += 2;
                                    y1++; y3--; y4 -= 2;
                                    subform = 2;
                                }
                                else
                                {
                                    matrix[x1, y1] = 1; matrix[x2, y2] = 1;
                                    matrix[x3, y3] = 1; matrix[x4, y4] = 1;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 1; matrix[x2, y2] = 1;
                                matrix[x3, y3] = 1; matrix[x4, y4] = 1;
                            }
                            break;
                        case 2:
                            try
                            {
                                if (matrix[x1 + 1, y1 - 1] == 0 && matrix[x3 - 1, y3 + 1] == 0 && matrix[x4 - 2, y4 + 2] == 0)
                                {
                                    x1++; x3--; x4 -= 2;
                                    y1--; y3++; y4 += 2;
                                    subform = 1;
                                }
                                else if (matrix[x2, y2 + 1] == 0 && matrix[x3 - 1, y3 + 2] == 0 && matrix[x4 - 2, y4 + 3] == 0)
                                {
                                    y1++; y2++; y3++; y4++;
                                    x1++; x3--; x4 -= 2;
                                    y1--; y3++; y4 += 2;
                                    subform = 1;
                                }
                                else if (matrix[x1 + 1, y1 - 3] == 0 && matrix[x2, y2 - 2] == 0 && matrix[x3 - 1, y3 - 1] == 0)
                                {
                                    x1++; x3--; x4 -= 2;
                                    y1 -= 3; y2 -= 2; y3--;
                                    subform = 1;
                                }
                                else
                                {
                                    matrix[x1, y1] = 1; matrix[x2, y2] = 1;
                                    matrix[x3, y3] = 1; matrix[x4, y4] = 1;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x2, y2+1]==0 && matrix[x3-1, y3+2]== 0 && matrix[x4-2, y4+3] == 0)
                                    {
                                        y1++; y2++; y3++; y4++;
                                        x1++; x3--; x4 -= 2;
                                        y1--; y3++; y4 += 2;
                                        subform = 1;
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        if (y1<9 && matrix[x1, y1+1] ==0 && matrix[x2, y2 + 1] == 0 && matrix[x3, y3 + 1] == 0 && matrix[x4, y4 + 1] == 0)
                                        {
                                            y1++; y2++; y3++; y4++;
                                        }
                                        if (matrix[x1 + 1, y1 - 3] == 0 && matrix[x2, y2 - 2] == 0 && matrix[x3 - 1, y3 - 1] == 0)
                                        {
                                            x1++; x3--; x4 -= 2;
                                            y1 -= 3; y2 -= 2; y3--;
                                            subform = 1;
                                        }
                                    }
                                    catch
                                    {
                                        matrix[x1, y1] = 1; matrix[x2, y2] = 1;
                                        matrix[x3, y3] = 1; matrix[x4, y4] = 1;
                                    }
                                }
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (subform)
                    {
                        case 1:
                            try
                            {
                                if (matrix[x1 - 1, y1 + 1] == 0 && matrix[x2 - 2, y2] == 0 && matrix[x3 - 1, y3 - 1] == 0 && matrix[x4, y4 - 2] == 0)
                                {
                                    x1--; x2 -= 2; x3--;
                                    y1++; y3--; y4 -= 2;
                                    subform = 2;
                                }
                                else
                                {
                                    matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                    matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                            }
                            break;
                        case 2:
                            try
                            {
                                if (matrix[x1 + 1, y1 + 1] == 0 && matrix[x2, y2 + 2] == 0 && matrix[x3 - 1, y3 + 1] == 0 && matrix[x4 - 2, y4] == 0)
                                {
                                    x1++; x3--; x4 -= 2;
                                    y1++; y2 += 2; y3++;
                                    subform = 3;
                                }
                                else if (matrix[x1 + 1, y1] == 0 && matrix[x4 - 2, y4 - 1] == 0)
                                {
                                    y1--; y2--; y3--; y4--;
                                    x1++; x3--; x4 -= 2;
                                    y1++; y2 += 2; y3++;
                                    subform = 3;
                                }
                                else
                                {
                                    matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                    matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x1+1, y1]==0 && matrix[x4-2, y4-1]==0)
                                    {
                                        y1--; y2--; y3--; y4--;
                                        x1++; x3--; x4 -= 2;
                                        y1++; y2 += 2; y3++;
                                        subform = 3;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                    matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                                }
                            }
                            break;
                        case 3:
                            try
                            {
                                if (matrix[x1 + 1, y1 - 1] == 0 && matrix[x2 + 2, y2] == 0 && matrix[x3 + 1, y3 + 1] == 0 && matrix[x4, y4 + 2] == 0)
                                {
                                    x1++; x2 += 2; x3++;
                                    y1--; y3++; y4 += 2;
                                    subform = 4;
                                }
                                else
                                {
                                    matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                    matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                            }
                            break;
                        case 4:
                            try
                            {
                                if (matrix[x1 - 1, y1 - 1] == 0 && matrix[x2, y2 - 2] == 0 && matrix[x3 + 1, y3 - 1] == 0 && matrix[x4 + 2, y4] == 0)
                                {
                                    x1--; x3++; x4 += 2;
                                    y1--; y2 -= 2; y3--;
                                    subform = 1;
                                }
                                else if (matrix[x1 - 1, y1] == 0 && matrix[x4 + 2, y4 + 1] == 0)
                                {
                                    y1++; y2++; y3++; y4++;
                                    x1--; x3++; x4 += 2;
                                    y1--; y2 -= 2; y3--;
                                    subform = 1;
                                }
                                else
                                {
                                    matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                    matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x1-1, y1]==0 && matrix[x4+2, y4+1]==0)
                                    {
                                        y1++; y2++; y3++; y4++;
                                        x1--; x3++; x4 += 2;
                                        y1--; y2 -= 2; y3--;
                                        subform = 1;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 2; matrix[x2, y2] = 2;
                                    matrix[x3, y3] = 2; matrix[x4, y4] = 2;
                                }
                            }
                            break;

                    }
                    break;
                case 3:
                    switch (subform)
                    {
                        case 1:
                            try
                            {
                                if (matrix[x1 + 1, y1 - 1] == 0 && matrix[x2 - 2, y2] == 0 && matrix[x3 - 1, y3 - 1] == 0 && matrix[x4, y4 - 2] == 0)
                                {
                                    x1++; x2 -= 2; x3--;
                                    y1--; y3--; y4 -= 2;
                                    subform = 2;
                                }
                                else
                                {
                                    matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                    matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                                }
                            }
                            catch
                            {
                                
                                matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                            }
                            break;
                        case 2:
                            try
                            {
                                if (matrix[x1 - 1, y1 - 1] == 0 && matrix[x2, y2 + 2] == 0 && matrix[x3 - 1, y3 + 1] == 0 && matrix[x4 - 2, y4] == 0)
                                {
                                    x1--; x3--; x4 -= 2;
                                    y1--; y2 += 2; y3++;
                                    subform = 3;
                                }
                                else if (matrix[x1, y1 - 2] == 0 && matrix[x2 + 1, y2 + 1] == 0 && matrix[x4, y4 - 1] == 0)
                                {
                                    y1--; y2--; y3--; y4--;
                                    x1--; x3--; x4 -= 2;
                                    y1--; y2 += 2; y3++;
                                    subform = 3;
                                }
                                else
                                {
                                    matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                    matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x1, y1 - 2] == 0 && matrix[x2 + 1, y2 + 1] == 0 && matrix[x4, y4 - 1] == 0)
                                    {
                                        y1--; y2--; y3--; y4--;
                                        x1--; x3--; x4 -= 2;
                                        y1--; y2 += 2; y3++;
                                        subform = 3;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                    matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                                }
                            }
                            break;
                        case 3:
                            try
                            {
                                if (matrix[x1 - 1, y1 + 1] == 0 && matrix[x2 + 2, y2] == 0 && matrix[x3 + 1, y3 + 1] == 0 && matrix[x4, y4 + 2] == 0)
                                {
                                    x1--; x2 += 2; x3++;
                                    y1++; y3++; y4 += 2;
                                    subform = 4;
                                }
                                else
                                {
                                    matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                    matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                            }
                            break;
                        case 4:
                            try
                            {
                                if (matrix[x1 + 1, y1 + 1] == 0 && matrix[x2, y2 - 2] == 0 && matrix[x3 + 1, y3 - 1] == 0 && matrix[x4 + 2, y4] == 0)
                                {
                                    x1++; x3++; x4 += 2;
                                    y1++; y2 -= 2; y3--;
                                    subform = 1;
                                }
                                else if (matrix[x1 + 1, y1 + 2] == 0 && matrix[x2, y2 - 1] == 0 && matrix[x4 + 2, y4 + 1] == 0)
                                {
                                    y1++; y2++; y3++; y4++;
                                    x1++; x3++; x4 += 2;
                                    y1++; y2 -= 2; y3--;
                                    subform = 1;
                                }
                                else
                                {
                                    matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                    matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x1+1, y1+2] == 0 && matrix[x2, y2-1] == 0 && matrix[x4+2, y4+1] == 0)
                                    {
                                        y1++; y2++; y3++; y4++;
                                        x1++; x3++; x4 += 2;
                                        y1++; y2 -= 2; y3--;
                                        subform = 1;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 3; matrix[x2, y2] = 3;
                                    matrix[x3, y3] = 3; matrix[x4, y4] = 3;
                                }
                            }
                            break;
                    }
                    break;
                case 4:
                    break;
                case 5:
                    switch (subform)
                    {
                        case 1:
                            try
                            {
                                if (matrix[x2 - 1, y2 - 1] == 0 && matrix[x3, y3 + 2] == 0 && matrix[x4 - 1, y4 + 1] == 0)
                                {
                                    x2--; x4--;
                                    y2--; y3 += 2; y4++;
                                    subform = 2;
                                }
                                else
                                {
                                    matrix[x1, y1] = 5; matrix[x2, y2] = 5;
                                    matrix[x3, y3] = 5; matrix[x4, y4] = 5;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 5; matrix[x2, y2] = 5;
                                matrix[x3, y3] = 5; matrix[x4, y4] = 5;
                            }
                            break;
                        case 2:
                            try
                            {
                                if (matrix[x2 + 1, y2 + 1] == 0 && matrix[x3, y3 - 2] == 0 && matrix[x4 + 1, y4 - 1] == 0)
                                {
                                    x2++; x4++;
                                    y2++; y3 -= 2; y4--;
                                    subform = 1;
                                }
                                else if (matrix[x3 + 1, y3 - 1] == 0 && matrix[x2 + 1, y2 + 2] == 0)
                                {
                                    y1++; y2++; y3++; y4++;
                                    x2++; x4++;
                                    y2++; y3 -= 2; y4--;
                                    subform = 1;
                                }
                                else
                                {
                                    matrix[x1, y1] = 5; matrix[x2, y2] = 5;
                                    matrix[x3, y3] = 5; matrix[x4, y4] = 5;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x3+1, y3-1]==0 && matrix[x2+1, y2+2]==0)
                                    {
                                        y1++; y2++; y3++; y4++;
                                        x2++; x4++;
                                        y2++; y3 -= 2; y4--;
                                        subform = 1;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 5; matrix[x2, y2] = 5;
                                    matrix[x3, y3] = 5; matrix[x4, y4] = 5;
                                }
                            }
                            break;
                    }
                    break;
                case 6:
                    switch (subform)
                    {
                        case 1:
                            try
                            {
                                if (matrix[x2 - 2, y2] == 0 && matrix[x3 - 1, y3 - 1] == 0 && matrix[x4, y4 - 2] == 0)
                                {
                                    x2 -= 2; x3--;
                                    y3--; y4 -= 2;
                                    subform = 2;
                                }
                                else
                                {
                                    matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                    matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                            }                            
                            break;
                        case 2:
                            try
                            {
                                if (matrix[x2, y2 + 2] == 0 && matrix[x3 - 1, y3 + 1] == 0 && matrix[x4 - 2, y4] == 0)
                                {
                                    x3--; x4 -= 2;
                                    y2 += 2; y3++;
                                    subform = 3;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x2, y2+1]==0 && matrix[x4-2, y4-1]==0)
                                    {
                                        y1--; y2--; y3--; y4--;
                                        x3--; x4 -= 2;
                                        y2 += 2; y3++;
                                        subform = 3;
                                    }
                                    else
                                    {
                                        matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                        matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                    matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                                }
                            }
                            break;
                        case 3:
                            try
                            {
                                if (matrix[x2 + 2, y2] == 0 && matrix[x3 + 1, y3 + 1] == 0 && matrix[x4, y4 + 2] == 0)
                                {
                                    x2 += 2; x3++;
                                    y3++; y4 += 2;
                                    subform = 4;
                                }
                                else
                                {
                                    matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                    matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                            }                            
                            break;
                        case 4:
                            try
                            {
                                if (matrix[x2, y2 - 2] == 0 && matrix[x3 + 1, y3 - 1] == 0 && matrix[x4 + 2, y4] == 0)
                                {
                                    x3++; x4 += 2;
                                    y2 -= 2; y3--;
                                    subform = 1;
                                }
                                else if (matrix[x2, y2 - 1] == 0 && matrix[x4 + 2, y4 + 1] == 0)
                                {
                                    y1++; y2++; y3++; y4++;
                                    x3++; x4 += 2;
                                    y2 -= 2; y3--;
                                    subform = 1;
                                }
                                else
                                {
                                    matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                    matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x2, y2-1]==0 && matrix[x4+2, y4+1]==0)
                                    {
                                        y1++; y2++; y3++; y4++;
                                        x3++; x4 += 2;
                                        y2 -= 2; y3--;
                                        subform = 1;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 6; matrix[x2, y2] = 6;
                                    matrix[x3, y3] = 6; matrix[x4, y4] = 6;
                                }
                            }
                            break;
                    }
                    break;
                case 7:
                    switch (subform)
                    {
                        case 1:
                            try
                            {
                                if (matrix[x1 - 1, y1 + 1] == 0 && matrix[x3 - 1, y3 - 1] == 0 && matrix[x4, y4 - 2] == 0)
                                {
                                    x1--; x3--;
                                    y1++; y3--; y4 -= 2;
                                    subform = 2;
                                }
                                else
                                {
                                    matrix[x1, y1] = 7; matrix[x2, y2] = 7;
                                    matrix[x3, y3] = 7; matrix[x4, y4] = 7;
                                }
                            }
                            catch
                            {
                                matrix[x1, y1] = 7; matrix[x2, y2] = 7;
                                matrix[x3, y3] = 7; matrix[x4, y4] = 7;
                            }
                            break;
                        case 2:
                            try
                            {
                                if (matrix[x1 + 1, y1 - 1] == 0 && matrix[x3 + 1, y3 + 1] == 0 && matrix[x4, y4 + 2] == 0)
                                {
                                    x1++; x3++;
                                    y1--; y3++; y4 += 2;
                                    subform = 1;
                                }
                                else if (matrix[x1 + 1, y1 - 2] == 0 && matrix[x4, y4 + 1] == 0)
                                {
                                    y1--; y2--; y3--; y4--;
                                    x1++; x3++;
                                    y1--; y3++; y4 += 2;
                                    subform = 1;
                                }
                                else
                                {
                                    matrix[x1, y1] = 7; matrix[x2, y2] = 7;
                                    matrix[x3, y3] = 7; matrix[x4, y4] = 7;
                                }
                            }
                            catch
                            {
                                try
                                {
                                    if (matrix[x1 + 1, y1 - 2] == 0 && matrix[x4, y4 + 1] == 0)
                                    {
                                        y1--; y2--; y3--; y4--;
                                        x1++; x3++;
                                        y1--; y3++; y4 += 2;
                                        subform = 1;
                                    }
                                }
                                catch
                                {
                                    matrix[x1, y1] = 7; matrix[x2, y2] = 7;
                                    matrix[x3, y3] = 7; matrix[x4, y4] = 7;
                                }
                            }
                            break;
                    }
                    break;
            }

            try
            {
                OnMatrix();
            }
            catch
            {
                try
                {
                    matrix[x1, y1] = 0; matrix[x2, y2] = 0;
                    matrix[x3, y3] = 0; matrix[x4, y4] = 0;
                }
                catch { }
                //MessageBox.Show(exp.Message);
                if (subform == 1)
                {
                    if (form == 1 || form == 5 || form == 7)
                        subform = 2;
                    else
                        subform = 4;
                }
                else
                    subform--;
                x1 = X1; x2 = X2; x3 = X3; x4 = X4;
                y1 = Y1; y2 = Y2; y3 = Y3; y4 = Y4;
                OnMatrix();
            }
        }

        public void GetBone(out byte X1, out byte X2, out byte X3, out byte X4, out byte Y1, out byte Y2, out byte Y3, out byte Y4)
        {
            X1 = x1; X2 = x2; X3 = x3; X4 = x4;
            Y1 = y1; Y2 = y2; Y3 = y3; Y4 = y4;
        }
    }

    class Fig_I : Figure
    {
        public Fig_I(byte[,] matrix)
            : base(matrix)
        {
            form = 1;

            x1 = 0; y1 = 3;
            x2 = 0; y2 = 4;
            x3 = 0; y3 = 5;
            x4 = 0; y4 = 6;
        }
    }

    class Fig_J : Figure
    {
        public Fig_J(byte[,] matrix)
            : base(matrix)
        {
            form = 2;

            x1 = 0; y1 = 3;
            x2 = 1; y2 = 3;
            x3 = 1; y3 = 4;
            x4 = 1; y4 = 5;
        }
    }

    class Fig_L : Figure
    {
        public Fig_L(byte[,] matrix)
            : base(matrix)
        {
            form = 3;

            x1 = 0; y1 = 5;
            x2 = 1; y2 = 3;
            x3 = 1; y3 = 4;
            x4 = 1; y4 = 5;
        }
    }

    class Fig_O : Figure
    {
        public Fig_O(byte[,] matrix)
            : base(matrix)
        {
            form = 4;

            x1 = 0; y1 = 4;
            x2 = 0; y2 = 5;
            x3 = 1; y3 = 4;
            x4 = 1; y4 = 5;
        }
    }

    class Fig_S : Figure
    {
        public Fig_S(byte[,] matrix)
            : base(matrix)
        {
            form = 5;

            x1 = 0; y1 = 4;
            x2 = 0; y2 = 5;
            x3 = 1; y3 = 3;
            x4 = 1; y4 = 4;
        }
    }

    class Fig_T : Figure
    {
        public Fig_T(byte[,] matrix)
            : base(matrix)
        {
            form = 6;

            x1 = 0; y1 = 4;
            x2 = 1; y2 = 3;
            x3 = 1; y3 = 4;
            x4 = 1; y4 = 5;
        }
    }

    class Fig_Z : Figure
    {
        public Fig_Z(byte[,] matrix)
            : base(matrix)
        {
            form = 7;

            x1 = 0; y1 = 3;
            x2 = 0; y2 = 4;
            x3 = 1; y3 = 4;
            x4 = 1; y4 = 5;
        }
    }
}