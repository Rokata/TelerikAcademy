using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class MultimediaDocument : BinaryDocument
    {
        private int? length;

        public int? Length
        {
            get { return length; }
        }

        public MultimediaDocument(string name, string content = null, int? size = null, int? length = null)
            : base(name, content, size)
        {
            this.length = length;
        }
    }
}
