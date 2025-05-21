void WriteThreadId()
{
    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
}

WriteThreadId();
//start another thread use thread class
//takes a delegate

Thread thread1  = new Thread(WriteThreadId);
thread1.Start();