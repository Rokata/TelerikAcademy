using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyGeometry
{
    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { this.radius = value; }
        }

        public double Height
        {
            get
            {
                return (this.vertices[1] - this.vertices[0]).Magnitude;
            }
        }

        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(bottom, top)
        {
            this.radius = radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        public double GetArea()
        {
            double area = (2 * Math.PI * radius * radius) + (2 * Math.PI * radius * Height);
            return Math.Round(area, 2);
        }

        public double GetVolume()
        {
            return Math.Round((Math.PI * radius * radius * Height), 2);
        }

        public new void Scale(Vector3D scaleCenter, double scaleFactor)
        {
        }
    }
}
