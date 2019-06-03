using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class Node
    {
        public int data;
        public int height;
        public Node right;
        public Node left;

        public Node(int data)
        {
            this.data = data;
            this.height = 1;
        }
    }
    public class AVL
    {
        public Node root;

        public int NodeHeight(Node node)
        {
            return (node == null) ? 0 : node.height;
        }

        public int maxHeight(int a,int b)
        {
            return (a > b) ? a : b;
        }

        public int balance(Node node)
        {
            return (NodeHeight(node.left) - NodeHeight(node.right));
        }

        public Node LeftRotate(Node x)
        {
            Node y = x.right;
            Node temp = y.left;

            y.left = x;
            x.right = temp;

            return y;
        }

        public Node RightRotate(Node x)
        {
            Node y = x.left;
            Node temp = y.right;

            y.right = x;
            x.left = temp;

            return y;
        }

        public Node insert(Node node,int data)
        {
            if(node == null)
            {
                return new Node(data);
            }else if(data > node.data)
            {
                node.right = insert(node.right, data);
            }else if(data < node.data)
            {
                node.left = insert(node.left, data);
            }

            node.height = maxHeight(NodeHeight(node.left), NodeHeight(node.right)) + 1;

            int balance = this.balance(node);

            if(balance < -1 && data > node.right.data)
            {
                return LeftRotate(node);
            }

            else if(balance > 1 && data < node.left.data)
            {
                return RightRotate(node);
            }

            else if(balance < -1 && data < node.right.data)
            {
                node.right = RightRotate(node.right);
                return LeftRotate(node);
            }
            else if(balance > 1 && data > node.left.data)
            {
                node.left = LeftRotate(node.left);
                return RightRotate(node);
            }
            
            return node;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AVL tree = new AVL();
            tree.root = tree.insert(tree.root, 10);
            tree.root = tree.insert(tree.root, 20);
            tree.root = tree.insert(tree.root, 30);
            tree.root = tree.insert(tree.root, 40);
            tree.root = tree.insert(tree.root, 50);
            tree.root = tree.insert(tree.root, 25);
        }
    }
}
