using AutoResetEvent autoResetEvent = new AutoResetEvent(false); //false I want the sign to be turned off initially 
//dispose unmanaged resources 

////consumeer will call Autoreset waitone  I am waiting for something 

//autoResetEvent.WaitOne();

////producer will say I have something for you 
//autoResetEvent.Set();//set turn on the signal 
////once consumer consumes the signal is turned off

string userInput = null;
Console.WriteLine("Write a for worker thread to start");
Thread thread = new Thread(Worker);
thread.Start(); 

while (true)
{
    userInput = Console.ReadLine();
    if (userInput == "a")
    {
        //signal worker thread to start consuming 
        autoResetEvent.Set();
    }
}


//worker thread process 
void Worker()
{
    while (true)
    {
        Console.WriteLine("Worker thread infinite loop waiting for signal");
        autoResetEvent.WaitOne();
        //when I recieve  the signal I will proceed with my task 

        Console.WriteLine("Worker thread proceeds");
        Console.WriteLine("after 2 second I will wait for another signal ");
        Thread.Sleep(1000);
        //after 2 second it will wait for another signal 

    }
}