using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public new const char Symbol = 'G';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                Gift gift = new Gift(this.TopLeft, new MatrixCoords(1, 0));
                List<Gift> gifts = new List<Gift>();
                gifts.Add(gift);
                return gifts;
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
