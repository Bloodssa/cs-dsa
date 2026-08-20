using Dsa.BTree.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.BTree
{
    public class SameBinaryTree
    {
        public static bool IsSameTree(TreeNode<int> p, TreeNode<int> q)
        {
            Queue<TreeNode<int>> first = new();
            Queue<TreeNode<int>> second = new();

            first.Enqueue(p);
            second.Enqueue(q);

            while (first.Count > 0 && second.Count > 0)
            {
                TreeNode<int> f = first.Dequeue();
                TreeNode<int> s = second.Dequeue();

                // both are null nothing to compare
                if (f == null && s == null)
                    continue;

                // if it one returns false then the 2 tree is not the same
                if (f == null || s == null || f.val != s.val)
                    return false;

                first.Enqueue(f.left);
                second.Enqueue(s.left);

                first.Enqueue(f.right);
                second.Enqueue(s.right);
            }

            return true;
        }
    }
}
