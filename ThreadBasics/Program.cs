using ManualResetEventSlim manualResetEvent = new ManualResetEventSlim(false);

//manualResetEvent.Set();//turn on the signal 
//manualResetEvent.Reset();//turn off the signal


//multiple threads released at the same time 

for (int i = 0; i < 3; i++)
{
    Thread thread = new Thread(Work);
    thread.Name = $"Thread {i}";
    thread.Start();
}

Console.WriteLine("To Release All Threads Press Enter");
Console.ReadLine();
manualResetEvent.Set();// give signal from producer to proceed like npm i
Console.ReadLine();

void Work()
{
    Console.WriteLine("Waiting for signal...");
    manualResetEvent.Wait(); // Wait until the signal is set
    //in auto reset as soon as it recieves the signal it resets 
    //since reset is manullly all threads can enter
    Thread.Sleep(1000);
    Console.WriteLine("Signal received, continuing work...");
}