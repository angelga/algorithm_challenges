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

            List<Node> children = new List<Node>();
            children.Add(root.Left);
            children.Add(root.Right);

            return IsbinTreeMirrored(children);
        }

        private static bool IsbinTreeMirrored(List<Node> children)
        {
            if (children.Count == 0)
            {
                return true;
            }

            for (int i = 0; i < children.Count / 2; i++)
            {
                if (children[i].Data != children[children.Count - 1 - i].Data)
                {
                    return false;
                }
            }

            List<Node> grandChildren = new List<Node>();
            foreach (Node child in children)
            {
                if (child != null)
                {
                    grandChildren.Add(child.Left);
                    grandChildren.Add(child.Right);
                }
            }

            return IsbinTreeMirrored(grandChildren);
        }
    }
}
