using System;
using System.Text;
using System.Reflection;

namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IEncryptable
    {
        private int? pages;
        private bool isEncrypted;

        public bool IsEncrypted
        {
            get { return isEncrypted; }
        }

        public int? Pages
        {
            get { return pages; }
        }

        public PDFDocument(string name, string content = null, int? size = null, int? pages = null)
            : base(name, content, size)
        {
            this.pages = pages;
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        protected override string GetPropertiesString()
        {
            PropertyInfo[] props = GetSortedProperties();
            StringBuilder propsBuilder = new StringBuilder();

            foreach (PropertyInfo prop in props)
            {
                var value = prop.GetValue(this, null);

                if (value != null && prop.Name != "IsEncrypted")
                {
                    propsBuilder.Append(prop.Name.ToLower() + "=" + value + ";");
                }
            }

            return propsBuilder.ToString();
        }

        public override string ToString()
        {
            if (IsEncrypted == true)
            {
                return "PDFDocument[encrypted]";
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("PDFDocument[" + this.GetPropertiesString());
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]");
            return builder.ToString();
        }
    }
}
