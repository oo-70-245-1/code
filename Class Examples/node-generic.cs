using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generics
{
    class Program
    {
        class Node<T>  where T : System.IComparable<T>
        {
            public T element;
            public Node<T> left = null;
            public Node<T> right = null;
            Node<T> parent = null;

            public Node<T> createNode(T element)
            {
                Node<T> n = new Node<T>() { parent = this, element = element };
                return n;
            }

            public Node<T> addLeft(T element)
            {
                this.left = createNode(element);
                return this.left;
            }
            public Node<T> addRight(T element)
            {
                this.right = createNode(element);
                return this.right;
            }
            public override string ToString()
            {
                return "Node element => " + element.ToString();
            }
            
        }
        static Node<T> dfs<T>(T val, Node<T> parent) where T : System.IComparable<T>
        {
            if (parent == null)
                return null;

            if (parent.element.CompareTo(val) == 0)
                return parent;

            Node<T> ret = null;
            if (parent.left != null)
                ret = dfs(val, parent.left);
            if (ret != null)
                return ret;
            if (parent.right != null)
                ret = dfs(val, parent.right);
            if (ret != null)
                return ret;
            return null;
        }
        static void Main(string[] args)
        {
            Node<int> n = new Node<int>();
            n.addLeft(4).addLeft(10).addLeft(7);
            n.addRight(5).addRight(2);
            Console.WriteLine(dfs(2, n));

        }
    }
}
