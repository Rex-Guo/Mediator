using Mediator;
using System;

namespace Basic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dispatch = new DispatchBuilder().Build();
            var cmd = new TestCommand();
            string result = dispatch.DispatchAsync(cmd).Result;
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}