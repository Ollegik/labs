using System;

namespace Figures
{

    abstract public class Figure : IComparable
    {
        public string Type
        {
            get
            {
                return this.figure_type;
            }
            protected set
            {
                this.figure_type = value;
            }
        }
        private string figure_type;


        public abstract double Area();


        public override string ToString()
        {

            return "Фигура - " + this.Type + " S =  " + this.Area().ToString();
        }

        public int CompareTo(object obj)
        {
            Figure figure = (Figure)obj;

            if (this.Area() < figure.Area())
                return -1;

            else if (this.Area() == figure.Area())
                return 0;

            else return 1;
        }
    }
}
