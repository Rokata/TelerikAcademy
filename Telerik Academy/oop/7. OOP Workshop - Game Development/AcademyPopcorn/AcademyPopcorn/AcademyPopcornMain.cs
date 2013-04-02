using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        /* Legend: 
            G - gift block 
            X - gift (the block that is dropped after G is hit)
            E - the exploding block 
            * - TrailObject (used by the meteorite ball or after explosion of ExplodingBlock) 
            @ - bullet fired by the racket
            % - ExplosionBlockResult blocks
         */

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // build ceiling and left wall for the scene
            for (int i = 0; i < endCol; i++)
            {
                Block ceilingBlock = new IndestructibleBlock(new MatrixCoords(0, i));
                Block leftWallBlock = new IndestructibleBlock(new MatrixCoords(i, 0));

                engine.AddObject(ceilingBlock);
                engine.AddObject(leftWallBlock);
            }

            // build right wall for the scene
            for (int i = 0; i < WorldRows; i++)
            {
                Block rightWallBlock = new IndestructibleBlock(new MatrixCoords(i, endCol - 1));
                engine.AddObject(rightWallBlock);
            }

            // meteorite or unstoppable ball test
            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            // test trail object with random MatrixCoords and lifetime = 15 turns
            GameObject trailObj = new TrailObject(new MatrixCoords(WorldRows - 6, WorldCols - 12), 15);
            engine.AddObject(trailObj);

            // add a gift block
            Block giftBlock = new GiftBlock(new MatrixCoords(WorldRows - 11, WorldCols - 20));
            engine.AddObject(giftBlock);

            //add unpassable block with random coords
            Block unpassable = new UnpassableBlock(new MatrixCoords(WorldRows - 15, WorldCols - 10));
            engine.AddObject(unpassable);

            // add exploding block and ordinary blocks around it
            Block explodingBlock = new ExplodingBlock(new MatrixCoords(WorldRows - 12, WorldCols - 35));
            Block leftToExploding = new Block(explodingBlock.TopLeft + new MatrixCoords(0, -1));
            Block rightToExploding = new Block(explodingBlock.TopLeft + new MatrixCoords(0, 1));
            engine.AddObject(explodingBlock);
            engine.AddObject(leftToExploding);
            engine.AddObject(rightToExploding);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            PopcornEngine gameEngine = new PopcornEngine(renderer, keyboard, 100);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            // shoot when space is pressed
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
