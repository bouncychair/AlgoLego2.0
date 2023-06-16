﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoAlgorithm
{
    public class Node
    {
        public string Data { get; set; }
        public Node Next { get; set; }

        public Node(string data)
        {
            Data = data;
            Next = null;
        }
    }
    public class MyLinkedList<T> where T : IComparable
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        public MyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddFirst(string data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Count++;
        }

        public void AddLast(string data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                return;
            }
            else if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
            }
            Count--;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                return;
            }
            else if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Node current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            Count--;
        }

        public void Remove(string data)
        {
            if (Head == null)
            {
                return;
            }
            else if (Head == Tail)
            {
                if (Head.Data == data)
                {
                    Head = null;
                    Tail = null;
                    Count--;
                }
            }
            else
            {
                if (Head.Data == data)
                {
                    Head = Head.Next;
                    Count--;
                }
                else
                {
                    Node current = Head;
                    while (current.Next != null)
                    {
                        if (current.Next.Data == data)
                        {
                            current.Next = current.Next.Next;
                            Count--;
                            break;
                        }
                        current = current.Next;
                    }
                }
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /* public T[] Quicksort()
         {
          *//*   //create Mergesort
             MyLinkedList<T> collection = new MyLinkedList<T>();
             Quicksort(collection);
             return collection;
             // make it so that it returns array
             //create sorting*//*


         }

         public T[] BubbleSort()
         {

         }*/
    }
}

