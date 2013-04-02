using System;
using System.Text;
using System.Reflection;

namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        private string charset;

        public string Charset
        {
            get { return charset; }
        }

        public TextDocument(string name, string content = null, string charset = null) : base(name, content)
        {
            this.charset = charset;
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("TextDocument[" + this.GetPropertiesString());
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]");
            return builder.ToString();
        }
    }
}
