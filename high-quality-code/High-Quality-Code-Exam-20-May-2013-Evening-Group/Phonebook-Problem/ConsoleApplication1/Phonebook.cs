using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace PhonebookApp
{
    public class Phonebook : IPhonebookRepository
    {
        private OrderedSet<PhonebookEntry> entriesSorted = new OrderedSet<PhonebookEntry>();
        private Dictionary<string, PhonebookEntry> namesDictionary = new Dictionary<string, PhonebookEntry>();
        private MultiDictionary<string, PhonebookEntry> phonesDictionary = new MultiDictionary<string, PhonebookEntry>(false);

        public Dictionary<string, PhonebookEntry> NamesDictionary
        {
            get { return namesDictionary; }
        }

        /// <summary>Adds new phone to the phonebook.</summary> 
        /// <param name="name">The name of the owner to whom the list of numbers will be associated with.</param>
        /// <param name="phoneNumbers">The list of numbers associated with the owner.</param>
        /// <returns>The method returns true if the name is already in the phonebook and false if not.</returns>
        /// <exception cref="System.NullReferenceException">Throws NullReference exception on name or numbers list being null.</exception>
        /// <remarks>
        /// The name might already exist. In this case the list of numbers is merged with the list in the phonebook leaving
        /// only unique numbers in it. If it doesn't exist a new entry is created and all numbers are added.
        /// </remarks>
        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            string nameToLower = name.ToLowerInvariant();
            PhonebookEntry entry;
 
            bool phoneExists = this.namesDictionary.TryGetValue(nameToLower, out entry);

            if (!phoneExists)
            {
                entry = new PhonebookEntry(); 
                entry.Name = name;
                entry.PhoneNumbers = new SortedSet<string>(); 
                this.namesDictionary.Add(nameToLower, entry);
                this.entriesSorted.Add(entry);
            }
            
            foreach (var number in phoneNumbers)
            {
                this.phonesDictionary.Add(number, entry);
            }

            entry.PhoneNumbers.UnionWith(phoneNumbers);
            return phoneExists;
        }

        /// <summary>Changes a number with a new one.</summary> 
        /// <param name="oldNumber">The number being replaced.</param>
        /// <param name="newNumber">The new number.</param>
        /// <returns>The method returns the count of the numbers changed.</returns>
        /// <exception cref="System.NullReferenceException">Throws NullReference exception on either of the numbers being null.</exception>
        /// <remarks>
        /// The method does not allow oldNumber and newNumber to be equal. If the oldNumber is not found then nothing is changed.
        /// If oldNumber is being replaced with an existing number this will reflect the namesDictionary and no duplicated will be allowed 
        /// there either. This is covered in the ChangePhone_OldBeingReplacedWithExisting test.
        /// </remarks>
        public int ChangePhone(string oldNumber, string newNumber)
        {
            if (oldNumber == newNumber)
            {
                return 0;
            }

            var oldNumberEntries = this.phonesDictionary[oldNumber].ToList(); 
            
            foreach (var entry in oldNumberEntries)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                this.phonesDictionary.Remove(oldNumber, entry);
                entry.PhoneNumbers.Add(newNumber); 
                this.phonesDictionary.Add(newNumber, entry);
            }

            return oldNumberEntries.Count;
        }

        /// <summary>Lists phonebook entries from the phonebook.</summary> 
        /// <param name="startIndex">The index where the retrieval of numbers will start.</param>
        /// <param name="count">The number of entries to be retrieved.</param>
        /// <returns>Returns an array of sorted entries by name.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// System.ArgumentOutOfRangeException is thrown if startIndex is outside of the namesDictionary bounds
        /// or if there aren't so many elements starting from the specified position. 
        /// </exception>
        public PhonebookEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.namesDictionary.Count) 
            {
                throw new ArgumentOutOfRangeException("Index was out of phonebook's range.");
            }

            PhonebookEntry[] enrtiesSelected = new PhonebookEntry[count];

            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                PhonebookEntry entry = this.entriesSorted[i];
                enrtiesSelected[i - startIndex] = entry;
            }

            return enrtiesSelected;
        }
    }
}
