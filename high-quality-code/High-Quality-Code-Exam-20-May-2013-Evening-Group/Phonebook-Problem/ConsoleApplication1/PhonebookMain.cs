using System;
using System.Text;

namespace PhonebookApp
{
    namespace PhonebookProblem
    {
        class PhonebookMain
        {
            private static StringBuilder output = new StringBuilder();

            static void Main()
            {
                bool isExecuting = true;
                PhonebookCommandResolver resolver = new PhonebookCommandResolver();
                PhonebookCommandExecutor executor = new PhonebookCommandExecutor();
                IPhonebookRepository phonebook = new Phonebook();

                while (isExecuting)
                {
                    string commandString = Console.ReadLine();
                    if (commandString == "End" || commandString == null)
                    {
                        isExecuting = false;
                        break;
                    }

                    int openBracketIndex;
                    string commandName = resolver.GetCommandName(commandString, out openBracketIndex);

                    if (!commandString.EndsWith(")"))
                    {
                        throw new InvalidOperationException("Invalid command.");
                    }

                    string commandBody = commandString.Substring(openBracketIndex + 1, commandString.Length - openBracketIndex - 2);
                    string[] commandParams = commandBody.Split(',');

                    for (int j = 0; j < commandParams.Length; j++)
                    {
                        commandParams[j] = commandParams[j].Trim();
                    }

                    CommandType type = resolver.GetCommandType(commandName, commandParams);
                    executor.ExecuteCommand(type, commandParams, phonebook, output);
                }
                Console.Write(output);
            }
        }
    }
}
