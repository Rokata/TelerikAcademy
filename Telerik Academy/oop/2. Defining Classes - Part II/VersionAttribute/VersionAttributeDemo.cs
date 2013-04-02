using System;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | 
    AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        private string version;

        public string Version
        {
            get { return version; }
        }

        public VersionAttribute(string version)
        {
            this.version = version;
        }
    }

    [Version("2.11")]
    class Program
    {
        static void Main()
        {
            Type type = typeof(Program);
            object[] allAttributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine("Program.cs ver. {0}", attr.Version);
            }
        }
    }
}
