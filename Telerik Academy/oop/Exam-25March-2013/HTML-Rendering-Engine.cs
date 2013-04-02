using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{  
	public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }
	
	public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }
	
	public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }
	
	public class HTMLElement : IElement
    {
        private string name;
        private string content;
        private List<IElement> childElements;

        public string Name
        {
            get { return name; }
        }

        public string TextContent
        {
            get { return content; }
            set { content = value; }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return childElements; }
        }

        public HTMLElement(string name = null, string content = null)
        {
            this.name = name;
            this.content = content;
            this.childElements = new List<IElement>();
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.name != null) output.Append("<" + Name + ">");

            if (this.content != null) output.Append(TextContent);

            if (childElements.Count > 0)
            {
                foreach (IElement el in childElements)
                {
                    if (el is TableElement) output.Append((el as TableElement).ToString());
                    else
                    {
                        if (el.Name != null) output.Append("<" + el.Name + ">");
                        if (el.TextContent != null)
                        {
                            if (ContainsSpecialChars(el.TextContent)) output.Append(GetEscapedContent(el.TextContent)); 
                            else output.Append(el.TextContent);
                        }
                        if (el.Name != null) output.Append("</" + el.Name + ">");
                    }
                }
            }

            if (this.name != null) output.Append("</" + Name + ">");
        }

        public bool ContainsSpecialChars(string input)
        {
            if (input == null) throw new ArgumentNullException();

            if ((input.IndexOf('<') > -1) || (input.IndexOf('>') > -1) || (input.IndexOf('&') > -1))
            {
                return true;
            }
            return false;
        }

        public string GetEscapedContent(string input)
        {
            if (input == null) throw new ArgumentNullException();

            input = input.Replace(">", "&gt;").Replace("<", "&lt;");

            StringBuilder output = new StringBuilder();
            string[] items = input.Split(' ');

            foreach (var item in items)
            {
                if (item.Contains("&") && !item.Contains("&lt;") && !item.Contains("&gt;"))
                {
                    output.Append(item.Replace("&", "&amp;") + " ");
                }
                else
                {
                    output.Append(item + " ");
                }
            }
            output.Remove(output.Length - 1, 1);
            return output.ToString();

            //return input.Replace(" & ", " &amp; ").Replace(">", "&gt;").Replace("<", "&lt;");
        }

        public override string ToString()
        {
            StringBuilder element = new StringBuilder();
            this.Render(element);
            return element.ToString();
        }
    }
	
	public class TableElement : HTMLElement, ITable
    {
        private int rows;
        private int cols;
        private IElement[,] childElements;

        public int Rows
        {
            get { return rows; }
        }

        public int Cols
        {
            get { return cols; }
        }

        public TableElement(int rows, int cols)
            : base("table")
        {
            this.rows = rows;
            this.cols = cols;
            this.childElements = new IElement[rows, cols];
        }
		
		public new void AddElement(IElement element)
        {
            throw new ArgumentNullException();
        }

        public override void Render(StringBuilder output)
        {
            if (output == null) throw new ArgumentNullException();

            output.Append("<table>");
            string currentName = String.Empty, currentContent = String.Empty;

            for (int i = 0; i < Rows; i++)
            {
                output.Append("<tr>");
                for (int j = 0; j < Cols; j++)
                {
                    currentName = this[i, j].Name;
                    currentContent = this[i, j].TextContent;

                    output.Append("<td>");

                    if (currentName != null) output.Append("<" + currentName + ">");

                    if (currentContent != null)
                    {
                        if (ContainsSpecialChars(currentContent)) output.Append(GetEscapedContent(currentContent));
                        else output.Append(currentContent);
                    }

                    if (currentName != null) output.Append("</" + this[i, j].Name + ">");

                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public IElement this[int row, int col]
        {
            get { return this.childElements[row, col]; }
            set { this.childElements[row, col] = value; }
        }

        public override string ToString()
        {
            StringBuilder element = new StringBuilder();
            this.Render(element);
            return element.ToString();
        }
    }
	
	public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new TableElement(rows, cols);
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
