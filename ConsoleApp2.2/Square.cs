using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Figures
{
    class Square : Rectangle, IPrint
    {
        public Square(double size) : base(size, size)
        {
            this.Type = "Квадрат";
        }
    }
}
