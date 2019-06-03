using System;
using System.Linq;
using Tree;
using Stack;

namespace DepthFirstTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<int> tree = new BST<int>();
            Stack<Node<int>> queue = new Stack<Node<int>>();

            tree.Insert(79);
            tree.Insert(51);
            tree.Insert(118);
            tree.Insert(17);
            tree.Insert(67);
            tree.Insert(90);
            tree.Insert(162);
            tree.Insert(41);
            tree.Insert(59);
            tree.Insert(71);
            tree.Insert(141);
            tree.Insert(190);
            tree.Insert(38);
            tree.Insert(49);
            tree.Insert(75);
            tree.Insert(150);
            tree.Insert(72);
            tree.Insert(149);
            tree.Insert(155);

            DepthFirst(tree, queue);
        }

        public static void DepthFirst(BST<int> tree,Stack<Node<int>> stack)
        {
            if(tree.root != null)
            {
                stack.push(tree.root);
            }

            while (!stack.isEmpty())
            {
                Node<int> curr = stack.pop();
                Console.WriteLine(curr.data);
                if(curr.right != null)
                {
                    stack.push(curr.right);
                }
                if(curr.left != null)
                {
                    stack.push(curr.left);
                }
            }
        }
    }
}
