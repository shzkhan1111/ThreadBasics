object userLock = new object();
object orderlock = new object();

Thread thread = new Thread(ManageOrder);
thread.Start();

//main thread
ManageUser();

thread.Join();
Console.WriteLine("Program Finished");
Console.ReadLine();
void ManageUser()
{


    lock (userLock)
    {
        Console.WriteLine("User Management Aquired user lock");
        Thread.Sleep(2000);


        lock (orderlock)
        {
            //nested lock not printed 
            Console.WriteLine("User Management Aquired order lock");
                
        }
    }
}
void ManageOrder()
{
    lock (orderlock)
    {
        Console.WriteLine("User Management Aquired user lock");
        Thread.Sleep(1000);


        lock (userLock)
        {
            //nested lock not printed 

            Console.WriteLine("User Management Aquired order lock");

        }
    }
}