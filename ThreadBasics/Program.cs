using AutoResetEvent autoResetEvent = new AutoResetEvent(false); //false I want the sign to be turned off initially 

//dispose unmanaged resources 

////consumeer will call Autoreset waitone  I am waiting for something 

//autoResetEvent.WaitOne();

////producer will say I have something for you 
//autoResetEvent.Set();//set turn on the signal 
////once consumer consumes the signal is turned off

string userInput = null;
Console.WriteLine("Write a for worker thread to start");
//Thread thread = new Thread(Worker);
//thread.Start(); 

//crating 3 worker thread
for (int i = 0; i < 3; i++) 
{
    Thread thread = new Thread(Worker);
    thread.Name = $"Worker {i + 1}";
    thread.Start();
}

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
        Console.WriteLine($"{Thread.CurrentThread.Name} is waiting");
        autoResetEvent.WaitOne();
        //when I recieve  the signal I will proceed with my task 

        Console.WriteLine($"{Thread.CurrentThread.Name} proceeds");
        Thread.Sleep(3000);
        //after 2 second it will wait for another signal 

    }
}