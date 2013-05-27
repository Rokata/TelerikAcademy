using System;
using System.Text;
using System.Collections;

namespace GenericList
{
    class GenericList<T> where T : IComparable<T>
    {
        private T[] elements;
        private int capacity;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public GenericList(int capacity)
        {
            this.elements = new T[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i > count) throw new IndexOutOfRangeException();
                return elements[i];
            }
            set 
            {
                if (i < 0 || i > count) throw new IndexOutOfRangeException();
                elements[i] = value; 
            }
        }

        public void Add(T t)
        {
            if (count == capacity) CopyElements();

            elements[count] = t;
            count++;
        }

        public void InsertAt(int pos, T value)
        {
            if (pos < 0 || pos > count) throw new IndexOutOfRangeException();
            if (count == capacity) CopyElements();

            T val = elements[pos];

            for (int i = pos + 1; i <= count; i++)
            {
                T temp = elements[i];
                elements[i] = val;
                val = temp;
            }

            elements[pos] = value;
            count++;
        }

        public void RemoveAt(int pos)
        {
            if (pos < 0 || pos >= count) throw new IndexOutOfRangeException();

            for (int i = pos; i < count - 1; i++) elements[i] = elements[i + 1];
            count--;
        }

        public void Clear()
        {
            elements = new T[1];
            capacity = 1;
            count = 0;
        }

        private void CopyElements()
        {
            T[] temp = (T[])elements.Clone();

            elements = new T[capacity << 1];

            for (int i = 0; i < capacity; i++) elements[i] = temp[i];

            this.capacity = capacity << 1;
        }

        public T Min()
        {
            T min = elements[0];

            for (int i=0; i<count; i++) if (elements[i].CompareTo(min) < 0) min = elements[i];

            return min;
        }

        public T Max()
        {
            T max = elements[0];
            for (int i = 0; i < count; i++) if (elements[i].CompareTo(max) > 0) max = elements[i];

            return max;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");

            for (int i=0; i < count; i++) builder.Append(elements[i] + ", ");
            if (count > 0) builder.Remove(builder.Length - 2, 2);
            builder.Append("]");

            return builder.ToString();
        }
    }
}
