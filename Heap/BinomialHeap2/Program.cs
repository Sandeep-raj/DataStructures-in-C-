using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap2
{
    public class Node
    {
        public int data, order;
        public Node parent, child, sibling;

        public Node(int data)
        {
            this.data = data;
            order = 0;
            parent = null;
            child = null;
            sibling = null;
        }
    }

    public class BinomialHeap
    {
        public Node root;
        public BinomialHeap()
        {
            root = null;
        }
        public void Insert(int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return;
            }
            Node newNode = new Node(data);
            InsertNode(newNode);
        }
        private void InsertNode(Node node)
        {
            MergeHeap(node, root);

            Node iterator = root;
            Node prev, curr, next;
            prev = null;
            while (iterator.sibling != null)
            {
                if (iterator.order != iterator.sibling.order)
                {
                    prev = iterator;
                    iterator = iterator.sibling;
                }

                else
                {
                    curr = iterator;
                    next = iterator.sibling;
                    Node rest = next.sibling;
                    Node unionNode = UnionHeap(curr, next);
                    if (prev == null)
                    {
                        unionNode.sibling = rest;
                        root = unionNode;
                        iterator = root;
                    }
                    else
                    {
                        prev.sibling = unionNode;
                        unionNode = rest;
                        iterator = unionNode;
                    }
                }
            }
        }
        private void MergeHeap(Node node1, Node node2)
        {
            
            while(node1 != null)
            {
                Node temp1 = node1.sibling;
                Node temp2 = node2;
                
                node1.sibling = null;
                if(node1.order <= node2.order)
                {
                    node1.sibling = node2;
                    node2 = node1;
                    node1 = temp1;
                }
                else
                {
                    while(temp2.sibling != null)
                    {
                        if(node1.order > temp2.sibling.order)
                        {
                            Node temp = temp2.sibling;
                            temp2.sibling = node1;
                            node1.sibling = temp;
                            break;
                        }
                        temp2 = temp2.sibling;
                    }
                    if(temp2.sibling == null)
                    {
                        temp2.sibling = node1;
                    }
                    node2 = temp2;
                    node1 = temp1;
                }
            }
            root = node2;
        }
        public Node UnionHeap(Node node1, Node node2)
        {
            Node temp = node2.sibling;
            Node newNode;
            if(node2.data < node1.data)
            {
                node1.sibling = node2.child;
                node1.parent = node2;
                node2.child = node1;
                node2.order += 1;
                newNode = node2;
            }
            else
            {
                node2.sibling = node1.child;
                node2.parent = node1;
                node1.child = node2;
                node1.order += 1;
                newNode = node1;
            }

            return newNode;
            
        }
        public void PrintAll()
        {
            Traversal(root);
        }
        private void Traversal(Node node)
        {
           if(node != null)
            {
                Traversal(node.child);
                Console.Write(node.data + " ");
                Traversal(node.sibling);
            }
        }
        public int FindMin()
        {
            Node temp = root;
            Node min = temp;
            Node prev= null;
            while (temp.sibling != null)
            {
                if (min.data > temp.sibling.data)
                {
                    min = temp.sibling;
                    prev = temp;
                }
                temp = temp.sibling;
            }
            if(min == root)
            {
                root = root.sibling;
            }
            else
            {
                prev.sibling = prev.sibling.sibling;
            }
            RemoveMin(min);
            return min.data;
        }
        private void RemoveMin(Node node)
        {
            while(node.child.sibling != null)
            {
                Node newNode = node.child;
                node.child = newNode.sibling;
                newNode.sibling = null;
                newNode.parent = null;
                InsertNode(newNode);
            }
            InsertNode(node.child);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinomialHeap heap = new BinomialHeap();
            heap.Insert(99);
            heap.Insert(51);
            heap.Insert(24);
            heap.Insert(73);
            heap.Insert(74);
            Console.WriteLine(heap.FindMin());
            heap.PrintAll();
        }
    }
}
