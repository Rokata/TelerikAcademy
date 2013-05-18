using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04_Free_Content
{
    public class Command : ICommand
    {
        private readonly char[] ParamsSeparators = { ';' };
        private readonly char CommandEnd = ':';
        private CommandType type;
        private string originalForm;
        private string name;
        private string[] parameters;
        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string OriginalForm
        {
            get { return this.originalForm; }
            set { this.originalForm = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string[] Parameters
        {
            get { return this.parameters; }
            set { this.parameters = value; }
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        public CommandType ParseCommandType(string commandName)
        {
            CommandType type;
            commandName = commandName.Trim();

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("Command name cannot contain symbols like ':' or ';'.");
            }

            switch (commandName)
            {
                case "Add book":
                    {
                        type = CommandType.AddBook;
                        break;
                    }
                case "Add movie":
                    {
                        type = CommandType.AddMovie;
                        break;
                    }
                case "Add song":
                    {
                        type = CommandType.AddSong;
                        break;
                    } 
                case "Add application":
                    {
                        type = CommandType.AddApplication;
                        break;
                    }
                case "Update":
                    {
                        type = CommandType.Update;
                        break;
                    }
                case "Find":
                    {
                        type = CommandType.Find;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Invalid command name.");
                    }
            }

            return type;
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsStringLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);
            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsStringLength);
            string[] parameters = paramsOriginalForm.Split(ParamsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        private int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(CommandEnd) - 1;

            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} ", this.Name);
            result.Append(string.Join(" ", this.Parameters));

            return result.ToString();
        }
    }
}
