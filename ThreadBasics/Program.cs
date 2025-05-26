//farmer produce batch of food 
//when batch is ready 
//animal jump into feeding station 
//all thread finished -> Q is empty -> signal back to producer 

using System;
using System.Xml.Serialization;

Queue<int> queue = new Queue<int>();

ManualResetEventSlim consumeEvent = new ManualResetEventSlim(false);
//how would the consumer know that the producer is done producing?
//true as initally the consumer is waiting for the producer to produce something
ManualResetEventSlim produceEvent = new ManualResetEventSlim(true);
int consumerCount = 0;

object lockObject = new object();

Thread[] consumerThreads = new Thread[5];

for (int i = 0; i < 3; i++)
{
    consumerThreads[i] = new Thread(Consume);
    consumerThreads[i].Name = $"Consumer {i}";

    consumerThreads[i].Start();
}


while (true)
{
    produceEvent.Wait(); //block if the producer is not ready to produce
    produceEvent.Reset(); //reset the event so that it can be used again 

    Console.WriteLine("To Produce, Enter p");
    var input = Console.ReadLine();
    if (input?.ToLower()  == "p")
    {
        for(int i = 0; i < 10; i++)
        {
            queue.Enqueue(i);
            Console.WriteLine($"Produced: {i}");
            //tell consumer i have produced something 
        }
        //consume when the batch is ready 
        consumeEvent.Set();
    }

}

//define consumer

void Consume()
{
    while (true)
    {
        //wait for Producer set 
       consumeEvent.Wait();//block if batch is not ready
                           ////in readl world application make the queue thread safe
        while (queue.TryDequeue(out int item))
        {
            Thread.Sleep(500);
            Console.WriteLine($"Consumed: {item} from thread: {Thread.CurrentThread.Name}");
        }
        lock (lockObject)
        {
            consumerCount++;
        }
        if (consumerCount == 3)
        {
            consumeEvent.Reset();//turn off the signals consumer 

            //all 3 thread finished while loop 


            //how would the consumer know that the producer is done producing?
            produceEvent.Set(); //signal back to producer that the queue is empty

            consumerCount = 0;
            Console.WriteLine("All consumers finished consuming. Producer can produce again.");
        }
        
    }
}