namespace ThreadBasics
{
    class Program
    {
        private static event Action EventFinished = () => { };

        static void Main(string[] args)
        {
            Console.WriteLine("Before Running Blocking Thread");
            //issue thread when blocked is idle and uuused 
            var blockingThread = new Thread(() =>
            {
                Console.WriteLine("Blocking thread started");
                Thread.Sleep(5000); // Simulate a blocking operation
                Console.WriteLine("Blocking thread finished");
            });
            blockingThread.Start();
            blockingThread.Join();
            Console.WriteLine("After Running Blocking Thread");

            // Another approach: use polling to check for completion
            // Constantly polling the thread state
            //polling set a flag is also slow and insufficent 
            var pollingThread = new Thread(() =>
            {
                Console.WriteLine("Polling thread started");
                Thread.Sleep(5000); // Simulate a blocking operation
                Console.WriteLine("Polling thread finished");
            });
            pollingThread.Start();
            while (pollingThread.IsAlive)
            {
                Console.WriteLine("Polling thread is still running...");
                Thread.Sleep(1000); // Poll every second
            }

            #region Event-Based Approach

            Console.WriteLine("Before Running Event-Based Thread");

            var event_thread = new Thread(() =>
            {
                Console.WriteLine("Event-based thread started");
                Thread.Sleep(5000); // Simulate a blocking operation
                Console.WriteLine("Event-based thread finished");
                // Event finished, inform listeners
                EventFinished();

                //issue
                //call back is happening on different thread
            });

            //call back to exec when event finished 
            EventFinished += () => Console.WriteLine("Event-based thread completed");
            event_thread.Start();

            Console.WriteLine("After Event thread fired");
            #endregion
        }
    }
}