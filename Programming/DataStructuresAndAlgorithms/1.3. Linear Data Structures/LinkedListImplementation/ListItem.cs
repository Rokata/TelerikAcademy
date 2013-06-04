using System;
using System.Collections.Generic;

namespace LinkedListImplementation
{
    public class ListItem<T>
    {
        public T Value { get; set; }
        public ListItem<T> NextItem { get; set; }
    }
}
