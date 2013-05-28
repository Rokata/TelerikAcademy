using System;

namespace Shapes
{
    class ShapesDemo
    {
        static void Main()
        {
            Shape[] shapes =  {
                                new Triangle(5.2, 5.3),
                                new Rectangle(5, 9.3),
                                new Circle(5)
                            };

            foreach (Shape s in shapes)
                Console.WriteLine("Surface of figure: {0}", s.CalculateSurface());
        }
    }
}
