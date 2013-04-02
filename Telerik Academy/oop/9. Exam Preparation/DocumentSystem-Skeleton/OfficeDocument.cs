using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DocumentSystem
{
    public class OfficeDocument : BinaryDocument, IEncryptable
    {
        private string version;
        private bool isEncrypted;

        public bool IsEncrypted
        {
            get { return isEncrypted; }
        }

        public string Version
        {
            get { return version; }
        }

        public OfficeDocument(string name, string content = null, int? size = null, string version = null)
            : base(name, content, size)
        {
            this.version = version;
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
    }
}
