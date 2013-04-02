using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public new const char Symbol = 'E';

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                // new moving blocks will collide for sure with the surrounding blocks which will be destroyed
                ExplodingBlockResult leftInvisible = new ExplodingBlockResult(this.topLeft, new MatrixCoords(0, -1));
                ExplodingBlockResult rightInvisible = new ExplodingBlockResult(this.topLeft, new MatrixCoords(0, 1));

                List<ExplodingBlockResult> trails = new List<ExplodingBlockResult>();
                trails.Add(leftInvisible);
                trails.Add(rightInvisible);
                return trails;
            }

            return new List<GameObject>();
        }
    }
}
