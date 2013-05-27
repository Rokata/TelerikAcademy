using System;

class Program
{
    static void Main()
    {
        string URL = "http://www.codeproject.com/Articles/9099/The-30-Minute-Regex-Tutorial";

        string protocol = URL.Substring(0, URL.IndexOf(':', 0));

        int offset = URL.IndexOf(':', 0) + 3;
        int nextSlash = URL.IndexOf('/', offset);

        string server = URL.Substring(offset, nextSlash-offset);
        string resource = URL.Substring(nextSlash);

        Console.WriteLine("Protocol: " + protocol);
        Console.WriteLine("Server: " + server);
        Console.WriteLine("Resource: " + resource);
    }
}
