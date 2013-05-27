using System;
using System.Collections.Generic;
using System.Text;

namespace PhonebookApp
{
    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string nameOriginalForm; 
        private string nameToLower;
        private SortedSet<string> phoneNumbers;

        public string Name
        {
            get
            {
                return this.nameOriginalForm;
            }
            set
            {
                this.nameOriginalForm = value;
                this.nameToLower = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhoneNumbers
        {
            get { return this.phoneNumbers; }
            set { this.phoneNumbers = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(); 
            output.Clear(); 
            output.AppendFormat("[{0}: ", this.Name);

            output.Append(string.Join(", ", this.PhoneNumbers));

            output.Append(']');
            return output.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            return this.nameToLower.CompareTo(other.nameToLower);
        }
    }
}
