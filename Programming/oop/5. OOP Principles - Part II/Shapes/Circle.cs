using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double value) : base(value) { }

        public override double CalculateSurface()
        {
            return (Math.PI * Width * Width) / 4; // пr^2 = nd^2 / 4 ; Width = Diameter
        }
    }
}
