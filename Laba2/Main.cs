using System;
using Figures;
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Козинов Олег ИУ5-35Б";

            Rectangle rectangle = new Rectangle(10, 20);
            rectangle.Print();

            Square square = new Square(30);
            square.Print();

            Circle circle = new Circle(10);

            circle.Print();

            Console.ReadLine();
        }
    }
}
