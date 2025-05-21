void WriteThreadId()
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(10); // Sleep for 10 milliseconds
    }
}
#region blocking thread
//#1
WriteThreadId();//in the main thread is blocking will be printed first must be completed before child thread start
//start another thread use thread class
//takes a delegate
#endregion
Thread thread1  = new Thread(WriteThreadId); // will write a different value as compared to the first one #1
thread1.Start();


Thread thread2 = new Thread(WriteThreadId); 
thread2.Start();

// may switch from thread1 to thread 2 based on the thread scheduler


#region non blocking thread
WriteThreadId(); // changing the placement will make it non blocking running it second 
#endregion