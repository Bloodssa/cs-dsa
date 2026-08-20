using System;
using System.Collections.Generic;
using Dsa.LinkedList.Implementation;

namespace Dsa.LinkedList
{
    public class ReverseLinkedList
    {
        // three pointers
        public static Node<int> ReverseList(Node<int> head)
        {
            Node<int>? curr = head;
            Node<int>? prev = null;
            Node<int>? next = null;

            while (curr != null)
            {
                // move 1 node from the current which starts from the head
                next = curr.Next;

                // set the next node of the curr or head pointing to the previous node
                curr.Next = prev;

                // move prev and curr forward
                prev = curr;
                curr = next;
            }

            return prev;
        }
    }
}
