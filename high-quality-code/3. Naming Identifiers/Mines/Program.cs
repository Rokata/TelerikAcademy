using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesGame
{
    public class Mines
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] board = GetBoard();
            char[,] bombs = GetBoardWithBombs();
            int count = 0;
            bool hasExploded = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool hasEndedGame = true;
            const int maxScore = 35;
            bool hasCompletedGame = false;

            do
            {
                if (hasEndedGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DisplayBoard(board);
                    hasEndedGame = false;
                }
                Console.Write("Daj row i col : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        DisplayScores(champions);
                        break;
                    case "restart":
                        board = GetBoard();
                        bombs = GetBoardWithBombs();
                        DisplayBoard(board);
                        hasExploded = false;
                        hasEndedGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                PlayTurn(board, bombs, row, col);
                                count++;
                            }
                            if (maxScore == count)
                            {
                                hasCompletedGame = true;
                            }
                            else
                            {
                                DisplayBoard(board);
                            }
                        }
                        else
                        {
                            hasExploded = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (hasExploded)
                {
                    DisplayBoard(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si nickname: ", count);
                    string nickname = Console.ReadLine();
                    Player newPlayer = new Player(nickname, count);
                    if (champions.Count < 5)
                    {
                        champions.Add(newPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < newPlayer.Points)
                            {
                                champions.Insert(i, newPlayer);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Player first, Player second) => first.Name.CompareTo(second.Name));
                    champions.Sort((Player first, Player second) => second.Points.CompareTo(first.Points));
                    DisplayScores(champions);

                    board = GetBoard();
                    bombs = GetBoardWithBombs();
                    count = 0;
                    hasExploded = false;
                    hasEndedGame = true;
                }
                if (hasCompletedGame)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DisplayBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, count);
                    champions.Add(player);
                    DisplayScores(champions);
                    board = GetBoard();
                    bombs = GetBoardWithBombs();
                    count = 0;
                    hasCompletedGame = false;
                    hasEndedGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void DisplayScores(List<Player> players)
        {
            Console.WriteLine("\nTo4KI:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, players[i].Name, players[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void PlayTurn(char[,] board, char[,] boardWithBombs, int row, int col)
        {
            char bombsAroundCount = GetBombsCountAroundPosition(boardWithBombs, row, col);
            boardWithBombs[row, col] = bombsAroundCount;
            board[row, col] = bombsAroundCount;
        }

        private static void DisplayBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GetBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GetBoardWithBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int random in randomNumbers)
            {
                int col = (random / cols);
                int row = (random % cols);
                if (row == 0 && random != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                board[col, row - 1] = '*';
            }

            return board;
        }

        private static void SetBombsAroundNumbers(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char bombsAroundCount = GetBombsCountAroundPosition(board, i, j);
                        board[i, j] = bombsAroundCount;
                    }
                }
            }
        }

        private static char GetBombsCountAroundPosition(char[,] board, int row, int col)
        {
            int count = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (board[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (board[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}
