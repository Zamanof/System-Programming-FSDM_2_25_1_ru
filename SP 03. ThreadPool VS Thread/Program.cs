// ThreadPool VS Thread

using System.Diagnostics;

int opeartionsCount = 10000;

var watch = new Stopwatch();

watch.Start();

//UseThread(opeartionsCount);
UseThreadPool(opeartionsCount);

watch.Stop();
Console.WriteLine($"{watch.ElapsedMilliseconds} milliseconds");


void UseThread(int operationsCount)
{
    List<int> ids = new();
    using (var count = new CountdownEvent(operationsCount))
    {
        Console.WriteLine("Threads...");
        for (int i = 0; i < operationsCount; i++)
        {
            var thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                if (!ids.Contains(Thread.CurrentThread.ManagedThreadId))
                {
                    ids.Add(Thread.CurrentThread.ManagedThreadId);
                }

                count.Signal();
            });
            thread.Start();
        }
        count.Wait();
    }
    //Console.WriteLine($"Threads used threads count = {ids.Count}");
}

void UseThreadPool(int operationsCount)
{
    List<int> ids = new();
    using (var count = new CountdownEvent(operationsCount))
    {
        Console.WriteLine("ThreadPool threads");
        for (int i = 0; i < operationsCount; i++)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Thread.Sleep(1000);
                if (!ids.Contains(Thread.CurrentThread.ManagedThreadId))
                {
                    ids.Add(Thread.CurrentThread.ManagedThreadId);
                }
                count.Signal();
            });
        }
        count.Wait();
    }
    //Console.WriteLine($"ThreadPool used threads count = {ids.Count}");
}
