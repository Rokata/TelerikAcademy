using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Problem04_Free_Content
{
    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> urls;
        private OrderedMultiDictionary<string, IContent> titles;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.titles = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.urls = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        /// <summary>
        /// Adds content object to a specified catalog.
        /// </summary> 
        /// <param name="content">The object being added to the catalog.</param>
        /// <exception cref="System.ArgumentException">Throws ArgumentException on null value.</exception>
        public void Add(IContent content)
        {
            if (content == null)
            {
                throw new ArgumentException("No null values are allowed.");
            }

            this.titles.Add(content.Title, content);
            this.urls.Add(content.URL, content);
        }

        /// <summary>
        /// Gets IEnumerable collection of IContent objects matching specified title.
        /// </summary> 
        /// <param name="title">The title to search for.</param>
        /// <param name="numberOfContentElementsToList">
        /// The desired results count. If more objects are matched then the first numberOfContentElementsToList
        /// objects are returned.
        /// </param>
        /// <exception cref="System.ArgumentException">Throws on empty title value or negative elements count.</exception>
        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            if (numberOfContentElementsToList < 1)
            {
                throw new ArgumentException("Number of elements should not be negative.");
            }
            if (string.IsNullOrEmpty(title)) 
            {
                throw new ArgumentException("Content title should not be null or empty.");    
            }

            IEnumerable<IContent> contentToList = from content in this.titles[title] select content;
            return contentToList.Take(numberOfContentElementsToList);
        }

        /// <summary>
        /// Updates elements in a catalog matching certain url with a new one.
        /// </summary> 
        /// <param name="oldUrl">The URL to search for.</param>
        /// <param name="newUrl">
        /// The new URL which will be assigned to the elements
        /// matching oldUrl. Those elements will be associated to the new key and the old key will be 
        /// removed.
        /// </param>
        /// <exception cref="System.ArgumentException">Throws it on empty or null url values.</exception>
        public int UpdateContent(string oldUrl, string newUrl)
        {
            if (string.IsNullOrEmpty(oldUrl) || string.IsNullOrEmpty(newUrl))
            {
                throw new ArgumentException("Old URL and new URL cannot be null.");
            }

            if (oldUrl == newUrl)
            {
                return 0;
            }

            int updatedElements = 0;
            List<IContent> contentToList = this.urls[oldUrl].ToList();

            RemoveFromTitleCollection(ref updatedElements, contentToList);

            this.urls.Remove(oldUrl);

            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
            }

            UpdateCollections(contentToList);
            return updatedElements;
        }

        private void UpdateCollections(List<IContent> contentToList)
        {
            foreach (IContent content in contentToList)
            {
                this.titles.Add(content.Title, content);
                this.urls.Add(content.URL, content);
            }
        }

        private void RemoveFromTitleCollection(ref int updatedElements, List<IContent> contentToList)
        {
            foreach (Content content in contentToList)
            {
                this.titles.Remove(content.Title, content);
                updatedElements++; //increase updatedElements
            }
        }
    }
}
