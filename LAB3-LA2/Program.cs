using System;

namespace LabWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("Задание 1. Заполнение " +
                "двумерных массивов");

            Console.WriteLine("\n1.1 Первый массив:");
            Console.WriteLine("Заполнение первого массива " +
                "(по столбцам):");
            MatrixTask m1 = new MatrixTask(2, 3);
            Console.WriteLine(m1.ToString());

            Console.WriteLine("\n1.2 Второй массив (4x4):");
            MatrixTask m2 = new MatrixTask(4, true);
            Console.WriteLine(m2.ToString());

            Console.WriteLine("\n1.3 Третий массив (5x5):");
            MatrixTask m3 = new MatrixTask(5);
            Console.WriteLine(m3.ToString());

            Console.WriteLine($"\nСоздано объектов " +
                $"MatrixTask: {MatrixTask.CreatedCount}");

            // 2
            Console.WriteLine("\nЗадание 2. Работа с " +
                "двумерными массивами");
            int[,] grades =
            {
                { 5, 5, 5, 4 },
                { 3, 4, 3, 4 },
                { 5, 4, 5, 5 }
            };
            MatrixTask.FindExcellentStudents(grades);

            // 3
            Console.WriteLine("\nЗадание 3. Работа с" +
                " двумерными массивами как с матрицами");
            MatrixTask.CalculateMatrixExpression();

            // 4-8
            Console.WriteLine("\nЗадание 4. Бинарные файлы");
            FileTasks.Task4_BinaryFile();

            Console.WriteLine("\nЗадание 5. Бинарные" +
                " файлы и структуры");
            FileTasks.Task5_XmlStructures();

            Console.WriteLine("\nЗадание 6. Текстовые файлы");
            FileTasks.Task6_TextFileAvg();

            Console.WriteLine("\nЗадание 7. Решить задачу " +
                "с использованием структуры «текстовый файл»");
            FileTasks.Task7_TextFileProduct();

            Console.WriteLine("\nЗадание 8. Текстовый файл");
            FileTasks.Task8_TextFileFilter();
        }
    }
}