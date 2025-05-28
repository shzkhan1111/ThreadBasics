using System;
using System.IO;
//asyncronous programming example 

class Program
{
    static async Task Main()
    {

        Console.WriteLine("Starting asynchronous database operation...");

        //start a DB operation 
        Task<bool> dbOperationTask = DBOperationAsync();
        Console.WriteLine("Doing other unrelated work...");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Working on other task {i + 1}/3");
            await Task.Delay(2000); // Simulate other work
        }

        bool operationResult = await dbOperationTask;
        if (operationResult)
        {
            Console.WriteLine("Database operation completed successfully.");
        }
        else
        {
            Console.WriteLine("Database operation failed.");
        }
    }

    static async Task<bool> DBOperationAsync()
    {
        Console.WriteLine("Operation Started");
        await Task.Delay(2000);//1 paused further execution and returns to the main thread , Await doenst mean run on a background thread 
        //it means don't block while waiting
        return true;
    }
}