using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLibrary;

namespace csharp_algorithms
{
    /// <summary>
    /// Collection of solutions to coding challenges and interview questions.
    /// </summary>
    public class Challenges
    {
        /// <summary>
        /// Given a binary tree, determine if tree is mirrored.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBinaryTreeMirrored(Node root)
        {
            if (root == null)
            {
                return false;
            }

            return IsbinTreeMirrored(root.Left, root.Right);
        }

        /// <summary>
        /// Given two nodes, ensure they are ether both null, or both have same Data.
        /// If so continue checking outer children and inner children recursively.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static bool IsbinTreeMirrored(Node left, Node right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null || left.Data != right.Data)
            {
                return false;
            }

            return IsbinTreeMirrored(left.Left, right.Right) && IsbinTreeMirrored(left.Right, right.Left);
        }

        /// <summary>
        /// Get the depth (levels) of a binary tree. It's assumed that:
        /// 1. Null root = depth of zero
        /// 2. Root only (no children) = depth of 1
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int DepthBinaryTree(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(DepthBinaryTree(root.Left), DepthBinaryTree(root.Right));
        }

        /// <summary>
        /// Given a binary tree, traverse the nodes in horizontal, left to right mode.
        /// For instance:
        ///     8
        ///   1   2
        ///  2 3 4 5
        ///  
        ///  Output: 8 1 2 2 3 4 5
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static string TraverseTreeHorizontally(Node root)
        {
            if (root == null)
            {
                return string.Empty;
            }

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);

            return TraverseTreeHor(nodes);
        }

        /// <summary>
        /// Use Queue data structure to visit nodes horizontally in a binary tree.
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private static string TraverseTreeHor(Queue<Node> nodes)
        {
            List<int> result = new List<int>();

            while (nodes.Count > 0)
            {
                Node last = nodes.Dequeue();
                result.Add(last.Data);
                if (last.Left != null)
                {
                    nodes.Enqueue(last.Left);
                }

                if (last.Right != null)
                {
                    nodes.Enqueue(last.Right);
                }
            }

            return string.Join(", ", result);
        }
    }
}
