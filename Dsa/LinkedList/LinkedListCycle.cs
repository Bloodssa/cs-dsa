using Dsa.LinkedList.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.LinkedList
{
    public class LinkedListCycle
    {
        // Time: O(n)
        // Space: O(1)
        public static bool HasCycle(Node<int> head)
        {
            if (head == null) return false;

            Node<int> slow = head, fast = head;

            while(slow != null & fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast) return true;
            }

            return false;
        }

        // Time: O(n)
        // Space: O(n)
        public static bool HasCycleVisited(Node<int> head)
        {
            if (head == null) return false;

            ISet<Node<int>> visited = new HashSet<Node<int>>();

            while(head != null)
            {
                if(visited.Contains(head))
                    return true;

                visited.Add(head);
                head = head.Next;
            }

            return false;
        }
    }
}
