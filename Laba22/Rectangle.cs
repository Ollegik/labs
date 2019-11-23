using System;
namespace Figures
{
    public class Rectangle : Figure, IPrint
    {
        private double rect_height;
        private double rect_width;
        public double height
        {
            get
            {
                return this.rect_height;
            }
            set
            {
                this.rect_height = value;
            }
        }
        public double width
        {
            get
            {
                return this.rect_width;
            }
            set
            {
                this.rect_width = value;
            }
        }

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
            this.Type = "Прямоугольник";
        }

        public override double Area()
        {
            return this.width * this.height;
        }

        public override string ToString()
        {
            return "Фигура - " + this.Type + " h = " + height + " w = " + width + " S =  " + this.Area().ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
