using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        private int? frameRate;

        public int? FrameRate
        {
            get { return frameRate; }
        }

        public VideoDocument(string name, string content = null, int? size = null, int? length = null, int? frameRate = null)
            : base(name, content, size, length)
        {
            this.frameRate = frameRate;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("VideoDocument[" + this.GetPropertiesString());
            builder.Remove(builder.Length - 1, 1);
            builder.Append("]");
            return builder.ToString();
        }
    }
}
