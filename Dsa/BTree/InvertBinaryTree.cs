using Dsa.BTree.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.BTree
{
    public class InvertBinaryTree
    {
        // invert a binary tree using bfs
        // put the left and right node if it exists
        // the if the right or the left node is not null then invert them
        // time: O(n)
        // space: O(n)
        public static TreeNode<int> InvertTree(TreeNode<int> root)
        {
            if (root == null) 
                return root;

            Queue<TreeNode<int>> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<int> current = queue.Dequeue();

                if(current.left != null)
                    queue.Enqueue(current.left);
                if(current.right != null)
                    queue.Enqueue(current.right);

                if (current.left != null || current.right != null)
                {
                    TreeNode<int> left = current.left;

                    current.left = current.right;
                    current.right = left;
                }
            }

            return root;
        }

        public static TreeNode<int> InvertWithDfs(TreeNode<int> root)
        {
            if (root == null) return null;

            TreeNode<int> temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertWithDfs(root.left);
            InvertWithDfs(root.right);

            return root;    
        }
    }
}
