using System;
using System.Collections.Generic;
using System.Text;

namespace Problem04_Free_Content
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder(); 
            Catalog catalog = new Catalog();
            ICommandExecutor executor = new CommandExecutor();

            List<ICommand> commandsForExecution = Parse();

            foreach (ICommand item in commandsForExecution)
            {
                executor.ExecuteCommand(catalog, item, output);
            }

            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output); 
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> commands = new List<ICommand>();
            bool isEndCommand = false;

            do
            {
                string commandString = Console.ReadLine().Trim();
                isEndCommand = (commandString == "End");

                if (!isEndCommand)
                {
                    commands.Add(new Command(commandString));
                }

            }
            while (!isEndCommand);

            return commands;
        }
    }
}
