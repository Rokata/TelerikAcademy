using System;
using System.IO;
using System.Security;

class ReadFromFile
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the full path of a file: ");
            string fileName = Console.ReadLine();

            string fileContent = File.ReadAllText(fileName);

            Console.WriteLine("\nFile content:\n");
            Console.Write(fileContent);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("String contains only white spaces or invalid characters!");
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine("Path must be less than 248 characters long!");
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine("The specified  directory couldn't be found.");
        }
        catch (IOException e)
        {
            Console.WriteLine("I/O error or file not found.");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Error. The path must point to a file or you don't have enough permissions!");
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine("Invalid path format!");
        }
        catch (SecurityException e)
        {
            Console.WriteLine("You don't have the required permissions.");
        }
        finally
        {
            Console.WriteLine("Exiting application.");
        }
    }
}