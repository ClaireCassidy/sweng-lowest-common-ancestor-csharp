using Microsoft.VisualStudio.TestTools.UnitTesting;
using lca_csharp;

namespace LowestCommonAncestorTests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    Node testNode = new Node(5);

        //    Assert.AreEqual(testNode.GetVal(), 5);
        //}

        [TestMethod]
        public void TestRoot()
        {
            Assert.AreEqual(new BinaryTree().GetRoot(), 
                null,
                "Binary tree constructor passed null should have a null root");

            Assert.AreEqual(new BinaryTree(new Node(3)).GetRoot().GetVal(), 
                3, 
                "Binary tree constructor passed a node should make that node the root");

            Assert.AreEqual(new BinaryTree(3).GetRoot().GetVal(),
                3,
                "Binary tree constructor passed an arbitrary integer should have that value as its root's value");

            BinaryTree testTree = new BinaryTree(5);
            testTree.Insert(1);
            testTree.Insert(2);
            testTree.Insert(3);
            testTree.Insert(4);
            Assert.AreEqual(testTree.GetRoot().GetVal(),
                5,
                "Root should not change after insertion operations");
        }

        [TestMethod]
        public void TestGetLChild()
        {
            BinaryTree testTree = new BinaryTree(5);

            Assert.AreEqual(testTree.GetRoot().GetLChild(),
                null,
                "Node with no children should have a null lchild");

            testTree.Insert(4);

            Assert.AreEqual(testTree.GetRoot().GetLChild().GetVal(),
                4,
                "If a node has an lchild, it should be returned by the method");
        }

        [TestMethod]
        public void TestGetRChild()
        {
            BinaryTree testTree = new BinaryTree(5);

            Assert.AreEqual(testTree.GetRoot().GetRChild(),
                null,
                "Node with no children should have a null rchild");

            testTree.Insert(6);
            testTree.Insert(4);

            Assert.AreEqual(testTree.GetRoot().GetRChild().GetVal(),
                4,
                "If a node has an rchild, it should be returned by the method");
        }

        [TestMethod]
        public void TestGetVal()
        {
            BinaryTree testTree = new BinaryTree(1);

            Assert.AreEqual(testTree.GetRoot().GetVal(),
                1,
                "should return the value of the node");
        }

        [TestMethod]
        public void TestSetLChild()
        {
            BinaryTree testTree = new BinaryTree(5);

            testTree.GetRoot().SetLChild(6);

            Assert.AreEqual(testTree.GetRoot().GetLChild().GetVal(),
                6,
                "Child nodes' values should be correctly set");

            Assert.AreEqual(testTree.GetRoot().SetLChild(5),
                false,
                "node should reject attempts to set lchild if it already exists");
        }

        [TestMethod]
        public void TestSetRChild()
        {
            BinaryTree testTree = new BinaryTree(5);

            testTree.GetRoot().SetRChild(6);

            Assert.AreEqual(testTree.GetRoot().GetRChild().GetVal(),
                6,
                "Child nodes' values should be correctly set");

            Assert.AreEqual(testTree.GetRoot().SetRChild(5),
                false,
                "node should reject attempts to set rchild if it already exists");
        }

        [TestMethod]
        public void TestInsertInBinaryTree()
        {
            BinaryTree testTree = new BinaryTree(null);

            testTree.Insert(5);
            Assert.AreEqual(testTree.GetRoot().GetVal(),
                5,
                "A value inserted into a binary tree with no root should become the root");

            testTree.Insert(6);
            Assert.AreEqual(testTree.GetRoot().GetLChild().GetVal(),
                6,
                "Insertion for a node with no children should make it the lchild");

            testTree.Insert(7);
            Assert.AreEqual(testTree.GetRoot().GetRChild().GetVal(),
                7,
                "Insertion for a node with an lchild should make the new value the rchild");

            testTree.Insert(8);
            Assert.AreEqual(testTree.GetRoot().GetLChild().GetLChild().GetVal(),
                8,
                "Insertion to a tree that has a full bottom row should see the value inserted in the leftmost position on the next row");

            //                     __[1]__
            //                    /       \
            //                   /         \
            //                [2]           [9]
            //               /   \             \
            //            [3]     [8]           [10]
            //           /   \                 /    \
            //        [4]     [6]          [11]      [12]
            //           \       \        /    \         \
            //            [5]     [7] [13]      [14]      [16]
            //                                 /         /
            //                             [15]      [17]
            testTree = LowestCommonAncestor.GenerateTestTree();
            testTree.Insert(18);

            Assert.AreEqual(testTree.GetRoot().GetRChild().GetLChild().GetVal(),
                18,
                "Insertion into a binary tree with random shape should go to the correct spot");
        }

        [TestMethod]
        public void TestGetLowestCommonAncestor()
        {
            BinaryTree testTree = LowestCommonAncestor.GenerateTestTree();

            //                     __[1]__
            //                    /       \
            //                   /         \
            //                [2]           [9]
            //               /   \             \
            //            [3]     [8]           [10]
            //           /   \                 /    \
            //        [4]     [6]          [11]      [12]
            //           \       \        /    \         \
            //            [5]     [7] [13]      [14]      [16]
            //                                 /         /
            //                             [15]      [17]

            Assert.AreEqual(testTree.GetLowestCommonAncestor(1, 1).GetVal(),
                1,
                "Lowest common ancestor of the same nodes should be that node");

            Assert.AreEqual(testTree.GetLowestCommonAncestor(3, 7).GetVal(),
                3,
                "Lowest common ancestor of a pair of nodes a b where a is an ancestor of b should be a");

            Assert.AreEqual(testTree.GetLowestCommonAncestor(13, 14).GetVal(),
                11,
                "LCA of a pair of arbitrary nodes should return the correct result");

            Assert.AreEqual(testTree.GetLowestCommonAncestor(17, 5).GetVal(),
                1,
                "Method should still work if the LCA is the root");
        }
    }
}
