using System;
using System.Net;
using System.IO;

class DownloadFile
{
    static void Main()
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                Console.Write("Enter URL: ");
                string URL = Console.ReadLine();
                client.DownloadFile(URL, Path.GetFileName(URL));
                Console.WriteLine("File successfully downloaded.");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("The address parameter must not be null!");
            }
            catch (WebException e)
            {
                Console.WriteLine("Error while downloading file.");
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("The method DownloadFile() cannot be called simultaneously on multiple threads.");
            }
            finally
            {
                Console.WriteLine("Bye-bye!");
            }
        }
    }
}
