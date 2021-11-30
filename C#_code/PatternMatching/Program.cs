using System;
using System.Collections.Generic;
using System.Linq;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Null Checks
            //int? maybe = 12; 
            //if (maybe is int number)
            //{
            //    Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            //}
            //else
            //{
            //    Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            //}

            //string? message = "This is not the null string";

            //if (message is not null)
            //{
            //    Console.WriteLine(message);
            //} 
            #endregion


        }

        public static T MiPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list)
            {
                return list[list.Count / 2];
            }
            else if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence), "Sequence can't be null.");
            }
            else
            {
                int halfLength = sequence.Count() / 2 - 1;
                if (halfLength < 0)
                    halfLength = 0;
                return sequence.Skip(halfLength).First();
            }
        }
        //public Sate PerformOPeracion (String command)=> command switch
        //{
        //    "SystemTest" => RunDiagnostics(),
        //    "Start" => StartSystem(),
        //    "Stop" => StopSystem(),
        //    "Reset" => ResetToReady(),
        //    _ => throw new ArgumentException("Invalid string value for command", nameof(command)),
        //}


        //public record Order(int Item, decimal Cost);

        //public decimal CalculateDiscount(Order order) =>
        //order switch
        //{
        //    (Items: > 10, Cost: > 1000.00m) => 0.10m,
        //    (Items: > 5, Cost: > 500.00m) => 0.05m,
        //    Order { Cost: > 250.00m } => 0.02m,
        //    null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
        //    var someObject => 0m,
        //};

        //public decimal CalculateDiscount(Order order) =>
        //order switch
        //{
        //    ( > 10, > 1000.00m) => 0.10m,
        //    ( > 5, > 50.00m) => 0.05m,
        //    Order { Cost: > 250.00m } => 0.02m,
        //    null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
        //    var someObject => 0m,
        //};

        string WaterState(int tempInFahrenheit) => tempInFahrenheit switch
        {
            (> 32) and (< 212) => "liquid",
            < 32 => "solid",
            > 212 => "gas",
            32 => "solid/liquid transition",
            212 => "liquid / gas transition",
        };

        string WaterState2(int tempInFahrenheit) => tempInFahrenheit switch
        {
            < 32 => "solid",
            32 => "solid/liquid transition",
            < 212 => "liquid",
            212 => "liquid / gas transition",
            _ => "gas",
        };
    }
}
