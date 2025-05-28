using System;
using System.IO;
//syncronous programming example 

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting synchronous file read...");

        // This will block the thread until the file is completely read
        bool res = DBOperation();
        Console.WriteLine("Do some other task not related to file");
        if (res)
        {
            Console.WriteLine("Finished synchronous operation.");
        }
        else
        {
            Console.WriteLine("Incomplete asynchronous operation.");
        }

    }

    static bool DBOperation()
    {
        Console.WriteLine("Operation Started");
        Task.Delay(2000).Wait();
        return true;
    }
}