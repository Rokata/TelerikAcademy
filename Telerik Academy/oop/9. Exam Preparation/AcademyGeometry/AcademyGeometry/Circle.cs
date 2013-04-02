using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyGeometry
{
    public class Circle : Figure, IFlat, IAreaMeasurable
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { this.radius = value; }
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }

        public Circle (Vector3D center, double radius) : base(center) 
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.Round((Math.PI * radius * radius), 2);
        }

        public Vector3D GetNormal()
        {
            return new Vector3D(0, 0, 1);
        }

        public new void Scale(Vector3D scaleCenter, double scaleFactor)
        {           
        }
    }
}
