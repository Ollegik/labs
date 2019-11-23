using System;
namespace Figures
{
    public class Circle : Figure, IPrint
    {


        public double radius
        {
            get
            {
                return this.circle_radius;
            }
            set
            {
                this.circle_radius = value;
            }
        }
        private double circle_radius;

        public Circle(double radius)
        {
            this.radius = radius;
            this.Type = "Круг";
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }

        public override string ToString()
        {
            return "Фигура - " + this.Type + " r = " + circle_radius + " S =  " + this.Area().ToString();
        }



        public void Print()
        {
            Console.WriteLine(this.ToString());
        }


    }
}
