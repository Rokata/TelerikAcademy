using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HTMLRenderer
{
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

            foreach (string item in items)
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
        }

        public override string ToString()
        {
            StringBuilder element = new StringBuilder();
            this.Render(element);
            return element.ToString();
        }
    }
}
