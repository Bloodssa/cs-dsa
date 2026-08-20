using Dsa.LinkedList.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.LinkedList
{
    public class RotateList
    {
        public static Node<int> RotateRigth(Node<int> head, int k)
        {
            if (head == null) return head;

            int length = 1;
            Node<int> tail = head;

            while(tail.Next != null)
            {
                tail = tail.Next;
                length += 1;
            }

            // reduce k if k has the same with the length then no rotate would happen
            k %= length;
            if (k == 0) return head;

            Node<int> curr = head;
            for(int i = 0; i < length - k - 1; i++)
            {
                curr = curr.Next;
            }

            Node<int> newNode = curr.Next;
            curr.Next = null; // break the list the stop of the curr is the new tail

            tail.Next = head;

            return newNode;
        }
    }
}
