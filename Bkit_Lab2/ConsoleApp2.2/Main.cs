using System;
using System.Linq;
using System.Text;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)


        {
            Console.Title = "Козинов Олег, ИУ5-35Б";
            Rectangle rect = new Rectangle(5, 4); Square square = new Square(5); Circle circle = new Circle(5);
            rect.Print();
            square.Print();
            circle.Print();

            Console.ReadLine();
        }
    }
}