int[] arr = { 1 ,2,3 ,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5};

int sumArr(int start , int end)
{
    int s = 0;

    for (int i = start; i < end; i++)
    {
        Thread.Sleep(100);
        s += arr[i];
    }
    return s;
}

int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
int numberofthread = 4;
int size = arr.Length / numberofthread;
Thread[] threads = new Thread[numberofthread];

threads[0] = new Thread(() => { sum1 = sumArr(0, size); });
threads[1] = new Thread(() => { sum2 = sumArr(size,2 * size); });
threads[2] = new Thread(() => { sum1 = sumArr(2 * size, 3 * size); });
threads[3] = new Thread(() => { sum1 = sumArr(3 * size, arr.Length); });

foreach (Thread thread in threads)
{
    thread.Start();
}
foreach (Thread thread in threads)
{
    thread.Join();
}

DateTime start = DateTime.Now;



DateTime end = DateTime.Now;


var timespamn = end - start;

Console.WriteLine($"Time taken: {timespamn.TotalMilliseconds} ms");
