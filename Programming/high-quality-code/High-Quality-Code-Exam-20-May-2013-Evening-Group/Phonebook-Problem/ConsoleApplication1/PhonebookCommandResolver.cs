using System;

namespace PhonebookApp
{
    public class PhonebookCommandResolver
    {
        public CommandType GetCommandType(string commandName, string[] commandParams)
        {
            if ((commandName.StartsWith("AddPhone")) && (commandParams.Length >= 2))
            {
                return CommandType.AddPhone;
            }
            else if ((commandName == "ChangePhone") && (commandParams.Length == 2))
            {
                return CommandType.ChangePhone;
            }
            else if ((commandName == "List") && (commandParams.Length == 2))
            {
                return CommandType.List;
            }
            else
            {
                throw new ArgumentException("Invalid command type.");
            }
        }

        public string GetCommandName(string commandString, out int bracketIndex)
        {
            bracketIndex = commandString.IndexOf('(');

            if (bracketIndex == -1)
            {
                throw new InvalidOperationException("Invalid command name.");
            }

            string commandName = commandString.Substring(0, bracketIndex);
            return commandName;
        }
    }
}
