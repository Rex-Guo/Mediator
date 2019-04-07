using Mediator;
using System;

namespace Basic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dispatch = new DispatchBuilder().Build();
            string result = dispatch.DispatchAsync(new TestCommand()).Result;
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}