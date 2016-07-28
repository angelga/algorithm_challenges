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
    }
}
