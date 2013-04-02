using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class BinaryDocument : Document
    {
        private int? size;

        public int? Size
        {
            get { return size; }
        }

        public BinaryDocument(string name, string content = null, int? size = null) : base(name, content)
        {
            this.size = size;
        }
    }
}
