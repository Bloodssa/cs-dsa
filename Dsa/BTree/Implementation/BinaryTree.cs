using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.BTree.Implementation
{
    public class BinaryTree<T>
    {
        public TreeNode<T> root;

        public TreeNode<T> Insert(T val)
        {
            TreeNode<T> newNode = new(val);

            if(root == null)
            {
                root = newNode;
                return newNode;
            }

            // level order insertion
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                TreeNode<T> current = queue.Dequeue();

                // insert in left if its null else add in the queue
                // repeat the queue left and right insert
                if (current.left == null)
                {
                    current.left = newNode;
                    return newNode;
                }else
                {
                    queue.Enqueue(current.left);
                }

                if (current.right == null)
                {
                    current.right = newNode;
                    return newNode;
                } else
                {
                    queue.Enqueue(current.right);
                }
            }

            throw new InvalidOperationException("Unable node insertion.");
        }

        public bool Search(T val)
        {
            return SearchHelper(root, val);
        }

        private bool SearchHelper(TreeNode<T> current, T val)
        {
            // preorder search traversal
            if (current == null) 
                return false;

            if (EqualityComparer<T>.Default.Equals(current.val, val))
                return true;

            bool foundInLeft = SearchHelper(current.left, val);
            if(foundInLeft) return true;

            return SearchHelper(current.right, val);
        }

        public void Delete(T val)
        {
            if (root == null) return;

            // only if the root is the only node
            if (root.left == null && root.right == null)
            {
                if (EqualityComparer<T>.Default.Equals(root.val, val))
                    root = null;
                return;
            }

            TreeNode<T> target = null, deepest = null, parentOfDeepest = null;
            Queue<TreeNode<T>> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> current = queue.Dequeue();

                // found the target val to remove
                if(target == null && EqualityComparer<T>.Default.Equals(current.val, val))
                    target = current;

                deepest = current;

                if (current.left != null)
                {
                    parentOfDeepest = current;
                    queue.Enqueue(current.left);
                }

                if (current.right != null)  
                {
                    parentOfDeepest = current;
                    queue.Enqueue(current.right);
                }
            }

            if (target == null)
                return;

            // copy thr value of the deepest node value of the target
            target.val = deepest.val;

            // remove deepest node
            if (parentOfDeepest.left == deepest)
            {
                parentOfDeepest.left = null;
            }
            else
            {
                parentOfDeepest.right = null;
            }
        }

        public void InOrder(TreeNode<T> node)
        {
            if (node == null) return;

            InOrder(node.left);
            Console.Write(node.val + " ");
            InOrder(node.right);
        }

        public void PreOrder(TreeNode<T> node)
        {
            if (node == null) return;

            Console.Write(node.val + " ");
            PreOrder(node.left);
            PreOrder(node.right);
        }

        public void PostOrder(TreeNode<T> node)
        {
            if (node == null) return;

            PostOrder(node.left);
            PostOrder(node.right);
            Console.Write(node.val + " ");
        }

        public void LevelOrder(TreeNode<T> node)
        {
            if (node == null)
                return;

            Queue<TreeNode<T>> queue = new();
            queue.Enqueue(node);

            while(queue.Count > 0)
            {
                TreeNode<T> current = queue.Dequeue();

                Console.Write(current.val + " ");

                if(current.left != null)
                    queue.Enqueue(current.left);

                if (current.right != null)
                    queue.Enqueue(current.right);
            }
        }

        // pre order traversal
        public void IterativeDfs(TreeNode<T> node)
        {
            if (node == null)
                return;

            Stack<TreeNode<T>> stack = new();
            stack.Push(node);

            while(stack.Count > 0)
            {
                TreeNode<T> curr = stack.Pop();

                Console.Write(curr.val + " ");

                if(curr.right != null)
                    stack.Push(curr.right);
                if(curr.left != null)
                    stack.Push(curr.left);
            }
        }
    }

    // type of dfs
    // preorder = root node, left node, right node
    // inorder = left node, root node, right node
    // post order = left node, right node, root node

    // bfs = level order traversal
    // visits node level by level
}
