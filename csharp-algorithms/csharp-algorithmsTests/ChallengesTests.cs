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

        [TestMethod()]
        public void DepthBinTree_Null()
        {
            Assert.AreEqual(0, Challenges.DepthBinaryTree(null));
        }

        [TestMethod()]
        public void DepthBinTree_OneLevel()
        {
            Assert.AreEqual(1, Challenges.DepthBinaryTree(new Node(5)));
        }

        [TestMethod()]
        public void DepthBinTree_TwoLevelIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);

            Assert.AreEqual(2, Challenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void DepthBinTree_TwoLevelComplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);

            Assert.AreEqual(2, Challenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void DepthBinTree_ThreeLevelIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);
            root.Right.Left = new Node(10);

            Assert.AreEqual(3, Challenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void DepthBinTree_ThreeLevelComplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(2);
            root.Right.Left = new Node(8);
            root.Right.Right = new Node(9);

            Assert.AreEqual(3, Challenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void DepthBinTree_FourLevelIncomplete()
        {
            Node root = new Node(5);
            root.Right = new Node(6);
            root.Right.Left = new Node(8);
            root.Right.Left.Right = new Node(9);

            Assert.AreEqual(4, Challenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void TraverseTreeHorizontally_Empty()
        {
            Assert.AreEqual(string.Empty, Challenges.TraverseTreeHorizontally(null));
        }

        [TestMethod()]
        public void TraverseTreeHorizontally_RootOnly()
        {
            Assert.AreEqual("1", Challenges.TraverseTreeHorizontally(new Node(1)));
        }

        [TestMethod()]
        public void TraverseTreeHorizontally_OneLevel()
        {
            Node root = new Node(1);
            root.Right = new Node(2);
            Assert.AreEqual("1, 2", Challenges.TraverseTreeHorizontally(root));
        }

        [TestMethod()]
        public void TraverseTreeHorizontaly_ThreeLevels()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Left.Right = new Node(0);
            root.Right = new Node(8);

            Assert.AreEqual("5, 4, 8, 0", Challenges.TraverseTreeHorizontally(root));
        }
    }
}