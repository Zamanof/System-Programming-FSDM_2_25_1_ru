
using System.Collections.Concurrent;

object consoleLock = new();

Console.CursorVisible = false;

int ordersCount = 200;

List<string> dishes = [
    "Pizza",
    "Burger",
    "Soup",
    "Steak",
    "Salad",
    "Roll",
    "Plov",
    "Kebab",
    "Sushi",
    ];

ConcurrentDictionary<int, int> threadStatistic = new();

using CountdownEvent countdown = new(ordersCount);

Console.WriteLine("""
    ==========================================
            RESTAURANT THREADPOOL DEMO
    ==========================================

    """);

ThreadPool.GetMaxThreads(
    out int maxWorkerThreads,
    out int maxIOThreads
    );

ThreadPool.GetAvailableThreads(
    out int availableWorkerThreads,
    out int availableIOThreads
    );

Console.WriteLine($"MaxWorkerThreads = {maxWorkerThreads}");
Console.WriteLine($"MaxIOThreads = {maxIOThreads}");
Console.WriteLine($"AvailableWorkerThreads = {availableWorkerThreads}");
Console.WriteLine($"AvailableIOThreads = {availableIOThreads}");
for (int i = 1; i <= ordersCount; i++)
{
    int orderId = i;

    ThreadPool.QueueUserWorkItem(_ =>
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;

        string dish = dishes[Random.Shared.Next(dishes.Count)];

        int cookingTime = Random.Shared.Next(1000, 4000);

        threadStatistic.AddOrUpdate(
            threadId,
            1,
            (_, oldValue) => oldValue + 1
        );

        Print($"""

            [START] Order #{orderId,2} 
            {dish,-8}                  
            Chef Thread #{threadId,2}
            {cookingTime} ms

            """
        );

        Thread.Sleep(cookingTime);

        Print($"""

            [DONE] Order #{orderId,2} 
            {dish,-8}                  
            Chef Thread #{threadId,2}
            {cookingTime} ms

            """
        );

        countdown.Signal();
    });
}

countdown.Wait();

Console.WriteLine();
Console.WriteLine("==========================================");
Console.WriteLine("               STATISTICS");
Console.WriteLine("==========================================");
Console.WriteLine();

Console.WriteLine($"Orders completed : {ordersCount}");
Console.WriteLine($"Threads used      : {threadStatistic.Count}");
Console.WriteLine();

Console.WriteLine("Orders processed by each thread:");
Console.WriteLine();

foreach (var item in threadStatistic.OrderBy(x => x.Key))
{
    Console.WriteLine(
        $"Thread #{item.Key,2} -> {item.Value} orders"
    );
}

Console.WriteLine();
Console.WriteLine("==========================================");
Console.WriteLine("          ALL ORDERS ARE READY!");
Console.WriteLine("==========================================");

Console.CursorVisible = true;

void Print(string message)
{
    lock (consoleLock)
    {
        Console.WriteLine(
            $"{DateTime.Now:HH:mm:ss.fff} | {message}"
        );
    }
}
