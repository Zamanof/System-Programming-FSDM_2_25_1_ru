// Threads

//Console.WriteLine($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId}");
//Console.WriteLine($"Main Thread IsBackground: {Thread.CurrentThread.IsBackground}");

Console.WriteLine("Start");

Thread thread1 = new Thread(() =>
{
    int summ = 0;
    for (int i = 0; i < 10; i++)
    {
        summ += i;
        Thread.Sleep(100);
        Console.WriteLine($"\tThread1 Id: {Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
    Console.WriteLine($"Thread1 sum =  {summ}");
});
Thread thread2 = new Thread(Some);

//thread1.IsBackground = true;
//thread2.IsBackground = true;

//thread1.Priority = ThreadPriority.Highest;
//thread2.Priority = ThreadPriority.Lowest;

thread1.Start();
thread2.Start();

int summ = 0;
for (int i = 0; i < 100; i++)
{
    summ += i;
    Console.WriteLine($"Main Thread Id: {Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
}
Console.WriteLine($"Main sum =  {summ}");
thread1.Join(); // .Join() Заставляет вызывающий Thread подождать вызываемый Thread

//ConsoleKeyInfo key = default;
//while (true)
//{
//    key = Console.ReadKey();

//    if (key.Key == ConsoleKey.Enter)
//    {
//        thread1.Interrupt();
//        break;
//    }
//}


Console.WriteLine("End");
void Some()
{
    int summ = 0;
    for (int i = 0; i < 10; i++)
    {
        summ += i;
        Thread.Sleep(100);
        Console.WriteLine($"\t\tSome Method Thread Id: {Thread.CurrentThread.ManagedThreadId} - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
    Console.WriteLine($"Some method sum =  {summ}");
}
