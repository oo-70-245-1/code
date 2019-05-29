using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generics
{
    class Program
    {
        class Node
        {
            public int element;
            public Node left = null;
            public Node right = null;
            Node parent = null;

            public Node createNode(int element)
            {
                Node n = new Node() { parent = this, element = element };
                return n;
            }

            public Node addLeft(int element)
            {
                this.left = createNode(element);
                return this.left;
            }
            public Node addRight(int element)
            {
                this.right = createNode(element);
                return this.right;
            }
            public override string ToString()
            {
                return "Node element => " + element.ToString();
            }
        }
        static Node dfs(int val, Node parent)
        {
            if (parent == null)
                return null;

            if (parent.element == val)
                return parent;

            Node ret = null;
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
			// Typical binary tree example
            Node n = new Node();
            n.addLeft(4).addLeft(10).addLeft(7);
            n.addRight(5).addRight(2);
            Console.WriteLine(dfs(22, n));

        }
    }
}
