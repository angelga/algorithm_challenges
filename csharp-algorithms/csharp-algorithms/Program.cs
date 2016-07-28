using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharpLibrary.Node node = new CSharpLibrary.Node(5);

            node.Left = new CSharpLibrary.Node(4);
            node.Right = new CSharpLibrary.Node(6);
            Console.WriteLine(node);
            Console.ReadKey();
        }
    }
}
