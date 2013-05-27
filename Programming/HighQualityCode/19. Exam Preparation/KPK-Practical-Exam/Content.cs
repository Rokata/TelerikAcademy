using System;

namespace Problem04_Free_Content
{
    public class Content : IComparable, IContent
    {
        private string title;
        private string author;
        private Int64 size;
        private string url;
        private ContentType type;
        private string textRepresentation;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentAttributesIndex.Title];
            this.Author = commandParams[(int)ContentAttributesIndex.Author];
            this.Size = Int64.Parse(commandParams[(int)ContentAttributesIndex.Size]);
            this.URL = commandParams[(int)ContentAttributesIndex.Url];
        }

        public string Title 
        {
            get { return title; }
            set { this.title = value; } 
        }

        public string Author 
        {
            get { return this.author; }  
            set { this.author = value; } 
        }

        public Int64 Size 
        {
            get { return this.size; }
            set { this.size = value; } 
        }

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public ContentType Type 
        {
            get { return this.type; }
            set { this.type = value; } 
        }

        public string TextRepresentation 
        {
            get { return this.textRepresentation; }
            set { this.textRepresentation = value; } 
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Cannot compare to null object.");
            }

            Content otherContent = obj as Content;

            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResult;
            }
            else
            {
                throw new ArgumentException("Cannot convert to Content object.");
            }            
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
