using System;
using System.Collections.Generic;

namespace TreeDataStructure
{
    public class TreeNode<T> : IComparable<TreeNode<T>>
        where T : IComparable<T>
    {
        private T value;
        private TreeNode<T> rightChild;
        private TreeNode<T> leftChild;
        private TreeNode<T> parent;

        public TreeNode(T value)
        {
            this.value = value;
            this.rightChild = null;
            this.leftChild = null;
            this.parent = null;
        }

        public TreeNode<T> RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        public TreeNode<T> LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        public TreeNode<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> other = (TreeNode<T>)obj;
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(TreeNode<T> other)
        {
            return this.value.CompareTo(other.value);
        }

    }
}
