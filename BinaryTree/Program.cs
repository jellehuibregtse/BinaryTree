using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace BinaryTree
{
    public class BinaryTree
    {
        /// <summary>
        /// Node data structure representing a node in a binary tree.
        /// </summary>
        public class Node
        {
            public readonly int Data;
            public Node Left, Right;

            public Node(int data)
            {
                Data = data;
                Left = Right = null;
            }
        }
        public readonly Node Root;

        public BinaryTree(IEnumerable<int> tree)
        {
            // Create the node structure using insertion
            var enumerable = tree.ToList();
            Root = new Node(enumerable.FirstOrDefault());
            enumerable.RemoveAt(0);

            foreach (var i in enumerable)
                Insert(Root, i);
        }

        /// <summary>
        /// Inserts the value in the tree
        /// </summary>
        /// <param name="root">The root node of the tree.</param>
        /// <param name="value">Value to be inserted in the tree.</param>
        public void Insert(Node root, int value)
        {
            if (root.Left == null)  root.Left = new Node(value);
            else if (root.Right == null) root.Right = new Node(value);
            else Insert(root.Left, value);
        }

        private int Height(Node node)
        {
            if (node == null) return 0;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private void PrintLevel(Node root, int height, int level)
        {
            if (height == level && root != null)
                Console.WriteLine(root.Data);

            if (level > height) return;

            if (root?.Left != null) PrintLevel(root.Left, height, level + 1);
            if (root?.Right != null) PrintLevel(root.Right, height, level + 1);
        }
        
        public void PrintLevelOrder(Node root)
        {
            var height = Height(root);
            for (var i = 0; i < height; i++)
                PrintLevel(root, i, 0);
        }

        public void PrintDepthOrder(Node node)
        {
            if (node == null) return;

            Console.WriteLine(node.Data);

            if (node.Left != null) PrintDepthOrder(node.Left);
            if (node.Right != null) PrintDepthOrder(node.Right);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var binaryTree = new BinaryTree(new[] {1, 2, 3, 4, 5});
            Console.WriteLine("Breath-first:");
            binaryTree.PrintLevelOrder(binaryTree.Root);
            Console.WriteLine("\nDepth-first:");
            binaryTree.PrintDepthOrder(binaryTree.Root);
        }
    }
}