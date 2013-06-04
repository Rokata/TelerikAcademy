using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TreeDataStructure
{
    public struct BinarySearchTree<T> : ICloneable, IEnumerable<TreeNode<T>>
        where T : IComparable<T>
    {
        private TreeNode<T> root;

        public TreeNode<T> Find(T value)
        {
            return Find(this.root, value);
        }

        private TreeNode<T> Find(TreeNode<T> node, T value)
        {
            int compareTo = value.CompareTo(node.Value);

            if (compareTo == 0)
            {
                return node;
            }

            if (compareTo < 0)
            {
                if (node.LeftChild != null) return Find(node.LeftChild, value);
                else return null;
            }
            else
            {
                if (node.RightChild != null) return Find(node.RightChild, value);
                else return null;
            }
        }

        public void AddElement(T value)
        {
            this.root = AddElement(value, null, root);
        }

        private TreeNode<T> AddElement(T value, TreeNode<T> parentNode, TreeNode<T> node)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                node.Parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node.LeftChild = AddElement(value, node, node.LeftChild);
                }
                else if (compareTo > 0)
                {
                    node.RightChild = AddElement(value, node, node.RightChild);
                }
            }

            return node;
        }

        public void Remove(T value)
        {
            TreeNode<T> nodeToDelete = Find(value);
            if (nodeToDelete == null)
            {
                return;
            }

            Remove(nodeToDelete);
        }

        private void Remove(TreeNode<T> node)
        {
            if (node.LeftChild != null && node.RightChild != null)
            {
                TreeNode<T> replacement = node.RightChild;
                while (replacement.LeftChild != null)
                {
                    replacement = replacement.LeftChild;
                }
                node.Value = replacement.Value;
                node = replacement;
            }

            TreeNode<T> theChild = node.LeftChild != null ?
                    node.LeftChild : node.RightChild;

            if (theChild != null)
            {
                theChild.Parent = node.Parent;

                if (node.Parent == null)
                {
                    root = theChild;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = theChild;
                    }
                    else
                    {
                        node.Parent.RightChild = theChild;
                    }
                }
            }
            else
            {
                if (node.Parent == null)
                {
                    root = null;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = null;
                    }
                    else
                    {
                        node.Parent.RightChild = null;
                    }
                }
            }
        }

        private void AppendNodes(ref StringBuilder builder, TreeNode<T> root)
        {
            if (root == null) return;

            AppendNodes(ref builder, root.LeftChild);
            builder.Append(root.Value);
            builder.Append(" ");
            AppendNodes(ref builder, root.RightChild);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            AppendNodes(ref builder, this.root);
            return builder.ToString();
        }

        public override int GetHashCode()
        {
            int hashCode = 7;

            foreach (TreeNode<T> node in this)
            {
                hashCode ^= node.Value.GetHashCode();
            }
            return hashCode;
        }

        private void CheckEqualNodes(TreeNode<T> node1, TreeNode<T> node2, ref bool equal)
        {
            if (node1 == null && node2 == null) return; // must not compare null nodes

            if ((node1 != null && node2 == null) || (node1 == null && node2 != null) || node1.CompareTo(node2) != 0)
            {
                // obviously null and something aren't equal
                equal = false;
                return;
            }

            CheckEqualNodes(node1.LeftChild, node2.LeftChild, ref equal);
            CheckEqualNodes(node1.RightChild, node2.RightChild, ref equal);
        }

        public override bool Equals(object obj)
        {
            bool equal = true;
            CheckEqualNodes(this.root, ((BinarySearchTree<T>)obj).root, ref equal);
            return equal;
        }

        public static bool operator ==(BinarySearchTree<T> t1, BinarySearchTree<T> t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(BinarySearchTree<T> t1, BinarySearchTree<T> t2)
        {
            return !t1.Equals(t2);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            GetNextNode(root, ref nodes);

            foreach (TreeNode<T> node in nodes)
                yield return node;
        }

        private void GetNextNode(TreeNode<T> node, ref List<TreeNode<T>> nodes)
        {
            if (node == null) return;

            GetNextNode(node.LeftChild, ref nodes);
            nodes.Add(node);
            GetNextNode(node.RightChild, ref nodes);
        }

        public object Clone()
        {
            BinarySearchTree<T> clone = new BinarySearchTree<T>();
            CopyNode(this.root, ref clone);
            return clone;
        }

        private void CopyNode(TreeNode<T> root, ref BinarySearchTree<T> tree)
        {
            if (root == null) return;

            tree.AddElement(root.Value);
            CopyNode(root.LeftChild, ref tree);
            CopyNode(root.RightChild, ref tree);
        }
    }
}
