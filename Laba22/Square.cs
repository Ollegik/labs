using System;
namespace Figures
{
    public class Square : Rectangle, IPrint
    {
        private double square_side;

        public double side
        {
            get
            {
                return this.square_side;
            }
            set
            {
                this.square_side = value;
            }
        }
        public Square(double side) : base(side, side)
        {
            this.Type = "Квадрат";
            this.side = side;
        }
        public override string ToString()
        {
            return "Фигура - " + this.Type + " side = " + side + " S =  " + this.Area().ToString();
        }

    }
}
