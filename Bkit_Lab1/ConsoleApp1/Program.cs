using System;
namespace ConsoleApp1
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
                Console.WriteLine("Ввод");
                try
                {
                    a = Double.Parse(args[0]);
                    b = Double.Parse(args[1]);
                    c = Double.Parse(args[2]);
                }
                catch
                {
                    Console.WriteLine("Ошибка, попробуйте еще раз ");
                    a = ReadDouble("А: ");
                    b = ReadDouble("B: ");
                    c = ReadDouble("C: ");
                }
            }
            else
            {
                a = ReadDouble("А: ");
                b = ReadDouble("B: ");
                c = ReadDouble("C: ");
            }
            if (a == 0 && b != 0)
            {
                double root = (-1 * c) / b;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Корни " + Math.Sqrt(root) + " и -" + Math.Sqrt(root));
            }
            else if (a != 0)
            {
                double discrim = Math.Pow(b, 2) - 4 * a * c;
                Console.WriteLine("Дискриминант: " + discrim);
                if (discrim > 0)
                {
                    double root_1 = (-1 * b + Math.Sqrt(discrim)) / (2 * a);
                    double root_2 = (-1 * b - Math.Sqrt(discrim)) / (2 * a);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корень 1: " + Math.Sqrt(root_1));
                    Console.WriteLine("Корень 2: " + -1 * Math.Sqrt(root_1));
                    Console.WriteLine("Корень 3: " + Math.Sqrt(root_2));
                    Console.WriteLine("Корень 4: " + -1 * Math.Sqrt(root_2));
                }
                else if (discrim == 0)
                {
                    double root = (b + Math.Sqrt(discrim)) / (2 * a);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Корни " + Math.Sqrt(root) + " и " + -1 * Math.Sqrt(root));
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
                Console.WriteLine("Оба коэффициента нулевые");
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
                    Console.WriteLine("Ошибка, попробуйте еще раз");
                    Console.ResetColor();
                }
            }
            while (!flag);
            return resultDouble;
        }
    }
}