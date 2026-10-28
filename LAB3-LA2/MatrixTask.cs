using System;

namespace LabWork
{
    class MatrixTask
    {
        private int[,] _matrix;
        public static int InstanceCount;

        static MatrixTask()
        {
            InstanceCount = 0;
        }

        public static int CreatedCount
        {
            get { return InstanceCount; }
        }

        public int[,] Matrix
        {
            get { return _matrix; }
        }

        // 1: Заполнение двумерных массивов

        public MatrixTask(int n, int m)
        {
            InstanceCount++;
            _matrix = new int[n, m];

            Console.WriteLine($"Введите {n * m} чисел для " +
                $"матрицы {n}x{m} (по столбцам снизу вверх):");

            for (int j = 0; j < m; j++)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    int value;
                    bool isCorrect = false;
                    while (!isCorrect)
                    {
                        Console.Write($"Элемент [{i},{j}]: ");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out value))
                        {
                            _matrix[i, j] = value;
                            isCorrect = true;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! " +
                                "Введите целое число.");
                        }
                    }
                }
            }
        }

        public MatrixTask(int n, bool isRandom)
        {
            InstanceCount++;
            _matrix = new int[n, n];
            Random rnd = new Random();

            for (int j = 0; j < n; j++)
            {
                int current = rnd.Next(1, 10);
                for (int i = 0; i < n; i++)
                {
                    _matrix[i, j] = current;
                    current += rnd.Next(1, 5);
                }
            }
        }

        public MatrixTask(int n)
        {
            InstanceCount++;
            _matrix = new int[n, n];
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23,
                29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
                73, 79, 83, 89, 97 };

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (k < primes.Length)
                    {
                        _matrix[i, j] = primes[k++];
                    }
                }
            }
        }

        // 2: Средняя оценка > 4.5
        public static void FindExcellentStudents(int[,] grades)
        {
            int n = grades.GetLength(0);
            int m = grades.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Школьник {i + 1}: оценки ");
                for (int j = 0; j < m; j++)
                {
                    Console.Write(grades[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write("\nШкольники со " +
                "средним баллом > 4.5: ");

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += grades[i, j];
                }

                double avg = sum / m;

                if (avg > 4.5)
                {
                    Console.Write($"{i + 1} ({avg:F2}) ");
                }
            }
            Console.WriteLine();
        }

        // 3: A^T - B^T + 2*C
        public static void CalculateMatrixExpression()
        {
            int[,] A = { { 1, 2 }, { 3, 4 } };
            int[,] B = { { 5, 6 }, { 7, 8 } };
            int[,] C = { { 1, 1 }, { 1, 1 } };

            int rows = 2, cols = 2;
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = 
                        A[j, i] - B[j, i] + 2 * C[i, j];
                }
            }

            Console.WriteLine("Результат A^T - B^T + 2C:");
            PrintMatrix(result);
        }

        public static void PrintMatrix(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    res += _matrix[i, j] + "\t";
                }
                res += "\n";
            }
            return res;
        }
    }
}