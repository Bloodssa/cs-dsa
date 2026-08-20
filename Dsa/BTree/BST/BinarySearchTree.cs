using Dsa.BTree.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.BTree.BST
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public TreeNode<T> root;

        public void Insert(T val)
        {
            root = InsertHelper(root, val);
        }

        private TreeNode<T> InsertHelper(TreeNode<T> root, T val)
        {
            if (root == null)
                return new TreeNode<T>(val);

            if (val.CompareTo(root.val) < 0)
                root.left = InsertHelper(root.left, val);
            else if (val.CompareTo(root.val) > 0)
                root.right = InsertHelper(root.right, val);

            return root;
        }

        public void InOrder(TreeNode<T> root)
        {
            if (root == null)
                return;

            InOrder(root.left);
            Console.Write(root.val + " ");
            InOrder(root.right);
        }

        public TreeNode<T> Search(T val)
        {
            return SearchHelper(root, val);
        }

        private TreeNode<T> SearchHelper(TreeNode<T> node, T val)
        {
            if (node == null || val.CompareTo(node.val) == 0) 
                return node;

            if (val.CompareTo(node.val) < 0)
                return SearchHelper(node.left, val);

            return SearchHelper(node.right, val);
        }

    }
}
