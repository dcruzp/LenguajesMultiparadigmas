using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace FuncionalesEnLenguajesMultiParadigma
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Prueba 
            //Func<int, int> square = (x) => { return x * x; };

            //Func<A, C> Compose<A, B, C>(Func<A, B> f, Func<B, C> g)
            //{
            //    return x => g(f(x));
            //}

            //Func<String, int> f1 = (str) =>
            //{
            //    return str == "ja" ? 1 : 0;
            //};

            //Func<int, bool> f2 = (x) =>
            //{
            //    return x == 1;
            //};

            //Func<String, bool> fComposed = Compose(f1, f2);

            //*//*Console.WriteLine(fComposed("ja"));*//*

            //Del hendle = DelegateMethod;

            //hendle("Hello World");

            /* int? maybe = 3423442; 
             if (maybe is int number)
             {
                 Console.WriteLine($"The nullable int 'maybe' has the value {number}"); 


             }
             else
             {
                 Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
             }*/

            //IEnumerable<int> numbers = Enumerable.Range(0, 10);
            //var evens = from num in numbers where num % 2 == 0 select num;

            //Console.WriteLine(string.Join("  ", evens));

            /*var foo = new List<int>() { 1, 2, 3 };
            var bar = foo.ConvertAll(x => x * 2);
            var bar1 = foo.ConvertAll(new Converter<int, int>(delegate (int x) { return x * 2; }));
            Console.WriteLine(string.Join(" ", bar1));*/

            //(int, double) t1 = (17, 3.14);
            //(double First, double Second) t2 = (0.0, 1.0);
            //t2 = t1;

            //Console.WriteLine($"{nameof(t2)}: {t2.First} and {t2.Second}");

            //(double A, double B) t3 = (2.0, 3.0);
            //t3 = t2;
            //Console.WriteLine($"{nameof(t3)}: {t3.A} and {t3.B}"); 

            //var t = ("post office", 3.6);
            //(string destination, double distance) = t;
            //Console.WriteLine($"Distance to {destination} is {distance} kilometers.");

            /*var t = ("post office", 3.6);
            var (destination, distance) = t;
            Console.WriteLine($"Distance to {destination} is {distance} kilometers.");*/

            /* (int a, byte b) left = (5, 10);
             (long a, int b) right = (5, 10);
             Console.WriteLine(left == right);*/
            /*
                        var a = new Fraction(5, 4);
                        var b = new Fraction(1, 2);

                        Console.WriteLine(-a);
                        Console.WriteLine(a + b);
                        Console.WriteLine(a - b);
                        Console.WriteLine(a * b);
                        Console.WriteLine(a / b);*/
            #endregion 

            //var stack = ImmutableStack<int>.Empty;

            //for (int i = 0; i < 10; i++)
            //{
            //    stack = stack.Push(i); 
            //}
            //Console.WriteLine("No of elements in original stack: " + stack.Count());
            //var newStack = stack.Pop();
            //Console.WriteLine("No of elements in new stack: " + newStack.Count());

            /*var list = ImmutableList.Create(1, 2, 3, 4, 5);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }*/

            var x = MakeAdder(10);
            var y = x(10);
            Console.WriteLine(y);
        }

        static Func<int,int> MakeAdder (int addend)
        {
            return delegate (int x)
            {
                return x + addend;
            };

            return x => x + addend; 
        }

        public static T  MidPoint<T> (IEnumerable<T> sequence)
        {
            if (sequence is  IList<T> list)
            {
                return list[list.Count / 2]; 
            }
            else if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence), "Sequence can't by null"); 
            }
            else
            {
                int helfLeft = sequence.Count() / 2 - 1;
                if (helfLeft < 0)
                    helfLeft = 0;
                return sequence.Skip(helfLeft).First();
            }
        }

        static string WaterState(int tempInFahrenheit) => tempInFahrenheit switch
        {
            (> 32) and (< 212) => "liquid",
            < 32 => "solid",
            > 212 => "gass",
            32 => "solid/liquid transition",
            212 => "liquid / gas transition",
        };

        public delegate void Del(string message); 

        public static void DelegateMethod (string message)
        {
            System.Console.WriteLine(message); 
        }
    }

    public readonly struct Fraction
    {
        private readonly int num;
        private readonly int den;

        public Fraction (int numerator , int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            }
            num = numerator;
            den = denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

        public static Fraction operator +(Fraction a, Fraction b) =>
            new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.num * b.num, a.den * b.den); 

        public static Fraction operator / (Fraction a , Fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException(); 
            }
            return new Fraction(a.num * b.den, a.den * b.num);
        }

        public override string ToString() => $"{num} / {den}"; 
    }
}
