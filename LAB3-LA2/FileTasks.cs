using System;
using System.IO;
using System.Xml.Serialization;

namespace LabWork
{
    public struct Toy
    {
        private string _name;
        private double _price;
        private int _minAge;
        private int _maxAge;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int MinAge
        {
            get { return _minAge; }
            set { _minAge = value; }
        }

        public int MaxAge
        {
            get { return _maxAge; }
            set { _maxAge = value; }
        }

        public Toy(string name, double price, 
            int minAge, int maxAge)
        {
            _name = name;
            _price = price;
            _minAge = minAge;
            _maxAge = maxAge;
        }
    }

    public static class FileTasks
    {
        // 4: Бинарные файлы
        public static void Task4_BinaryFile()
        {
            string path = "task4.bin";
            Random rnd = new Random();

            using (BinaryWriter writer =
                new BinaryWriter(File.Open(
                    path, FileMode.Create)))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(rnd.Next(1, 20));
                }
            }

            int count = 0;
            using (BinaryReader reader =
                new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.BaseStream.Position <
                    reader.BaseStream.Length)
                {
                    int num = reader.ReadInt32();
                    if (num % 2 != 0)
                    {
                        int root = (int)Math.Sqrt(num);
                        if (root * root == num)
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine($"Квадратов " +
                $"нечётных чисел = {count}");
        }

        // 5: Бинарный файл + структура + XML
        public static void Task5_XmlStructures()
        {
            string path = "task5.xml";

            Toy[] toys = new Toy[]
            {
                new Toy("Кукла", 500, 3, 10),
                new Toy("Машинка", 1200, 2, 6),
                new Toy("Конструктор", 2000, 6, 12),
                new Toy("Погремушка", 200, 0, 2)
            };

            XmlSerializer serializer =
                new XmlSerializer(typeof(Toy[]));

            using (FileStream fs =
                new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, toys);
            }

            Toy[] loaded;
            using (FileStream fs =
                new FileStream(path, FileMode.Open))
            {
                loaded = (Toy[])serializer.Deserialize(fs);
            }

            Toy best = new Toy();
            double maxPrice = 0;
            bool found = false;

            for (int i = 0; i < loaded.Length; i++)
            {
                if (loaded[i].MinAge <= 4
                    && loaded[i].Price > maxPrice)
                {
                    maxPrice = loaded[i].Price;
                    best = loaded[i];
                    found = true;
                }
            }

            if (found)
            {
                Console.WriteLine($"{best.Name} — " +
                    $"{best.Price} руб.");
            }
            else
            {
                Console.WriteLine("Игрушек до 4 лет не найдено.");
            }
        }

        // 6: Текстовые файлы
        public static void Task6_TextFileAvg()
        {
            string path = "task6.txt";
            Random rnd = new Random();

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine(rnd.Next(1, 100));
                }
            }

            string[] lines = File.ReadAllLines(path);
            int[] nums = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                nums[i] = int.Parse(lines[i]);
            }

            int max = nums[0];
            int min = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > max) max = nums[i];
                if (nums[i] < min) min = nums[i];
            }

            double avg = (max + min) / 2.0;
            Console.WriteLine($"Среднее max и min = {avg}");
        }

        // 7: Текстовые файлы
        public static void Task7_TextFileProduct()
        {
            string path = "task7.txt";
            Random rnd = new Random();

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        sw.Write(rnd.Next(1, 10) + " ");
                    }
                    sw.WriteLine();
                }
            }

            long product = 1;
            bool hasEven = false;
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts =
                    lines[i].Split(new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < parts.Length; j++)
                {
                    int num = int.Parse(parts[j]);
                    if (num % 2 == 0 && num != 0)
                    {
                        product *= num;
                        hasEven = true;
                    }
                }
            }

            if (!hasEven)
            {
                product = 0;
            }
            Console.WriteLine($"Произведение " +
                $"чётных = {product}");
        }

        // 8: Текстовый файл
        public static void Task8_TextFileFilter()
        {
            string source = "task8_source.txt";
            string dest = "task8_dest.txt";

            string[] sourceLines = new string[]
            {
                "Привет мир",
                "Hello World",
                "Это строка без латиницы",
                "C# programming",
            };

            File.WriteAllLines(source, sourceLines);

            string[] allLines = File.ReadAllLines(source);
            string[] result = new string[allLines.Length];
            int count = 0;

            for (int i = 0; i < allLines.Length; i++)
            {
                bool hasLatin = false;
                string line = allLines[i];

                for (int j = 0; j < line.Length; j++)
                {
                    char c = line[j];
                    if ((c >= 'a' && c <= 'z') ||
                        (c >= 'A' && c <= 'Z'))
                    {
                        hasLatin = true;
                        break;
                    }
                }

                if (!hasLatin)
                {
                    result[count] = line;
                    count++;
                }
            }

            using (StreamWriter sw = new StreamWriter(dest))
            {
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(result[i]);
                }
            }

            Console.WriteLine($"Результат записан в {dest}");
        }
    }
}