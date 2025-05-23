
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
        lock (counterlock)
        {
            //critical section
            counter++;
            //if execption lock has try catch finally mechanism  
            //lock will be released 
        }
    }
}