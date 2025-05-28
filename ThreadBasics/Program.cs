using System;
using System.IO;
//asyncronous programming example 

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting synchronous file read...");

        // This will block the thread until the file is completely read
        Task<bool> resasync = DBOperation(); //2 resasync now holds a reference to a Task<bool> that will complete in 2 seconds
        Console.WriteLine("Do some other task not related to file");
        
        var res = await resasync;//Control returns here after 2 seconds
        if (res)
        {
            Console.WriteLine("Finished synchronous operation.");
        }
        else
        {
            Console.WriteLine("Incomplete asynchronous operation.");
        }

    }

    static async Task<bool> DBOperation()
    {
        Console.WriteLine("Operation Started");
        await Task.Delay(2000);//1 paused further execution and returns to the main thread 
        return true;
    }
}