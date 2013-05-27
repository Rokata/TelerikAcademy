using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace PhonebookApp
{
    public class PhonebookCommandExecutor
    {
        public void ExecuteCommand(CommandType commandType, string[] commandParams, IPhonebookRepository phonebook, StringBuilder output)
        {
            switch (commandType)
            {
                case CommandType.AddPhone:
                    {
                        ExecuteAdd(commandParams, phonebook, output);
                        break;
                    }
                case CommandType.ChangePhone:
                    {
                        ExecuteChange(commandParams, phonebook, output);
                        break;
                    }
                case CommandType.List:
                    {
                        try
                        {
                            OutputEntries(commandParams, phonebook, output);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            output.AppendLine("Invalid range");
                        }
                        break;
                    }
            }
        }

        private void OutputEntries(string[] commandParams, IPhonebookRepository phonebook, StringBuilder output)
        {
            int startIndex = int.Parse(commandParams[0]);
            int count = int.Parse(commandParams[1]);

            IEnumerable<PhonebookEntry> entries = phonebook.ListEntries(startIndex, count);

            foreach (var entry in entries)
            {
                output.AppendLine(entry.ToString());
            }
        }

        private void ExecuteAdd(string[] commandParams, IPhonebookRepository phonebook, StringBuilder output)
        {
            string name = commandParams[0];
            var phones = commandParams.Skip(1).ToList();

            for (int i = 0; i < phones.Count; i++)
            {
                phones[i] = PhonebookUtils.ConvertPhoneNumber(phones[i]);
            }

            bool phoneExists = phonebook.AddPhone(name, phones);

            if (phoneExists)
            {
                output.AppendLine("Phone entry merged");
            }
            else
            {
                output.AppendLine("Phone entry created");
            }
        }

        private void ExecuteChange(string[] commandParams, IPhonebookRepository phonebook, StringBuilder output)
        {
            string oldNumberConverted = PhonebookUtils.ConvertPhoneNumber(commandParams[0]);
            string newNumberConverted = PhonebookUtils.ConvertPhoneNumber(commandParams[1]);
            int numbersChanged = phonebook.ChangePhone(oldNumberConverted, newNumberConverted);

            output.AppendLine(numbersChanged + " numbers changed");
        }
    }
}
