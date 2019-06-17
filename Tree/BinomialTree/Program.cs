using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialTree
{
    public class Node
    {
        public int data, numnodes;
        public Node[] children;
        public Node(int order)
        {
            this.data = -1;
            numnodes = order;
            children = new Node[order];
        }
    }
    public class BinomialTree
    {
        public int order;
        public Node root;

        public BinomialTree(int order)
        {
            this.order = order;
            this.root = new Node(order);
            CreateTree(root, order);
        }
        public void Clear()
        {
            root = new Node(order);
            CreateTree(root, order);
        }
        private void CreateTree(Node node,int order)
        {
            if (order == 0)
                return;
            for(int i=0;i< order; i++)
            {
                node.children[i] = new Node(i);
                CreateTree(node.children[i], i);
            }
        }
        public void Insert(int data)
        {
            if(root.data == -1)
            {
                root.data = data;
                return;
            }

            try
            {
            Insert(root, data);
            }catch(Exception ex) { }
        }
        private void Insert(Node node, int data)
        {
            if(node.data == -1)
            {
                node.data = data;
                throw new Exception("Inserted");
            }

            if (node.numnodes == 0)
                return;

            for(int i = 0; i < node.numnodes; i++)
            {
                Insert(node.children[i], data);
            }

        }
        public void Traversal()
        {
            PrintAllNodes(root);
        }
        private void PrintAllNodes(Node node)
        {
            if (node.data == -1)
                return;
            Console.Write(node.data + " ");
            for(int i = 0; i < node.numnodes; i++)
            {
                PrintAllNodes(node.children[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinomialTree BT = new BinomialTree(5);
            Random rand = new Random();
            for(int i = 0; i < 32; i++)
            {
                BT.Insert(rand.Next(100));
            }
            BT.Clear();
            BT.Traversal();
            Console.ReadKey();
        }
    }
}
