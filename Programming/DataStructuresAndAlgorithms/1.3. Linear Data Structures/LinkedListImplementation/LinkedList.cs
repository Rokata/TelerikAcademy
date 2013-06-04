using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListImplementation
{
    public class LinkedList<T>
    {
        public ListItem<T> FirstElement { get; private set; }
        public int Count { get; private set; }

        public void Add(ListItem<T> element)
        {
            Count++;

            if (FirstElement == null)
            {
                this.FirstElement = element;
                return;
            }

            var current = this.FirstElement;

            while (current.NextItem != null)
            {
                current = current.NextItem;
            }

            current.NextItem = element;
        }

        public ListItem<T> Find(T value)
        {
            for (var current = FirstElement; current != null; )
            {
                if (current.Value.Equals(value))
                    return current;

                current = current.NextItem;
            }

            return null;
        }

        public void Remove(T value)
        {
            if (FirstElement.Value.Equals(value))
            {
                FirstElement.Value = FirstElement.NextItem.Value;
                var afterSecond = FirstElement.NextItem.NextItem;
                FirstElement.NextItem.NextItem = null;
                FirstElement.NextItem = afterSecond;
                Count--;
                return;
            }

            var beforeRemoved = this.FirstElement;

            while (beforeRemoved != null && !beforeRemoved.NextItem.Value.Equals(value))
            {
                beforeRemoved = beforeRemoved.NextItem;
            }

            if (beforeRemoved == null)
                throw new ArgumentException("Element for removal was not found.");

            var forRemoval = beforeRemoved.NextItem;

            var temp = forRemoval.NextItem;
            forRemoval.NextItem = null;
            beforeRemoved.NextItem = temp;
            Count--;
        }

        public void Reverse()
        {
            for (int changes = Count - 1; changes > 0; changes--)
            {
                var current = FirstElement;

                for (int i = 0; i < changes; i++)
                {
                    T temp = current.Value;
                    current.Value = current.NextItem.Value;
                    current.NextItem.Value = temp;
                    current = current.NextItem;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            var current = FirstElement;

            while (current != null)
            {
                result.AppendFormat("{0} ", current.Value);
                current = current.NextItem;
            }

            return result.ToString();
        }
    }
}
