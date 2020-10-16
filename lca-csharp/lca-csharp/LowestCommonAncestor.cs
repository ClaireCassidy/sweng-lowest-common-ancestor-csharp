using System;
using System.Collections.Generic;
using System.Text;

namespace lca_csharp
{
    public class LowestCommonAncestor
    {
        static void Main(string[] args)
        {

            BinaryTree tree = GenerateTestTree();
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

            int val1 = 6;
            int val2 = 3;
            Node lowestCommonAncestor = tree.GetLowestCommonAncestor(val1, val2);
            Console.WriteLine("LCA: " + lowestCommonAncestor.GetVal());
        }


        public static BinaryTree GenerateTestTree()
        {
            BinaryTree tree = new BinaryTree(1);

            tree.Insert(2);
            tree.Insert(9);
            tree.Insert(3);
            tree.Insert(8);

            tree.GetRoot().GetRChild().SetRChild(10);
            tree.GetRoot().GetLChild().GetLChild().SetLChild(4);
            tree.GetRoot().GetLChild().GetLChild().SetRChild(6);
            tree.GetRoot().GetLChild().GetLChild().GetLChild().SetRChild(5);
            tree.GetRoot().GetLChild().GetLChild().GetRChild().SetRChild(7);

            tree.GetRoot().GetRChild().GetRChild().SetLChild(11);
            tree.GetRoot().GetRChild().GetRChild().SetRChild(12);
            tree.GetRoot().GetRChild().GetRChild().SetRChild(12);
            tree.GetRoot().GetRChild().GetRChild().GetLChild().SetLChild(13);
            tree.GetRoot().GetRChild().GetRChild().GetLChild().SetRChild(14);
            tree.GetRoot().GetRChild().GetRChild().GetLChild().GetRChild().SetLChild(15);

            tree.GetRoot().GetRChild().GetRChild().GetRChild().SetRChild(16);
            tree.GetRoot().GetRChild().GetRChild().GetRChild().GetRChild().SetLChild(17);

            return tree;
        }
    }
}
