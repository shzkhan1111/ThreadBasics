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
        if(Monitor.TryEnter(counterlock , 2000))//2 sec wait time wait for 2 sec
        {
            try
            {
                Thread.Sleep(2500);
                //Thread.Sleep(25);

                Console.WriteLine($"Counter = {counter++}");

            }
            finally
            {
                Console.WriteLine("Releasing Lock");
                Monitor.Exit(counterlock);
            }
        }
        else
        {
            Console.WriteLine("System is busy");
        }
        
        

    }
}