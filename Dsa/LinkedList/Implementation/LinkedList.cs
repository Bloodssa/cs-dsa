using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa.LinkedList.Implementation
{
    // singly linkedlist
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T>? Head;
        private int Count { get; set; } = 0;

        // add first node of the list
        public Node<T> AddFirst(T value)
        {
            Node<T> node = new(value);
            if (Head == null)
            {
                Head = node;
                Count++;
                return node;
            }

            Node<T> first = Head;
            Head = node;
            Head.Next = first;
            Count++;

            return node;
        }

        // enhanced solution of add first
        //public void AddFirst(T value)
        //{
        //    Node<T> node = new(value);
        //    node.Next = Head;
        //    Head = node;
        //}

        // add last to the list
        public Node<T> AddLast(T value)
        {
            Node<T> newNode = new(value);
            if (Head == null) 
            {
                Head = newNode;
                return newNode;
            }else
            {
                // traverse to the last node and set the newNode for in the Next
                Node<T> node = Head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }
            
            Count++;
            return newNode;
        }

        // return the length of the linkedlist
        public int Length() => Count;

        public bool Contains(T value)
        {
            Node<T> node = Head;

            while (node != null)
            {
                //if (node.Data.Equals(value)) return true;
                if(EqualityComparer<T>.Default.Equals(node.Data, value)) return true;

                node = node.Next;
            }

            return false;
        }

        // find the value and return the node of it else return null
        public Node<T>? Find(T value)
        {
            Node<T> node = Head;

            while (node != null)
            {
                if (EqualityComparer<T>.Default.Equals(node.Data, value)) return node;
                node = node.Next;
            }

            return null;
        }

        // add after based on the passed node
        public Node<T>? AddAfter(Node<T> node, T value)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            Node<T> newNode = new(value);
            newNode.Next = node.Next;
            node.Next = newNode;
            Count++;

            return newNode;
        }
        
        // add before based on passed node
        public Node<T> AddBefore(Node<T> node, T value)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));

            Node<T> newNode = new(value);

            // if the passed noode is the head then make it the head and old head to next
            if (Head == node)
            {
                newNode.Next = Head;
                Head = newNode;
                Count++;
                return newNode;
            }

            Node<T>? current = Head;

            // traverse start from the head and if the next node is the pass node stop in there
            while (current != null && current.Next != node)
            {
                current = current.Next;
            }

            if (current == null) throw new InvalidOperationException("Invalid Operation Node not found");

            newNode.Next = node;
            current.Next = newNode;
            Count++;

            return newNode;
        }

        public bool Remove(T value)
        {
            Node<T>? current = Head;
            Node<T>? previous = null;

            while(current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, value))
                {
                    // if the pass value is the head update the head
                    if (Head == current)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public Node<T>? Last()
        {
            Node<T> curr = Head;

            while(curr.Next != null)
            {
                curr = curr.Next;
            }

            return curr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = Head;

            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //public bool Remove(T value)
        //{
        //    Node<T>? node = Find(value);

        //    if (node == null) return false;

        //    if (Head == node)
        //    {
        //        Head = Head.Next;
        //        return true;
        //    }

        //    Node<T>? current = Head;

        //    while(current != null && current.Next != node)
        //    {
        //        current = current.Next;
        //    }

        //    if (current == null) return false;

        //    current.Next = node.Next;
        //    return true;
        //}

        public void Print()
        {
            Node<T> first = Head;

            while (first.Next != null)
            {
                Console.Write(first.Data + " ");
                first = first.Next;
            }

            Console.Write(first.Data + " ");
        }
    }
}
