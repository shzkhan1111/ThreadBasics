/*
 Thread sync 
Per A and B have joint account 
having $1000  
A and B ask bank teller 
for $800 
at the same time
Teller A and B (TA,TB) see $1000 will give $800 to both A and B
bank loses $600
 */
//add 1 to counter 
//Wrong implementation
//race condition
int counter = 0; // shared resource

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
        counter++;
    }
}