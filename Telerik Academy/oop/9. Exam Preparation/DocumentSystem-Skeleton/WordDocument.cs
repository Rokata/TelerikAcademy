using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        private int? chars;

        public int? Chars
        {
            get { return chars; }
        }

        public WordDocument(string name, string content = null, int? size = null, string version = null, int? chars = null)
            : base(name, content, size, version)
        {
            this.chars = chars;
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override string ToString()
        {
            if (IsEncrypted == true)
            {
                return "WordDocument[encrypted]";
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("WordDocument[" + this.GetPropertiesString());
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]");
            return builder.ToString();
        }
    }
}
