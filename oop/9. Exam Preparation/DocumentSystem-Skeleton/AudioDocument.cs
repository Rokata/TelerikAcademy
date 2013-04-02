using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        private int? sampleRate;

        public int? SampleRate
        {
            get { return sampleRate; }
        }

        public AudioDocument(string name, string content = null, int? size = null, int? length = null, int? sampleRate = null)
            : base(name, content, size, length)
        {
            this.sampleRate = sampleRate;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("AudioDocument[" + this.GetPropertiesString());
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]");
            return builder.ToString();
        }
    }
}
