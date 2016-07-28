using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibrary
{
    public class Node
    {
        private int data;
        private Node left;
        private Node right;

        public Node(int data)
        {
            this.data = data;
        }

        public int Data
        {
            get
            {
                return this.data;
            }
        }

        public Node Left
        {
            get
            {
                return this.left;
            }
            set
            {
                if (value != null)
                {
                    this.left = value;
                }
            }
        }

        public Node Right
        {
            get
            {
                return this.right;
            }
            set
            {
                if (value != null)
                {
                    this.right = value;
                }
            }
        }
    }
}
