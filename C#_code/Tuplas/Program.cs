using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuplas
{
    class Program
    {
        static void Main(string[] args)
        {
            ////tuple with 4 element
            //var tuple = new Tuple<string, int, bool, MyClass>("foo", 123, true, new MyClass());

            //// tuple with 4 elements
            //var tuple = Tuple.Create("foo", 123, true, new MyClass());

            //var tuple = ("foo", 123, true, new MyClass());

            var tuple = new Tuple<string, int, bool, MyClass>("foo", 123, true, new MyClass());
            var item1 = tuple.Item1; // "foo"
            var item2 = tuple.Item2; // 123
            var item3 = tuple.Item3; // true
            var item4 = tuple.Item4; // new My Class()

            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(new Tuple<int, string>(2, "foo"));
            list.Add(new Tuple<int, string>(1, "bar"));
            list.Add(new Tuple<int, string>(3, "qux"));

            list.Sort((a, b) => a.Item2.CompareTo(b.Item2)); //sort based on the string element

            foreach (var element in list)
            {
                Console.WriteLine(element);
            }

            // Output
            // (1, bar) 
            // (2, foo) 
            // (3, qux)

            
            
            
            //void Write()
            //{
            //    var result = AddMultiply(25, 28);
            //    Console.WriteLine(result.Item1);
            //    Console.WriteLine(result.Item2);
            //}

            //Tuple<int, int> AddMultiply(int a, int b)
            //{
            //    return new Tuple<int, int>(a + b, a * b);
            //}
            //// output:
            //// 53 
            //// 700

            
            
            var xs = new[] { 4, 7, 9 };
            var limits = FindMinMax(xs);
            Console.WriteLine($"Limits of [{string.Join(" ", xs)}] are {limits.min} and {limits.max}");
            // Output:
            // Limits of [4 7 9] are 4 and 9

           
            
            var ys = new[] { -9, 0, 67, 100 };
            var (minimum, maximum) = FindMinMax(ys);
            Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
            // Output:
            // Limits of [-9 0 67 100] are -9 and 100

            (int min, int max) FindMinMax(int[] input)
            {
                int max = int.MaxValue;
                int min = int.MinValue;
                foreach (var item in input)
                {

                }

                return (min, max);
            }


            //var t = (Sum: 4.5, Count: 3);
            //Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");

            //(double Sum, int Count) d = (4.5, 3);
            //Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");


            //var sum = 4.5;
            //var count = 3;
            //var t = (sum, count);
            //Console.WriteLine($"Sum of {t.count} elements is {t.sum}.");

            
            
            var a = 1;
            var t = (a, b: 2, 3);
            Console.WriteLine($"The 1st element is {t.Item1} (same as {t.a}).");
            Console.WriteLine($"The 2nd element is {t.Item2} (same as {t.b}).");
            Console.WriteLine($"The 3rd element is {t.Item3}.");
            // Output:
            // The 1st element is 1 (same as 1).
            // The 2nd element is 2 (same as 2).
            // The 3rd element is 3.




            (int, double) t1 = (17, 3.14);
            (double First, double Second) t2 = (0.0, 1.0);
            t2 = t1;
            Console.WriteLine($"{nameof(t2)}: {t2.First} and {t2.Second}");
            // Output:
            // t2: 17 and 3.14

            (double A, double B) t3 = (2.0, 3.0);
            t3 = t2;
            Console.WriteLine($"{nameof(t3)}: {t3.A} and {t3.B}");
            // Output:
            // t3: 17 and 3.14


            //var t = ("post office", 3.6);
            //(string destination, double distance) = t;
            //Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            //// Output:
            //// Distance to post office is 3.6 kilometers.


            //var t = ("post office", 3.6);
            //var (destination, distance) = t;
            //Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
            //// Output:
            //// Distance to post office is 3.6 kilometers.


            //(int a, byte b) left = (5, 10);
            //(long a, int b) right = (5, 10);
            //Console.WriteLine(left == right);  // output: True
            //Console.WriteLine(left != right);  // output: False

            //var t1 = (A: 5, B: 10);
            //var t2 = (B: 5, A: 10);
            //Console.WriteLine(t1 == t2);  // output: True
            //Console.WriteLine(t1 != t2);  // output: False


            //var limitsLookup = new Dictionary<int, (int Min, int Max)>()
            //{
            //    [2] = (4, 10),
            //    [4] = (10, 20),
            //    [6] = (0, 23)
            //};

            //if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
            //{
            //    Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
            //}
            //// Output:
            //// Found limits: min is 10, max is 20
        }

        public class MyClass
        {

        }
    }
}
