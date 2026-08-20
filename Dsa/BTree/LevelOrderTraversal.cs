using Dsa.BTree.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.BTree
{
    public class LevelOrderTraversal
    {
        public static List<List<int>> LevelOrderTraversalFunc(TreeNode<int> root)
        {
            List<List<int>> list = new List<List<int>>();
            if (root == null) return list;

            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                List<int> level = new();
                int levelLength = queue.Count;

                for(int i = 0; i < levelLength; i++)
                {
                    TreeNode<int> curr = queue.Dequeue();
                    level.Add(curr.val);

                    if (curr.left != null)
                        queue.Enqueue(curr.left);

                    if (curr.right != null)
                        queue.Enqueue(curr.right);
                }

                list.Add(level);    
            }

            return list;    
        }
    }
}
