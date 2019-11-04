using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figures
{
    abstract class Figure
    {
        public string Type
        {
            get
            {
                return this._Type;
            }
            protected set
            {
                this._Type = value;
            }
        }
        string _Type;
        public abstract double Area();
        public override string ToString()
        {
            return this.Type + " площадью " + this.Area().ToString();
        }
    }
}