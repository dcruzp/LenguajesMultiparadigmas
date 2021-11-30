using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListComprehension
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(0, 10);
            var evens = from num in numbers where num % 2 == 0 select num;

            //var foo = new List<int> { 1, 2, 3 };
            //var bar = foo.ConvertAll(x => x * 2);  //list comprehension 
            //Console.WriteLine(string.Join(" ", bar)); // should print 2,4,6

            //List<Foo> fooList = new List<Foo>();
            //IEnumerable<string> extract = from foo in fooList where foo.Bar > 10 select foo.Name.ToUpper();

            //List<Foo> fooList = new List<Foo>();
            //IEnumerable<string> extract = fooList.Where(foo => foo.Bar > 10)
            //                                     .Select(foo => foo.Name.ToUpper());

            //List<Foo> fooList = new List<Foo>();
            //IEnumerable<string> extract = fooList.Where((foo, index) => foo.Bar > 10 + index)
            //                                     .Select(foo => foo.Name.ToUpper());

            List<int> foo = new List<int>(new int[] { 1, 2, 3 });
            var bar = foo.ConvertAll(new Converter<int, int>(delegate (int x) { return x * 2; }));
            Console.WriteLine(string.Join(" ", bar));

        }
    }
}
