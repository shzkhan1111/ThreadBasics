//monitor 
//monitor the critical section 
//lock simple form of monitor but monitor gives you more control 

/*
 * monitor enter 
 * 
 * critical section 
 * 
 * monitor exit 
 */


int counter = 0; // shared resource

//exclusive lock only 1 thread can enter 
object counterlock = new object();

Thread threadA = new Thread(IncrementCounter);
Thread threadB = new Thread(IncrementCounter);

threadA.Start();
threadB.Start();

threadA.Join();
threadB.Join();

Console.WriteLine($"Final Counter Value is {counter}");


void IncrementCounter()
{
    for (int i = 0; i < 1000000; i++)
    {
        //exclusive lock only 1 thread can enter 
        //Monitor.Enter(counterlock);
        Monitor.TryEnter(counterlock , 2000);//2 sec wait time wait for 2 sec

        try
        {
            counter++;
        }
        finally
        {
            Monitor.Exit(counterlock);
        }
        

    }
}