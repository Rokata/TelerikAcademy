using System;

class TwoInOne
{
    private static string CheckBounded(char[] commands)
    {
        int x_coord = 0;
        int y_coord = 0;
        string currentDirection = "right";

        for (int i = 0; i < 4; i++)
        {
            foreach (char c in commands)
            {
                switch (c)
                {
                    case 'S':
                        if (currentDirection == "forward") y_coord++;
                        else if (currentDirection == "left") x_coord--;
                        else if (currentDirection == "right") x_coord++;
                        else y_coord--;
                        break;
                    case 'R':
                        if (currentDirection == "forward") currentDirection = "right";
                        else if (currentDirection == "left") currentDirection = "forward";
                        else if (currentDirection == "right") currentDirection = "backward";
                        else currentDirection = "left";
                        break;
                    case 'L':
                        if (currentDirection == "forward") currentDirection = "left";
                        else if (currentDirection == "left") currentDirection = "backward";
                        else if (currentDirection == "right") currentDirection = "forward";
                        else currentDirection = "right";
                        break;
                }
            }         
        }

        if (x_coord != 0 || y_coord != 0) return "unbounded";
        else return "bounded";
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        char[] commandsOne = Console.ReadLine().ToCharArray();
        char[] commandTwo = Console.ReadLine().ToCharArray();

        bool[] isTurned = new bool[N + 1];

        int offset = 2;
        int last = 0;

        int maxOffset = N - 2;

        for (int i = 1; i <= N; i++)
        {
            if (!isTurned[i])
            {
                for (int j = i; j <= N; j += offset)
                {
                    if (!isTurned[j])
                    {
                        isTurned[j] = true;
                        last = j;
                    }
                }
            }
            offset++;
        }

        Console.WriteLine(last);
        Console.WriteLine(CheckBounded(commandsOne));
        Console.WriteLine(CheckBounded(commandTwo));
    }
}
