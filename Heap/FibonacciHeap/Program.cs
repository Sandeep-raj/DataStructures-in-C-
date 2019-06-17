using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciHeap
{
    public class Node
    {
        public int key, order;
        public Node child, parent, left, right;

        public Node(int data)
        {
            key = data;
            order = 0;
            child = parent = null;
            left = right = this;
        }
    }
    public class FibonacciHeap
    {
        public Node minNode;
        public FibonacciHeap()
        {
            minNode = null;
        }
        public void Insert(int data)
        {
            Node newNode = new Node(data);
            InsertNode(newNode);
        }
        public void InsertNode(Node newNode)
        {
            if (minNode == null)
            {
                minNode = newNode;
            }
            else
            {
                Node left = minNode.left;
                newNode.left = left;
                left.right = newNode;
                newNode.right = minNode;
                minNode.left = newNode;
                if (newNode.key < minNode.key)
                    minNode = newNode;
            }
        }
        public void Delete()
        {
            Node temp = minNode;
            Node left = minNode.left;
            Node right = minNode.right;
            left.right = right;
            right.left = left;
            minNode = left;

            while (temp.child != null)
            {
                Node child = temp.child;
                temp.child = temp.child.right;
                child.right = child.left = null;

                InsertNode(child);

            }
            UnionHeap();
        }
        private void UnionHeap()
        {
            Node[] degreeOrder = new Node[7];

            while (minNode != null)
            {

                Node curr = minNode;
                if (minNode.right == minNode)
                {
                    minNode = null;
                }
                else
                {
                    curr.left.right = curr.right;
                    curr.right.left = curr.left;
                    minNode = curr.left;
                }

                curr.left = curr.right = curr;
                while (degreeOrder[curr.order] != null)
                {
                    Node temp = degreeOrder[curr.order];
                    if (temp.key > curr.key)
                    {
                        Node child = curr.child;
                        curr.child = temp;
                        temp.parent = curr;
                        temp.left.right = child;
                        if(child != null)
                        {
                            Node childExtreme = child.left;
                            child.left = temp.left;
                            child.right = temp;
                            temp.left = childExtreme;
                        }
                        degreeOrder[curr.order] = null;
                        curr.order += 1;

                    }
                    else
                    {
                        Node child = temp.child;
                        temp.child = curr;
                        curr.parent = temp;
                        curr.left.right = child;
                        if(child != null)
                        {
                            Node childExtreme = curr.left;
                            child.left = curr.left;
                            child.right = curr;
                            curr.left = childExtreme;
                        }
                        degreeOrder[temp.order] = null;
                        temp.order += 1;
                        curr = temp;
                    }
                }
                curr.left = curr;
                curr.right = curr;
                degreeOrder[curr.order] = curr;
            }

            minNode = null;
            for(int i = 0; i < 7; i++)
            {
                if(degreeOrder[i] != null)
                {
                    degreeOrder[i].left = degreeOrder[i];
                    degreeOrder[i].right = degreeOrder[i];
                    InsertNode(degreeOrder[i]);
                }
            }
            
        }
        public void Display()
        {
            DisplayRow(minNode);
        }
        public void DisplayRow(Node node)
        {
            Node curr = node;
            while (curr != null && curr.right != node)
            {
                Console.Write(curr.key + " ");
                if(curr.child != null)
                    DisplayRow(curr.child);
                curr = curr.right;
            }
            if (node.child != null)
            {
                Console.Write(curr.key);
                DisplayRow(node.child);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciHeap heap = new FibonacciHeap();
            heap.Insert(34);
            heap.Insert(12);
            heap.Insert(30);
            heap.Insert(78);
            heap.Insert(4);
            heap.Delete();
            heap.Display();
        }
    }
}
