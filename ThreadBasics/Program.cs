Console.WriteLine("Simulating Server Request ");

//implementr queue 
//monitor
//Request processor
/*
 in the given case input wont be blocked 
you enter text 
its entered into the request queue
the monitorThread takes it out of the queue 
and processes it
 */
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