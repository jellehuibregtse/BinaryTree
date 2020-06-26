using System;
using System.Collections.Generic;
using System.Linq;

// Assignment "Binaire Boom" Quaterfall.
// Author: Jelle Huibregtse
// Note:   I did not structure this most efficiently or according to usual C# or .NET guidelines.
//         I just made sure the functionality of the algorithm is there.

namespace BinaryTree
{
    /// <summary>
    ///     This class represents the tree data structure.
    /// </summary>
    public class BinaryTree
    {
        public readonly Node Root;

        public BinaryTree(Node root)
        {
            Root = root;
        }

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
        ///     Inserts the value in the tree
        /// </summary>
        /// <param name="root">The root node of the tree.</param>
        /// <param name="value">Value to be inserted in the tree.</param>
        private void Insert(Node root, int value)
        {
            if (root.Left == null) root.Left = new Node(value);
            else if (root.Right == null) root.Right = new Node(value);
            else Insert(root.Left, value);
        }

        /// <summary>
        ///     Calculate the height of the node within the tree, if the root is passed through the height of the tree is
        ///     calculated.
        /// </summary>
        /// <param name="node">Node of which to calculate the height.</param>
        /// <returns>The height of the node within the tree as an integer.</returns>
        private int Height(Node node)
        {
            if (node == null) return 0;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        /// <summary>
        ///     Prints a given level of the tree.
        /// </summary>
        /// <param name="node">The node of the tree.</param>
        /// <param name="height">The height of the node of the tree</param>
        /// <param name="level">The level which to calculate.</param>
        private void PrintLevel(Node node, int height, int level)
        {
            if (height == level && node != null)
                Console.WriteLine(node.Data);

            if (level > height) return;

            if (node?.Left != null) PrintLevel(node.Left, height, level + 1);
            if (node?.Right != null) PrintLevel(node.Right, height, level + 1);
        }

        /// <summary>
        ///     Prints the tree using breadth-first.
        /// </summary>
        /// <param name="root">The node of the tree (usually the root).</param>
        public void PrintLevelOrder(Node root)
        {
            var height = Height(root);
            for (var i = 0; i < height; i++)
                PrintLevel(root, i, 0);
        }

        /// <summary>
        ///     Prints the tree using depth-first.
        ///     (This is what I thought of first, so decided to keep it in here.)
        /// </summary>
        /// <param name="node">The node of the tree (usually the root).</param>
        public void PrintDepthOrder(Node node)
        {
            if (node == null) return;

            Console.WriteLine(node.Data);

            if (node.Left != null) PrintDepthOrder(node.Left);
            if (node.Right != null) PrintDepthOrder(node.Right);
        }

        /// <summary>
        ///     Node data structure representing a node in a binary tree.
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
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Using Insert
            var binaryTree = new BinaryTree(new[] {1, 2, 3, 4, 5});

            Console.WriteLine("[1] Breath-first:");
            binaryTree.PrintLevelOrder(binaryTree.Root);
            Console.WriteLine("\n[1] Depth-first:");
            binaryTree.PrintDepthOrder(binaryTree.Root);

            Console.WriteLine();

            // Manual
            var tree = new BinaryTree.Node(1);
            tree.Left = new BinaryTree.Node(2);
            tree.Right = new BinaryTree.Node(3);
            tree.Right.Left = new BinaryTree.Node(4);
            tree.Right.Right = new BinaryTree.Node(5);

            var secondBinaryTree = new BinaryTree(tree);
            Console.WriteLine("[2] Breath-first:");
            secondBinaryTree.PrintLevelOrder(binaryTree.Root);
            Console.WriteLine("\n[2] Depth-first:");
            secondBinaryTree.PrintDepthOrder(binaryTree.Root);
        }
    }
}