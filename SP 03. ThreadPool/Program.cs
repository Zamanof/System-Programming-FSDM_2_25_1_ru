// ThreadPool
/*
CLR-ские потоки(Threat) из пула(Thread Poll)

1. class ThreadPool 

2. Winform Timer

3. Асинхронные методы(.BeginInvoke(), .EndInvoke()) - устаревшие методы
Не путать с async/await

4. TPL - Task Parallel Library

...
*/

//ThreadPool
//    .GetAvailableThreads(out int workerCount, out int complCount);
//Console.WriteLine($"Worker threads count = {workerCount}");
//Console.WriteLine($"Completation threads count = {complCount}");

Console.WriteLine("Main method start...");
//Console.WriteLine($"Main thread is ThreadPoll thread? -> {Thread.CurrentThread.IsThreadPoolThread}");
//Console.WriteLine($"Main thread is background thread? -> {Thread.CurrentThread.IsBackground}");

ThreadPool.QueueUserWorkItem(SomeOperations!, "Salam");

ThreadPool.QueueUserWorkItem(_ =>
{
    OtherOperations();
});


Console.WriteLine("Main method end...");
Console.ReadLine();

void SomeOperations(object state)
{
    Console.WriteLine($"""

        SomeOperations method start...
        State:              {state}
        ThreadId:           {Thread.CurrentThread.ManagedThreadId}
        IsBackground:       {Thread.CurrentThread.IsBackground}
        IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
        """);
}

void OtherOperations()
{
    Console.WriteLine($"""

        OtherOperations method start...
        ThreadId:           {Thread.CurrentThread.ManagedThreadId}
        IsBackground:       {Thread.CurrentThread.IsBackground}
        IsThreadPool:       {Thread.CurrentThread.IsThreadPoolThread}
        """);
}