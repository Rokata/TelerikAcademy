using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool canShoot;
        private bool hasCollectedGift;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            canShoot = false;
            hasCollectedGift = false;
        }

        public void Shoot()
        {
            // only if a gift has been collected will the racket be able to shoot, otherwise nothing will happen uppon pressing Space
            if (hasCollectedGift) this.canShoot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            // it will always shoot a couple of bullets from both sides of the racket if the latter has the ability to do so
            if (canShoot && hasCollectedGift)
            {
                canShoot = false;

                List<Bullet> bullets = new List<Bullet>();
                bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row - 1, this.TopLeft.Col), new MatrixCoords(-1, 0)));
                bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row - 1, this.TopLeft.Col + Width - 1), new MatrixCoords(-1, 0)));

                return bullets;
            }

            return new List<GameObject>();
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("gift"))
            {
                hasCollectedGift = true;
            }
        }
    }
}
