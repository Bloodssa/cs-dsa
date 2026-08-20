using Dsa.LinkedList.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.LinkedList
{
    public class PalidromeLInkedList
    {
        public static bool IsPalindrome(Node<int> head)
        {
            Stack<int> stack = new();
            Node<int> iterator = head;

            while(iterator != null)
            {
                stack.Push(iterator.Data);
                iterator = iterator.Next;
            }

            while(head != null)
            {
                if (head.Data != stack.Pop()) return false;
                head = head.Next;
            }

            return true;
            // 0(n) space .....-
        }
    }
}
