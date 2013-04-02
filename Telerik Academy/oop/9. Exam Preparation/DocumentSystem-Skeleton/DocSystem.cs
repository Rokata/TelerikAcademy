using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocSystem
    {
        private IList<Document> documents;

        public DocSystem()
        {
            this.documents = new List<Document>();
        }

        public IList<Document> Documents
        {
            get { return documents; }
        }

        public void AddDocument(Document d)
        {
            documents.Add(d);
        }
    }
}
