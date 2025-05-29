using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
       
        //task isCompleted 
        Task task = SimulateWorkAsync();

        Console.WriteLine($"IsCompleted (before await): {task.IsCompleted}"); // Should be false

        await task;

        Console.WriteLine($"IsCompleted (after await): {task.IsCompleted}"); // Should be true

    }
    static async Task SimulateWorkAsync()
    {
        await Task.Delay(2000); // Simulate some work
        Console.WriteLine("Work completed.");
    }
}
