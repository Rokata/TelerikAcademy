using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject 
    {
        private int lifetime;
        private int turnsCount;

        public int LifeTime
        {
            get { return lifetime; }
        }

        public TrailObject(MatrixCoords topLeft, int lifetime)
            : base(topLeft, new char[,] { { '*'} })
        {
            this.lifetime = lifetime;
            this.turnsCount = 0;
        }

        public void Disappear()
        {
            this.IsDestroyed = true;
        }

        public override void Update()
        {
            turnsCount++;

            if (turnsCount == lifetime) this.Disappear();
        }
    }
}
