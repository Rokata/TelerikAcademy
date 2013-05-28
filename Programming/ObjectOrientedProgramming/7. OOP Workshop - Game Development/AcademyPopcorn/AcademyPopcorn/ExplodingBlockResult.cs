using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ExplodingBlockResult : MovingObject
    {
        public ExplodingBlockResult(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] {{'%'}}, speed)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
