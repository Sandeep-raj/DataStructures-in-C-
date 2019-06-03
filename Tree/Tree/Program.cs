using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
                                                          79
                                                      
                                          51                           118

                                    17          67                 90       162

                                      41     59     71                   141    190

                                   38   49              75                 150

                                                    72                 149      155



*/


namespace Tree
{
    public enum Traversal
    {
        inorder = 1,
        preorder = 2,
        postorder = 3
    }
    public class Node<T>
    {
        public Node<T> left;
        public T data;
        public Node<T> right;
        public Node(T data)
        {
            this.data = data;
        }
        public static int CompareTo(T inp, T other)
        {
            if (typeof(T).ToString().ToLower().Contains("int"))
            {
                if ((int)(object)inp > (int)(object)other)
                    return 1;
                else if ((int)(object)inp < (int)(object)other)
                    return -1;
                else
                    return 0;
            }
            else
                return 0;
        }
    }
    public class BST<T>
    {
        public Node<T> root;
        public BST()
        {

        }
        public BST(T data)
        {
            root = new Node<T>(data);
        }
        public void Insert(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.left = null;
            newNode.right = null;
            Node<T> curr = root;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                bool validState = true;
                while (validState)
                {
                    int res = Node<T>.CompareTo(data, curr.data);
                    switch (res)
                    {
                        case 0:
                        case 1:
                            if (curr.right == null)
                            {
                                curr.right = newNode;
                                validState = false;
                            }
                            else
                            {
                                curr = curr.right;
                            }
                            break;
                        case -1:
                            if (curr.left == null)
                            {
                                curr.left = newNode;
                                validState = false;
                            }
                            else
                            {
                                curr = curr.left;
                            }
                            break;
                    }
                }
            }
        }
        public void Delete(T data)
        {
            Node<T> curr = root;
            bool validState = true;
            while (validState)
            {
                int diff = Node<T>.CompareTo(data, curr.data);
                if(diff == 1)
                {
                    if(Node<T>.CompareTo(curr.right.data,data) == 0)
                    {
                        if (curr.right.left == null && curr.right.right == null)
                        {
                            curr.right = null;
                            validState = false;
                        }
                        else if(curr.right.left != null || curr.right.right != null)
                        {
                            Node<T> replaceNode;
                            if (curr.right.left != null)
                            {
                                replaceNode = GetMax(curr.right);
                            }
                            else
                            {
                                replaceNode = GetMin(curr.right);
                            }
                            curr.right.data = replaceNode.data;
                            validState = false;
                        }
                    }
                    curr = curr.right;
                }
                else if(diff == -1)
                {
                    if (Node<T>.CompareTo(curr.left.data, data) == 0)
                    {
                        if (curr.left.right == null && curr.left.right == null)
                        {
                            curr.left = null;
                            validState = false;
                        }
                        else if (curr.left.right != null || curr.left.right != null)
                        {
                            Node<T> replaceNode;
                            if (curr.left.right != null)
                            {
                                replaceNode = GetMax(curr);
                            }
                            else
                            {
                                replaceNode = GetMin(curr);
                            }
                            curr.left.data = replaceNode.data;
                            validState = false;
                        }
                    }
                    curr = curr.left;
                }
                else
                {
                    if(Node<T>.CompareTo(curr.data,data) == 0)
                    {
                        Node<T> replaceNode;
                        if (curr.left == null && curr.right == null)
                        {
                            curr = null;
                        }
                        else if(curr.left != null)
                        {
                            replaceNode = GetMax(curr);
                            curr.data = replaceNode.data;
                            validState = false;
                        }
                        else
                        {
                            replaceNode = GetMin(curr);
                            curr.data = replaceNode.data;
                            validState = false;
                        }
                    }
                }
            }
        }
        public bool Search(T data)
        {
            Node<T> curr = root;
            while (curr != null)
            {
                int diff = Node<T>.CompareTo(curr.data, data);
                if (diff == 0)
                    return true;
                if (diff == 1)
                {
                    curr = curr.left;
                }
                else
                    curr = curr.right;
            }
            return false;
        }
        private Node<T> GetMin(Node<T> node)
        {
            Node<T> replaceNode = null;
            if(node.right.left == null && node.right.right == null)
            {
                replaceNode = node.right;
                node.right = null;
            }
            else
            {
                Node<T> curr = node.right;
                while(curr.left.left != null)
                {
                    curr = curr.left;
                }
                replaceNode = curr.left;
                
                if(curr.left.right != null)
                {
                    curr.left = curr.left.right;
                }
                else
                {
                    curr.left = null;
                }
                replaceNode.left = null;
                replaceNode.right = null;
            }
            return replaceNode;
        }
        private Node<T> GetMax(Node<T> node)
        {
            Node<T> replaceNode = null;
            if (node.left.left == null && node.left.right == null)
            {
                replaceNode = node.left;
                node.left = null;
            }
            else
            {
                Node<T> curr = node.left;
                while (curr.right.right != null)
                {
                    curr = curr.right;
                }
                replaceNode = curr.right;
                
                if (curr.right.left != null)
                {
                    curr.right = curr.right.left;
                }
                else
                {
                    curr.right = null;
                }
                replaceNode.left = null;
                replaceNode.right = null;
            }
            return replaceNode;
        }
        public T FindMin()
        {
            Node<T> curr = root;
            while (curr.left != null)
                curr = curr.left;
            return curr.data;
        }
        public T FindMax()
        {
            Node<T> curr = root;
            while (curr.right != null)
                curr = curr.right;
            return curr.data;
        }
        public void Traversal(Traversal mode)
        {
            if (mode == Tree.Traversal.inorder)
            {
                Inorder(root);
            }
            else if (mode == Tree.Traversal.postorder)
            {
                Postorder(root);
            }
            else
                Preorder(root);
        }
        private void Preorder(Node<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.data);
                Preorder(node.left);
                Preorder(node.right);
            }
        }
        private void Inorder(Node<T> node)
        {
            if (node != null)
            {
                Inorder(node.left);
                Console.WriteLine(node.data);
                Inorder(node.right);
            }
        }
        private void Postorder(Node<T> node)
        {
            if (node != null)
            {
                Postorder(node.left);
                Postorder(node.right);
                Console.WriteLine(node.data);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BST<int> bst = new BST<int>();
            bst.Insert(79);
            bst.Insert(51);
            bst.Insert(118);
            bst.Insert(17);
            bst.Insert(67);
            bst.Insert(90);
            bst.Insert(162);
            bst.Insert(41);
            bst.Insert(59);
            bst.Insert(71);
            bst.Insert(141);
            bst.Insert(190);
            bst.Insert(38);
            bst.Insert(49);
            bst.Insert(75);
            bst.Insert(150);
            bst.Insert(72);
            bst.Insert(149);
            bst.Insert(155);
            Console.WriteLine(bst.Search(59) ? "found" : "not found");
            Console.WriteLine(bst.Search(141) ? "found" : "not found");
            Console.WriteLine(bst.FindMax());
            Console.WriteLine(bst.FindMin());
            bst.Delete(79);
            bst.Traversal(Traversal.inorder);
        }
    }
}
