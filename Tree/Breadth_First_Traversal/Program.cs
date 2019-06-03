using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue;
using Tree;

namespace Breadth_First_Traversal
{
    
    class Program
    {
        static void Main(string[] args)
        {
            BST<int> tree = new BST<int>();
            Queue<Node<int>> queue = new Queue<Node<int>>();

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

            BreadthFirst(tree, queue);
        }

        public static void BreadthFirst(BST<int> tree,Queue<Node<int>> queue)
        {
            
            if(tree.root != null)
            {
                queue.enqueue(tree.root);
            }

            while (!queue.isEmpty())
            {
                Node<int> curr = queue.dequeue();
                Console.WriteLine(curr.data);
                if(curr.left != null)
                {
                    queue.enqueue(curr.left);
                }
                if (curr.right != null)
                {
                    queue.enqueue(curr.right);
                }
            }
        }
    }
}
