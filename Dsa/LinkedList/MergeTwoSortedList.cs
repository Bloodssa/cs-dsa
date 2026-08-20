using Dsa.LinkedList.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.LinkedList
{
    public class MergeTwoSortedList
    {
        public static Node<int> MergeTwoList(Node<int> list1, Node<int> list2)
        {
            if (list1 == null && list2 == null) return null;

            Node<int> dummy = new(0);
            Node<int> iterator = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.Data < list2.Data)
                {
                    iterator.Next = list1;
                    list1 = list1.Next;
                } else
                {
                    iterator.Next = list2;
                    list2 = list2.Next;
                }

                iterator = iterator.Next;
            }

            // copy the remaining nodes
            if(list1 != null)
            {
                iterator.Next = list1;
            }else
            {
                iterator.Next = list2;
            }

             return dummy.Next;
        }
    }
}
