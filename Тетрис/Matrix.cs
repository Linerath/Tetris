namespace Тетрис
{
    class Matrix
    {
        protected byte[,] matrix;
        int rows, cells;

        public Matrix(int _rows, int _cells)
        {
            rows = _rows;
            cells = _cells;
            matrix = new byte[rows, cells];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public byte[,] GetMatrix()
        {
            //byte[,] temp = new byte[rows, cells];
            //Array.Copy(matrix, temp, matrix.Length);
            //return temp;
            return matrix;
        }

        void MatrixDown(int line)
        {
            for (int i = line; i >= 0; i--)
            {
                for (int j = cells - 1; j >= 0; j--)
                {
                    if (i != 0)
                        matrix[i, j] = matrix[i - 1, j];
                }
            }
        }

        void DestroyLine(int line)
        {
            for (int i = 0; i < cells; i++)
                matrix[line, i] = 0;
            MatrixDown(line);
        }

        public byte DestructedCount()
        {
            int i, j;
            bool flag = false;
            byte count = 0;
            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < cells; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    DestroyLine(i);
                    count++;
                }
                flag = false;
            }
            return count;
        }
    }
}