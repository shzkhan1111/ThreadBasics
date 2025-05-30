using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadBasics
{
    class Program
    {
        static async Task Main(string[] args) // ✅ Must return Task for async Main
        {
            Console.WriteLine($"1 - {Thread.CurrentThread.ManagedThreadId}");



            var task = Task.Run(() =>
            {
                Console.WriteLine($"2 - {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"3 - {Thread.CurrentThread.ManagedThreadId}");

            await task;

            Console.WriteLine($"4 - {Thread.CurrentThread.ManagedThreadId}");


            Console.WriteLine($"1.1 - {Thread.CurrentThread.ManagedThreadId}");

            var task1 = Task.Run(() =>
            {
                Console.WriteLine($"1.2 - {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"1.3 - {Thread.CurrentThread.ManagedThreadId}");

            task1.Wait();

            Console.WriteLine($"1.4 - {Thread.CurrentThread.ManagedThreadId}");

        }
    }
}
