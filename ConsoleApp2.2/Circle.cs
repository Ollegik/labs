using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Figures
{
    class Circle : Figure, IPrint
    {
        double radius;
        public Circle(double pr)
        {
            this.radius = pr;
            this.Type = "Круг";
        }
        public override double Area()
        {
            double Result = Math.PI * this.radius * this.radius;
            return Result;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }
}
