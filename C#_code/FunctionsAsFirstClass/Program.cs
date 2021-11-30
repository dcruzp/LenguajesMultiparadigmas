using System;

namespace FunctionsAsFirstClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int, int> square = (x) => { return x * x; };
            //Func<A, C> Compose<A, B, C>(Func<A, B> f, Func<B, C> g)
            //{
            //    return x => g(f(x));
            //}
            //Func<string, int> f1 = (str) => {
            //    return str == "first" ? 1 : 0;
            //};
            //Func<int, bool> f2 = (x) => {
            //    return x == 1;
            //};

            //var fComposed = Compose(f1, f2);

            //Console.WriteLine(fComposed("second")); 

            Del handle = DelegateMethod;

            handle("Hello World");  // Hello world

        }

        public delegate void Del(string message);

        public static void DelegateMethod (string message)
        {
            Console.WriteLine("Hello World");
        }

    }
}

    

