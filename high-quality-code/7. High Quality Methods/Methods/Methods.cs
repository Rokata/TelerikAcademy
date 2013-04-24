using System;
using System.Diagnostics;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 ||
                (a > b + c) || (b > a + c) || (c > a + b))
            {
                throw new ArgumentException("These sides cannot form a triangle.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            string word;

            switch (number)
            {
                case 0: word = "zero"; break;
                case 1: word = "one"; break;
                case 2: word = "two"; break;
                case 3: word = "three"; break;
                case 4: word = "four"; break;
                case 5: word = "five"; break;
                case 6: word = "six"; break;
                case 7: word = "seven"; break;
                case 8: word = "eight"; break;
                case 9: word = "nine"; break;
                default: throw new ArgumentException(number + " is not a digit.");
            }

            return word;
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Array is null or elements count is less than one.");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }
            return maxElement;
        }

        static void PrintAsNumber(object number, string format)
        {
            decimal outputNumber;

            if (!decimal.TryParse(number.ToString(), out outputNumber) || format == null)
            {
                throw new FormatException("Invalid arguments. Object must be valid number and format must be a known format.");
            }

            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new FormatException("Invalid number format.");
            }
        }

        static double CalcDistanceBetweenPoints(Point first, Point second)
        {
            double firstX = first.X;
            double firstY = first.Y;
            double secondX = second.X;
            double secondY = second.Y;

            double distance = Math.Sqrt((secondX - firstX) * (secondX - firstX) + (secondY - firstY) * (secondY - firstY));
            return distance;
        }

        static bool EqualOnX(Point first, Point second)
        {
            return (first.X == second.X);
        }

        static bool EqualOnY(Point first, Point second)
        {
            return (first.Y == second.Y);
        }

        static void Main()
        {
            try
            {
                Console.WriteLine(CalcTriangleArea(3, 4, 5));

                Console.WriteLine(NumberToDigit(5));

                Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

                PrintAsNumber(5, "f");
                PrintAsNumber(0.75, "%");
                PrintAsNumber(2.30, "r");

                Point pointOne = new Point(3, -1);
                Point pointTwo = new Point(3, 2.5);

                Console.WriteLine(CalcDistanceBetweenPoints(pointOne, pointTwo));

                bool horizontal = EqualOnY(pointOne, pointTwo);
                bool vertical = EqualOnX(pointOne, pointTwo);
                Console.WriteLine("Horizontal? " + horizontal);
                Console.WriteLine("Vertical? " + vertical);

                Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
                peter.OtherInfo = "From Sofia";
                peter.BirthDate = new DateTime(1992, 3, 17);

                Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
                stella.OtherInfo = "From Vidin, gamer, high results";
                stella.BirthDate = new DateTime(1993, 11, 3);

                if (peter.FirstName != null && stella.FirstName != null)
                {
                    Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
                }
                else
                {
                    Console.WriteLine("Cannot compare unnamed students.");
                }
                
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}
