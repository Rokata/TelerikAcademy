using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        public static DocSystem docSystem = new DocSystem();

        private static bool IsValidDocument(string name)
        {
            if (name == null)
            {
                Console.WriteLine("Document has no name");
                return false;
            }
            return true;
        }

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            string name = null, content = null, charset = null;

            foreach (string attr in attributes)
            {
                string[] pair = attr.Split('=');

                if (pair[0] == "name") name = pair[1];
                else if (pair[0] == "content") content = pair[1];
                else charset = pair[1];
            }

            if (IsValidDocument(name))
            {
                docSystem.AddDocument(new TextDocument(name, content, charset));
                Console.WriteLine("Document added: " + name);
            }
        }

        private static void AddPdfDocument(string[] attributes)
        {
            string name = null, content = null;
            int? size = null, pages = null;

            foreach (string attr in attributes)
            {
                string[] pair = attr.Split('=');

                if (pair[0] == "name") name = pair[1];
                else if (pair[0] == "content") content = pair[1];
                else if (pair[0] == "size") size = int.Parse(pair[1]);
                else pages = int.Parse(pair[1]);
            }

            if (IsValidDocument(name))
            {
                docSystem.AddDocument(new PDFDocument(name, content, size, pages));
                Console.WriteLine("Document added: " + name);
            }
        }

        private static void AddWordDocument(string[] attributes)
        {
            string name = null, content = null, version = null;
            int? size = null, chars = null;

            foreach (string attr in attributes)
            {
                string[] pair = attr.Split('=');

                if (pair[0] == "name") name = pair[1];
                else if (pair[0] == "content") content = pair[1];
                else if (pair[0] == "size") size = int.Parse(pair[1]);
                else if (pair[0] == "chars") chars = int.Parse(pair[1]);
                else version = pair[1];
            }

            if (IsValidDocument(name))
            {
                docSystem.AddDocument(new WordDocument(name, content, size, version, chars));
                Console.WriteLine("Document added: " + name);
            }
        }

        private static void AddExcelDocument(string[] attributes)
        {
            string name = null, content = null, version = null;
            int? size = null, rows = null, cols = null;

            foreach (string attr in attributes)
            {
                string[] pair = attr.Split('=');

                if (pair[0] == "name") name = pair[1];
                else if (pair[0] == "content") content = pair[1];
                else if (pair[0] == "size") size = int.Parse(pair[1]);
                else if (pair[0] == "rows") rows = int.Parse(pair[1]);
                else if (pair[0] == "cols") cols = int.Parse(pair[1]);
                else version = pair[1];
            }

            if (IsValidDocument(name))
            {
                docSystem.AddDocument(new ExcelDocument(name, content, size, version, rows, cols));
                Console.WriteLine("Document added: " + name);
            }
        }

        private static void AddAudioDocument(string[] attributes)
        {
            string name = null, content = null;
            int? size = null, length = null, sampleRate = null;

            foreach (string attr in attributes)
            {
                string[] pair = attr.Split('=');

                if (pair[0] == "name") name = pair[1];
                else if (pair[0] == "content") content = pair[1];
                else if (pair[0] == "size") size = int.Parse(pair[1]);
                else if (pair[0] == "length") length = int.Parse(pair[1]);
                else sampleRate = int.Parse(pair[1]);
            }

            if (IsValidDocument(name))
            {
                docSystem.AddDocument(new AudioDocument(name, content, size, length, sampleRate));
                Console.WriteLine("Document added: " + name);
            }
        }

        private static void AddVideoDocument(string[] attributes)
        {
            string name = null, content = null;
            int? size = null, length = null, frameRate = null;

            foreach (string attr in attributes)
            {
                string[] pair = attr.Split('=');

                if (pair[0] == "name") name = pair[1];
                else if (pair[0] == "content") content = pair[1];
                else if (pair[0] == "size") size = int.Parse(pair[1]);
                else if (pair[0] == "length") length = int.Parse(pair[1]);
                else frameRate = int.Parse(pair[1]);
            }

            if (IsValidDocument(name))
            {
                docSystem.AddDocument(new VideoDocument(name, content, size, length, frameRate));
                Console.WriteLine("Document added: " + name);
            }
        }

        private static void ListDocuments()
        {
            foreach (Document d in docSystem.Documents)
            {
                Console.WriteLine(d.ToString());
            }
        }

        private static void EncryptDocument(string name)
        {
            bool found = false;
            foreach (Document d in docSystem.Documents)
            {
                if (d.Name == name)
                {
                    if (!found) found = true;

                    if (d is IEncryptable)
                    {
                        (d as IEncryptable).Encrypt();
                        Console.WriteLine("Document encrypted: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: {0}", name);
                    }
                }
            }

            if (!found) Console.WriteLine("Document not found: {0}", name);
        }

        private static void DecryptDocument(string name)
        {
            bool found = false;
            foreach (Document d in docSystem.Documents)
            {
                if (d.Name == name)
                {
                    found = true;

                    if (d is IEncryptable)
                    {
                        (d as IEncryptable).Decrypt();
                        Console.WriteLine("Document decrypted: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: {0}", name);
                    }
                }
            }

            if (!found) Console.WriteLine("Document not found: {0}", name);
        }

        private static void EncryptAllDocuments()
        {
            bool hasEncryptionDocs = false;

            foreach (Document d in docSystem.Documents)
            {
                if (d is IEncryptable)
                {
                    if (!hasEncryptionDocs)
                    {
                        Console.WriteLine("All documents encrypted");
                        hasEncryptionDocs = true;
                    }
                    (d as IEncryptable).Encrypt();
                }
            }

            if (!hasEncryptionDocs) Console.WriteLine("No encryptable documents found");
        }

        private static void ChangeContent(string name, string content)
        {
            bool found = false;

            foreach (Document d in docSystem.Documents)
            {
                if (d.Name == name)
                {
                    if (!found) found = true;

                    if (d is IEditable)
                    {
                        (d as IEditable).ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: {0}", name);
                    }
                }
            }

            if (!found) Console.WriteLine("Document not found: {0}", name);
        }
    }
}


