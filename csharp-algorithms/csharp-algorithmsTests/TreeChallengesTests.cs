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
            Assert.IsFalse(TreeChallenges.IsBinaryTreeMirrored(null));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_RootOnly()
        {
            Assert.IsTrue(TreeChallenges.IsBinaryTreeMirrored(new Node(5)));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_OneLevelOneChild()
        {
            Node root = new Node(5);
            root.Left = new Node(4);

            Assert.IsFalse(TreeChallenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_OneLevelMirrored()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);

            Assert.IsTrue(TreeChallenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_OneLevelUnmirrored()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);

            Assert.IsFalse(TreeChallenges.IsBinaryTreeMirrored(root));
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

            Assert.IsTrue(TreeChallenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_TwoLevelsMirroredIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);
            root.Left.Left = new Node(3);
            root.Right.Right = new Node(3);

            Assert.IsTrue(TreeChallenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void IsBinaryTreeMirrored_TwoLevelsUnmirroredIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(4);
            root.Left.Left = new Node(3);

            Assert.IsFalse(TreeChallenges.IsBinaryTreeMirrored(root));
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

            Assert.IsFalse(TreeChallenges.IsBinaryTreeMirrored(root));
        }

        [TestMethod()]
        public void DepthBinTree_Null()
        {
            Assert.AreEqual(0, TreeChallenges.DepthBinaryTree(null));
        }

        [TestMethod()]
        public void DepthBinTree_OneLevel()
        {
            Assert.AreEqual(1, TreeChallenges.DepthBinaryTree(new Node(5)));
        }

        [TestMethod()]
        public void DepthBinTree_TwoLevelIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);

            Assert.AreEqual(2, TreeChallenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void DepthBinTree_TwoLevelComplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);

            Assert.AreEqual(2, TreeChallenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void DepthBinTree_ThreeLevelIncomplete()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);
            root.Right.Left = new Node(10);

            Assert.AreEqual(3, TreeChallenges.DepthBinaryTree(root));
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

            Assert.AreEqual(3, TreeChallenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void DepthBinTree_FourLevelIncomplete()
        {
            Node root = new Node(5);
            root.Right = new Node(6);
            root.Right.Left = new Node(8);
            root.Right.Left.Right = new Node(9);

            Assert.AreEqual(4, TreeChallenges.DepthBinaryTree(root));
        }

        [TestMethod()]
        public void TraverseTreeHorizontally_Empty()
        {
            Assert.AreEqual(string.Empty, TreeChallenges.TraverseTreeHorizontally(null));
        }

        [TestMethod()]
        public void TraverseTreeHorizontally_RootOnly()
        {
            Assert.AreEqual("1", TreeChallenges.TraverseTreeHorizontally(new Node(1)));
        }

        [TestMethod()]
        public void TraverseTreeHorizontally_OneLevel()
        {
            Node root = new Node(1);
            root.Right = new Node(2);
            Assert.AreEqual("1, 2", TreeChallenges.TraverseTreeHorizontally(root));
        }

        [TestMethod()]
        public void TraverseTreeHorizontaly_ThreeLevels()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Left.Right = new Node(0);
            root.Right = new Node(8);

            Assert.AreEqual("5, 4, 8, 0", TreeChallenges.TraverseTreeHorizontally(root));
        }

        [TestMethod()]
        public void TreeTraverseAndLink_Null()
        {
            Assert.IsNull(TreeChallenges.TraverseAndLinkTreeHorizontally(null));
        }

        [TestMethod()]
        public void TreeTraverseAndLink_RootOnly()
        {
            Node root = TreeChallenges.TraverseAndLinkTreeHorizontally(new Node(5));
            Assert.IsTrue(root.Data == 5 && root.Left == null && root.Right == null);
        }

        [TestMethod()]
        public void TreeTraverseAndLink_TwoLevelFull()
        {
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);

            Node result = TreeChallenges.TraverseAndLinkTreeHorizontally(root);
            int[] expectedData = { 5, 4, 6 };
            bool correct = true;
            for (int i = 0; i < expectedData.Length; i++)
            {
                correct = correct &&
                    result != null &&
                    result.Data == expectedData[i] &&
                    result.Left == null;
                result = result.Right;
            }

            Assert.IsTrue(correct);
        }

        [TestMethod()]
        public void TreeTraverseAndLink_ThreeLevelsIncomplete()
        {
            // Setup test tree
            Node root = new Node(5);
            root.Left = new Node(6);
            root.Left.Right = new Node(7);
            root.Right = new Node(8);
            root.Right.Left = new Node(9);

            // Execute test
            Node result = TreeChallenges.TraverseAndLinkTreeHorizontally(root);
            int[] expectedData = { 5, 6, 8, 7, 9 };
            bool correct = true;
            for (int i = 0; i < expectedData.Length; i++)
            {
                correct = correct &&
                    result != null &&
                    result.Data == expectedData[i] &&
                    result.Left == null;
                result = result.Right;
            }

            Assert.IsTrue(correct);
        }

        [TestMethod()]
        public void TreeZigzag()
        {
            // Setup test tree
            Node root = new Node(5);
            root.Left = new Node(7);
            root.Right = new Node(6);
            root.Left.Right = new Node(8);
            root.Right.Left = new Node(9);

            // Traverse tree
            List<int> result = new List<int>();
            foreach (var node in TreeChallenges.TraverseZigzag(root))
            {
                result.Add(node.Data);
            }

            Assert.AreEqual("5, 6, 7, 8, 9", string.Join(", ", result));
        }

        [TestMethod()]
        public void BSTTraverseInOrder()
        {
            // Setup test tree
            Node root = new Node(5);
            root.Left = new Node(4);
            root.Right = new Node(6);
            root.Left.Left = new Node(3);

            List<int> result = new List<int>();
            foreach (var node in TreeChallenges.TraverseInOrderBST(root))
            {
                result.Add(node.Data);
            }

            Assert.AreEqual("3, 4, 5, 6", string.Join(", ", result));
        }

        [TestMethod()]
        public void BSTFindNthSmallest()
        {
            Node root = new Node(5);
            Assert.AreEqual(5, TreeChallenges.FindNthSmallest(root, 1).Data);
        }

        [TestMethod()]
        public void BSTFindNthSmallest_SmallerNth()
        {
            Node root = new Node(5);
            Assert.IsNull(TreeChallenges.FindNthSmallest(root, 0));
        }

        [TestMethod()]
        public void BSTFindNthSmallest_BiggerNth()
        {
            Node root = new Node(5);
            Assert.IsNull(TreeChallenges.FindNthSmallest(root, 2));
        }

        [TestMethod()]
        public void BSTFindSmallestWRef()
        {
            Node root = new Node(5);
            int nth = 1;
            Assert.AreEqual(5, TreeChallenges.FindNthSmallestWRef(root, ref nth).Data);
        }

        [TestMethod()]
        public void BSTFindSmallestWRef_1Level()
        {
            Node root = new Node(5);
            root.Left = new Node(3);
            root.Left.Right = new Node(4);

            int nth = 2;
            Assert.AreEqual(4, TreeChallenges.FindNthSmallestWRef(root, ref nth).Data);
        }

        [TestMethod()]
        public void FindNodeInTree()
        {
            Node root = new Node(5);
            root.Left = new Node(3);
            root.Left.Right = new Node(4);

            Assert.AreEqual(4, TreeChallenges.FindNodeInBST(root, 4).Data);
        }

        [TestMethod()]
        public void FindNodeInTreeNull()
        {
            Assert.IsNull(TreeChallenges.FindNodeInBST(null, 1));
        }

        [TestMethod()]
        public void FindNodeInTreeNullResult()
        {
            Assert.IsNull(TreeChallenges.FindNodeInBST(new Node(5), 1));
        }
    }
}