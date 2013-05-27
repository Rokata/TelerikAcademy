using System;

namespace TreeDataStructure
{
    class TreeDataStructure
    {
        static void Main()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.AddElement(13);
            tree.AddElement(17);
            tree.AddElement(101);
            tree.AddElement(44);
            tree.AddElement(9);
            tree.AddElement(11);

            BinarySearchTree<int> tree2 = (BinarySearchTree<int>)tree.Clone();
            //tree2.AddElement(45);
            //tree2.AddElement(99);
            
            Console.WriteLine("Tree: " + tree.ToString());
            Console.WriteLine("Tree2: " + tree2.ToString());
            Console.WriteLine("Tree equals Tree2: " + tree.Equals(tree2));
            Console.WriteLine("Tree == Tree2: " + (tree == tree2));
            Console.WriteLine("Tree != Tree2: " + (tree != tree2));

            Console.Write("Traverse with foreach: ");
            foreach (TreeNode<int> item in tree)
                Console.Write(item.Value + " ");

            Console.WriteLine();

            Console.WriteLine("Tree hash: {0}", tree.GetHashCode());
            Console.WriteLine("Tree2 hash: {0}", tree2.GetHashCode());
        }
    }
}
