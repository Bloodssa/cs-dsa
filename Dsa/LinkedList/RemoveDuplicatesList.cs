using Dsa.LinkedList.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.LinkedList
{
    public class RemoveDuplicatesList
    {
        public static Node<int> DeleteDuplicates(Node<int> head)
        {
            Node<int> iterator = head;

            while (head != null && head.Next != null)
            {
                // skip the next.data if its a duplicate
                // only move the head if the next node if its not a duplicate
                if (head.Data == head.Next.Data)
                {
                    head.Next = head.Next.Next;
                }else
                {
                    head = head.Next;
                }
            }

            return iterator;
        }
    }
}
