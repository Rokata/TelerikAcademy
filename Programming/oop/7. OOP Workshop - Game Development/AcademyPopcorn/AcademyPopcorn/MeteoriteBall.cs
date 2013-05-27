using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public const int trailsLifetime = 3;

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            
        }

        public override void Update()
        {
            MatrixCoords oldPosition = new MatrixCoords(this.topLeft.Row, this.topLeft.Col);
            base.Update();
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> trails = new List<TrailObject>();
            trails.Add(new TrailObject(this.TopLeft - this.Speed, trailsLifetime));
            return trails;
        }
    }
}
