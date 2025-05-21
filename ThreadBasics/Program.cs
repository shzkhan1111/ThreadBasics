void WriteThreadId()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        //Thread.Sleep(10); // Sleep for 10 milliseconds
    }
}
#region blocking thread
//#1
//WriteThreadId();//in the main thread is blocking will be printed first must be completed before child thread start
//start another thread use thread class
//takes a delegate
#endregion
Thread thread1  = new Thread(WriteThreadId); 
Thread thread2 = new Thread(WriteThreadId);

thread1.Priority = ThreadPriority.Highest;
thread2.Priority = ThreadPriority.Lowest;

//make the current priority normal
Thread.CurrentThread.Priority = ThreadPriority.Normal;

thread1.Start();
thread2.Start();


#region non blocking thread
WriteThreadId(); // changing the placement will make it non blocking running it second 

//before WriteThreadId() in the main thread is funished next line wont be executed
#endregion