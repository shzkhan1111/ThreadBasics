using System;
using System.IO;




void doSomethingElse()
{
    Thread.Sleep(1000);
    Console.WriteLine($"Doing something else...");

}


Console.WriteLine("Enter an input");
    string line = Console.ReadLine();
    //doSomethingElse(line); //I will block the thread
    Thread thread = new Thread(() => doSomethingElse());
    
    thread.Start();
    Console.WriteLine("you dont need to wait for me to do something");
    


