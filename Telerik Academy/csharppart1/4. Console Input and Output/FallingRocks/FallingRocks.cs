using System;
using System.Threading;

struct Position
{
    public int row;
    public int col;
    public Position(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}

struct Rock
{
    public string symbol;
    public int colour;
    public int length;
    public Position position;
    public Rock(string symbol, int colour, int length, Position position)
    {
        this.symbol = symbol;
        this.colour = colour;
        this.length = length;
        this.position = position;
    }
}

class FallingRocks
{

    static void Main()
    {
        byte right = 0;
        byte left = 1;
        byte stop = 2;
        Position[] directions = new Position[]
            {
                new Position(0, 1), 
                new Position(0, -1), 
                new Position(0, 0), 
            };

        Rock[] rocks = new Rock[Console.BufferHeight];

        bool isAlive = true;
        bool collision = false;
        int points = 0;
        int randomSymbol, randomColour, randomLength;
        int index = 0;
        string rockSymbol = "";
        double sleepTime = 150;
        int direction = stop;
        Random randomNumbersGenerator = new Random();
        Console.CursorVisible = false;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Position Dwarf = new Position(Console.BufferHeight - 2, Console.BufferWidth / 2);

        do
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    direction = left;
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    direction = right;
                }
            }

            Position nextDirection = directions[direction];
            Position newDwarf = new Position(Dwarf.row, Dwarf.col + nextDirection.col);

            if (newDwarf.col < 0 || newDwarf.col > Console.BufferWidth - 3)
            {
                Console.SetCursorPosition(Dwarf.col, Dwarf.row);
                Console.Write("(O)");
            }
            else
            {
                Console.SetCursorPosition(newDwarf.col, newDwarf.row);
                Console.Write("(O)");
                Dwarf = newDwarf;
            }

            randomSymbol = randomNumbersGenerator.Next(0, 11);

            switch (randomSymbol)
            {
                case 0: rockSymbol = "^"; break;
                case 1: rockSymbol = "@"; break;
                case 2: rockSymbol = "*"; break;
                case 3: rockSymbol = "&"; break;
                case 4: rockSymbol = "+"; break;
                case 5: rockSymbol = "%"; break;
                case 6: rockSymbol = "$"; break;
                case 7: rockSymbol = "#"; break;
                case 8: rockSymbol = "!"; break;
                case 9: rockSymbol = "."; break;
                case 10: rockSymbol = ";"; break;
                case 11: rockSymbol = "-"; break;
                default: Console.Write("Something's wrong with the symbols!"); break;
            }

            randomColour = randomNumbersGenerator.Next(0, 14);

            randomLength = randomNumbersGenerator.Next(1, 5);
            Position rockPosition = new Position(0, randomNumbersGenerator.Next(0, Console.BufferWidth - 1));
            rocks[index] = new Rock(rockSymbol, randomColour, randomLength, rockPosition);


            for (int i = 0; i < index; i++)
            {
                Console.SetCursorPosition(rocks[i].position.col, rocks[i].position.row);

                switch (rocks[i].colour)
                {
                    case 0: Console.ForegroundColor = ConsoleColor.Blue; break;
                    case 1: Console.ForegroundColor = ConsoleColor.Cyan; break;
                    case 2: Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                    case 3: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                    case 4: Console.ForegroundColor = ConsoleColor.DarkGray; break;
                    case 5: Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                    case 6: Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                    case 7: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                    case 8: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                    case 9: Console.ForegroundColor = ConsoleColor.Gray; break;
                    case 10: Console.ForegroundColor = ConsoleColor.Green; break;
                    case 11: Console.ForegroundColor = ConsoleColor.Magenta; break;
                    case 12: Console.ForegroundColor = ConsoleColor.Red; break;
                    case 13: Console.ForegroundColor = ConsoleColor.White; break;
                    case 14: Console.ForegroundColor = ConsoleColor.Yellow; break;
                    default: Console.Write("Something's wrong with the colour!"); break;
                }

                for (int j = 0; j < rocks[i].length; j++)
                {
                    Console.Write(rocks[i].symbol);
                }

                rocks[i].position.row++;
                if (rocks[i].position.row - 1 == Dwarf.row)
                {
                    collision = ((Dwarf.col + 2 >= rocks[i].position.col) && (Dwarf.col + 2 <= rocks[i].position.col + rocks[i].length - 1)) || ((Dwarf.col >= rocks[i].position.col) && (Dwarf.col <= rocks[i].position.col + rocks[i].length - 1));
                    if (collision)
                    {
                        isAlive = false;
                        break;
                    }
                    for (int j = i; j < index; j++)
                    {
                        rocks[j] = rocks[j + 1];
                    }
                    points++;
                    index--;
                }

            }

            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep((int)sleepTime);
            index++;

            Console.Clear();

        } while (isAlive);

        Console.SetCursorPosition(Console.BufferWidth / 2 - 10, 0);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You made {0} points.\n\n", points);
        Console.CursorLeft = Console.BufferWidth / 2 - 5;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Game Over!");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
