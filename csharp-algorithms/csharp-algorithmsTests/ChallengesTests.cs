using Microsoft.VisualStudio.TestTools.UnitTesting;
using csharp_algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpLibrary;

namespace csharp_algorithms.Tests
{
    [TestClass()]
    public class ChallengesTests
    {
        [TestMethod()]
        public void IsBinaryTreeMirrored_NullTree()
        {
            Assert.IsFalse(Challenges.IsBinaryTreeMirrored(null));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_RootOnly()
        {
            Assert.IsTrue(Challenges.IsBinaryTreeMirrored(new Node(5)));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_OneLevelOneChild()
        {
            Node root = new Node(5);
            root.Left = new Node(4);

            Assert.IsFalse(Challenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_OneLevelMirrored()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);

            Assert.IsTrue(Challenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_OneLevelUnmirrored()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);

            Assert.IsFalse(Challenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_TwoLevelsMirroredFull()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);
            root.Left.Left = new Node(3);
            root.Left.Right = new Node(5);
            root.Right.Left = new Node(5);
            root.Right.Right = new Node(3);

            Assert.IsTrue(Challenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_TwoLevelsMirroredIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);
            root.Left.Left = new Node(3);
            root.Right.Right = new Node(3);

            Assert.IsTrue(Challenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_TwoLevelsUnmirroredIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);
            root.Left.Left = new Node(3);

            Assert.IsFalse(Challenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_TwoLevelsUnmirroredComplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);
            root.Left.Left = new Node(3);
            root.Left.Right = new Node(6);
            root.Right.Left = new Node(6);
            root.Right.Right = new Node(1);

            Assert.IsFalse(Challenges.IsBinaryTreeMirrored(root));
        }
    }
}