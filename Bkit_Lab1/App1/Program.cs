using System;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Title = "Козинов Олег ИУ5-35Б";
            double a;
            double b;
            double c;
            if (args.Length == 3)
            {
                Console.WriteLine("Аргументы из командной строки");
                try
                {
                    a = Double.Parse(args[0]);
                    b = Double.Parse(args[1]);
                    c = Double.Parse(args[2]);

                }
                catch
                {
                    Console.WriteLine("Аргументы командной строки некорректны! ");
                    a = ReadDouble("Введите коэффициент А: ");
                    b = ReadDouble("Введите коэффициент B: ");
                    c = ReadDouble("Введите коэффициент C: ");
                }

            }
            else
            {
                a = ReadDouble("Введите коэффициент А: ");
                b = ReadDouble("Введите коэффициент B: ");
                c = ReadDouble("Введите коэффициент C: ");
            }



            if (a == 0 && b != 0)
            {
                double root = (-1 * c) / b;
                if (root > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корни " + Math.Sqrt(root) + " и -" + Math.Sqrt(root));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет");
                }
            }
            else if (a != 0)
            {
                double discrim = Math.Pow(b, 2) - 4 * a * c;

                Console.WriteLine("Дискриминант: " + discrim);

                if (discrim > 0)
                {
                    double root_1 = (-b + Math.Sqrt(discrim)) / (2 * a);
                    double root_2 = (-b - Math.Sqrt(discrim)) / (2 * a);
                    if (root_1 >= 0 && root_2 >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Корень 1: " + Math.Sqrt(root_1));
                        Console.WriteLine("Корень 2: " + -1 * Math.Sqrt(root_1));
                        Console.WriteLine("Корень 3: " + Math.Sqrt(root_2));
                        Console.WriteLine("Корень 4: " + -1 * Math.Sqrt(root_2));
                    }
                    else if (root_1 < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Корень 1: " + Math.Sqrt(root_2));
                        Console.WriteLine("Корень 2: " + -1 * Math.Sqrt(root_2));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Корень 1: " + Math.Sqrt(root_1));
                        Console.WriteLine("Корень 2: " + -1 * Math.Sqrt(root_1));
                    }

                }
                else if (discrim == 0)
                {
                    if (c != 0)
                    {
                        double root = (b + Math.Sqrt(discrim)) / (2 * a);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Корни " + Math.Sqrt(root) + " и " + -1 * Math.Sqrt(root));
                    }
                    else
                    {
                        double root = (b + Math.Sqrt(discrim)) / (2 * a);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Корень 0", Math.Sqrt(root));
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет");
                }
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Оба коэффициента при х равны нулю");
            }

            Console.ReadLine();
        }

        static double ReadDouble(string consoleMessage)
        {
            string resultString;
            double resultDouble;
            bool flag;
            do
            {
                Console.Write(consoleMessage);

                resultString = Console.ReadLine();
                if (!(flag = double.TryParse(resultString, out resultDouble)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод!");
                    Console.ResetColor();
                }
            }
            while (!flag);

            return resultDouble;
        }



    }
}