using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmutablilidad
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = string.Empty;
            for (int i = 0; i < 1000; i++)
            {
                str += "string "; 
            }


            //StringBuilder = strB = new StringBuilder();
            //for (int i = 0; i < 10000; i++)
            //{
            //    strB.Append("Modified ");
            //}

            //var stack = ImmutableStack<int>.Empty;
            //for (int i = 0; i < 10; i++)
            //{
            //    stack = stack.Push(i);
            //}

            var stack = ImmutableStack<int>.Empty;
            for (int i = 0; i < 10; i++)
            {
                stack = stack.Push(i);
            }
            Console.WriteLine("No of elements in original stack:" + stack.Count());
            var newStack = stack.Pop();
            Console.WriteLine("No of elements in new stack: " + newStack.Count());
            Console.ReadKey();

            // No of elements in original stack: 10
            // No of elements in new stack: 9


            var list = ImmutableList.Create(1, 2, 3, 4, 5);
        }

        class MyClass
        {
            private readonly string myStr;

            public MyClass(string str)
            {
                myStr = str;
            }

            public string GetStr
            {
                get { return myStr; }
            }
        }
    }
}
