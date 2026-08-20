using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.BTree.Implementation
{
    public class TreeNode<T>
    {
        public T val;
        public TreeNode<T>? left;
        public TreeNode<T>? right;

        public TreeNode(T val, TreeNode<T>? left = null, TreeNode<T>? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
