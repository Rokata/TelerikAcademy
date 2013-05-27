using System;

    class CalculateNumberSequence
    {
        static void Main()
        {
            int n;
            Console.Write("n=? ");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            int sum = n;

            for (int i = 1; i <= n; i++)
            {
                int next;
                Console.Write("Another number: ");

                if (int.TryParse(Console.ReadLine(), out next)) { }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }

                sum += next;
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
