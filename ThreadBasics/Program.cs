/*
 * Semaphore
 * Most Often usen to control/limit number of thread 
 * 
 * look at lecture 4 basic solution 
 *
 *
Queue<string> requestQueue = new Queue<string>();

Thread monitorThread = new Thread(MonitorQueue);
monitorThread.Start();



while (true)
{
    string input = Console.ReadLine();
    if (input == "exit")
    {
        Console.WriteLine("Exiting");

        break;
    }
    //SimulateServerRequest(input);
    requestQueue.Enqueue(input);

}

//worker thead can cause race condition
 void MonitorQueue()
{
    while (true)
    {
        if (requestQueue.Count > 0)
        {
            string input = requestQueue.Dequeue();
            Thread thread = new Thread(() => SimulateServerRequest(input));
            thread.Start();
        }
        Thread.Sleep(1000);
    }
}

static void SimulateServerRequest(string input)
{
    Thread.Sleep(1000);
    Console.WriteLine($"Server Request {input} Completed");
}


using this many thread can be created 

Semaphore can be used system wide
using semaphoreSlim s = new Semaphore(3,3)
3 process can exec the code
semphore.wait()//now we are entering inti the protected section  

Initail thread comes can sees semaphore.wait it will decrease its count 
it will enter and decrease the counter 
4th thread sees 0 and it will be released 

finally{semaphore.release() counter++}




 */




Queue<string> requestQueue = new Queue<string>();

using SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 3, maxCount: 3);

Thread monitorThread = new Thread(MonitorQueue);
monitorThread.Start();



while (true)
{
    string input = Console.ReadLine();
    if (input == "exit")
    {
        Console.WriteLine("Exiting");

        break;
    }
    //SimulateServerRequest(input);
    requestQueue.Enqueue(input);

}

//worker thead can cause race condition
void MonitorQueue()
{
    while (true)
    {
        if (requestQueue.Count > 0)
        {
            string input = requestQueue.Dequeue();
            semaphore.Wait();//like global counter 
            Thread thread = new Thread(() => SimulateServerRequest(input));
            thread.Start();
        }
        Thread.Sleep(1000);
    }
}

 void SimulateServerRequest(string input)
{
    try
    {
        Thread.Sleep(1000);
        Console.WriteLine($"Server Request {input} Completed");

    }
    finally
    {
        var previous_count = semaphore.Release(); 
        Console.WriteLine($"Thread:: {Thread.CurrentThread.ManagedThreadId} released semaphore {previous_count}");
    }
    //release when process finishes 
}

