using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        private int? rows;
        private int? cols;

        public int? Rows
        {
            get { return rows; }
        }

        public int? Cols
        {
            get { return cols; }
        }

        public ExcelDocument(string name, string content = null, int? size = null, string version = null, int? rows = null, int? cols = null)
            : base(name, content, size, version)
        {
            this.rows = rows;
            this.cols = cols;
        }

        public override string ToString()
        {
            if (IsEncrypted == true)
            {
                return "ExcelDocument[encrypted]";
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("ExcelDocument[" + this.GetPropertiesString());
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]");
            return builder.ToString();
        }
    }
}
