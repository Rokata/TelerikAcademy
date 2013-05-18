using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem04_Free_Content
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand commmand, StringBuilder output)
        {
            switch (commmand.Type)
            {
                case CommandType.AddBook:
                    {
                        catalog.Add(new Content(ContentType.Book, commmand.Parameters));
                        output.AppendLine("Book added"); 
                        break;
                    } 
                case CommandType.AddMovie:
                    {
                        catalog.Add(new Content(ContentType.Movie, commmand.Parameters));
                        output.AppendLine("Movie added");
                        break;
                    }
                case CommandType.AddSong:
                    {
                        catalog.Add(new Content(ContentType.Song, commmand.Parameters));
                        output.AppendLine("Song added");
                        break;
                    }
                case CommandType.AddApplication:
                    {
                        catalog.Add(new Content(ContentType.Application, commmand.Parameters));
                        output.AppendLine("Application added"); 
                        break;
                    }  
                case CommandType.Update:
                    {
                        if (commmand.Parameters.Length != 2)
                        {
                            throw new FormatException("Invalid parameteres count.");
                        }

                        int itemsUpdated = catalog.UpdateContent(commmand.Parameters[0], commmand.Parameters[1]);
                        string updatedInfo = String.Format("{0} items updated", itemsUpdated);

                        output.AppendLine(updatedInfo);
                        break;
                    }
                case CommandType.Find:
                    {
                        if (commmand.Parameters.Length != 2)
                        {
                            throw new Exception("Invalid number of parameters!");
                        }

                        int numberOfElementsToList = int.Parse(commmand.Parameters[1]);
                        FindContent(catalog, commmand, output, numberOfElementsToList);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Unknown command type.");
                    }
            }
        }

        private void FindContent(ICatalog catalog, ICommand commmand, StringBuilder output, int numberOfElementsToList)
        {
            IEnumerable<IContent> foundContent = catalog.GetListContent(commmand.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
