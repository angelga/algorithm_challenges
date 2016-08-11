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
    public class TreeChallenges
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

        /// <summary>
        /// Given a binary tree, modify the tree such that each node's right child points
        /// to the next node in horizontal traversal, such that all left nodes are empty.
        /// For example this tree:
        ///     8
        ///   1   2
        ///  2 3 4 5
        ///  
        /// Would look like:
        ///     8
        ///      1
        ///       2
        ///        2
        ///         3
        ///          4
        ///           5
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Node TraverseAndLinkTreeHorizontally(Node root)
        {
            if (root == null)
            {
                return root;
            }

            Node tail = root;
            Queue<Node> nodes = new Queue<Node>();
            if (tail.Left != null)
            {
                nodes.Enqueue(tail.Left);
            }

            if (tail.Right != null)
            {
                nodes.Enqueue(tail.Right);
            }

            while (nodes.Count > 0)
            {
                tail.Left = null;
                tail.Right = nodes.Dequeue();
                tail = tail.Right;

                if (tail.Left != null)
                {
                    nodes.Enqueue(tail.Left);

                }
                
                if (tail.Right != null)
                {
                    nodes.Enqueue(tail.Right);
                }
            }

            return root;
        }

        /// <summary>
        /// Helper method adds node to stack if node not empty
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="node"></param>
        private static void PushIfNotNull(Stack<Node> stack, Node node)
        {
            if (node != null)
            {
                stack.Push(node);
            }
        }

        /// <summary>
        /// Given a binary tree, return the string representation of comma separated leaf contents
        /// in zigzag order.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IEnumerable<Node> TraverseZigzag(Node root)
        {
            if (root == null)
            {
                yield break;
            }

            var workingStack = new Stack<Node>();
            var storageStack = new Stack<Node>();
            workingStack.Push(root);
            
            bool leftToRight = true;

            while (workingStack.Count > 0)
            {
                while (workingStack.Count > 0)
                {
                    Node head = workingStack.Pop();
                    yield return head;
                    if (leftToRight)
                    {
                        PushIfNotNull(storageStack, head.Left);
                        PushIfNotNull(storageStack, head.Right);
                    }
                    else
                    {
                        PushIfNotNull(storageStack, head.Right);
                        PushIfNotNull(storageStack, head.Left);
                    }
                }

                var temp = workingStack;
                workingStack = storageStack;
                storageStack = temp;
                leftToRight = !leftToRight;
            }
        }

        /// <summary>
        /// Given a binary search tree, perform in order traversal. 
        /// That is, left leaf nodes, root, finally right leaf nodes.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IEnumerable<Node> TraverseInOrderBST(Node root)
        {
            if (root == null)
            {
                yield break;
            }

            foreach (var node in TraverseInOrderBST(root.Left))
            {
                yield return node;
            }

            yield return root;
            foreach (var node in TraverseInOrderBST(root.Right))
            {
                yield return node;
            }
        }

        /// <summary>
        /// Given a binary search tree, find the nth smallest item.
        /// Return null if not found (there are less items in the tree than nth provided,
        /// or nth is not positive).
        /// It is assumed root is a BST.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nth"></param>
        /// <returns></returns>
        public static Node FindNthSmallest(Node root, int nth)
        {
            if (nth < 1)
            {
                return null;
            }

            var count = 0;
            foreach (var node in TraverseInOrderBST(root))
            {
                count++;
                if (count == nth)
                {
                    return node;
                }
            }

            return null;
        }

        /// <summary>
        /// Given a binary search tree, find the nth smallest item.
        /// root is assumed to be a binary search tree.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nth"></param>
        /// <returns></returns>
        public static Node FindNthSmallestWRef(Node root, ref int nth)
        {
            if (root == null || nth <= 0)
            {
                return null;
            }

            Node node = FindNthSmallestWRef(root.Left, ref nth);
            if (node != null)
            {
                return node;
            }

            if (--nth == 0)
            {
                return root;
            }

            return FindNthSmallestWRef(root.Right, ref nth);
        }

        /// <summary>
        /// Given a binary (not search) tree, find the node having value.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Node FindNodeInBST(Node root, int value)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Data == value)
            {
                return root;
            }

            Node node = FindNodeInBST(root.Left, value);
            if (node != null)
            {
                return node;
            }

            return FindNodeInBST(root.Right, value);
        }

        /// <summary>
        /// Given a binary search tree, insert node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="bst"></param>
        public static void InsertNodeToBST(Node node, Node bst)
        {
            if (node == null || bst == null)
            {
                return;
            }

            if (node.Data == bst.Data)
            {
                throw new ArgumentException("Duplicate value found in binary search tree.");
            }

            if (bst.Data > node.Data)
            {
                if (bst.Left == null)
                {
                    bst.Left = node;
                }
                else
                {
                    InsertNodeToBST(node, bst.Left);
                }
            }
            else
            {
                if (bst.Right == null)
                {
                    bst.Right = node;
                }
                else
                {
                    InsertNodeToBST(node, bst.Right);
                }
            }
        }
    }
}
