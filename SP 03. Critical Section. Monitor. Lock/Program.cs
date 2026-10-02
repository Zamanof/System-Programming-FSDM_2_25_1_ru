#region Albahari tricks
// First trick

//for (int i = 0; i < 10; i++)
//{
//    new Thread(() =>
//    {
//        Console.WriteLine(i);
//    }).Start();
//}

// solve
//for (int i = 0; i < 10; i++)
//{
//    int a = i;
//    new Thread(() =>
//    {
//        Console.WriteLine(a);
//    }).Start();
//}

// Second trick
//string name = "Nadir";
//Thread thread1 = new(() =>
//{
//    Console.WriteLine(name);
//});

//name = "Zaman";

//Thread thread2 = new(() =>
//{
//    Console.WriteLine(name);
//});

//thread1.Start();
//thread2.Start();
#endregion


// 

#region Race condition, Critical section
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Counter.count++;

//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.count);
#endregion

#region Interlocked
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Interlocked.Increment(ref Counter.count);
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.count);
#endregion

#region Interlocked problem
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            if (Counter.count % 2 == 0) Interlocked.Increment(ref Counter.even);
//            Interlocked.Increment(ref Counter.count);
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine($" Count: {Counter.count}");
//Console.WriteLine($"Even count: {Counter.even}");
#endregion

#region Monitor
//Thread[] threads = new Thread[5];
//object o = new();

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {

//        for (int j = 0; j < 1000000; j++)
//        {
//            try
//            {
//                Monitor.Enter(o);
//                if (Counter.count % 2 == 0) 
//                    Counter.even++;
//                Counter.count++;
//            }
//            finally
//            {
//                Monitor.Exit(o);
//            }

//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine($" Count: {Counter.count}");
//Console.WriteLine($"Even count: {Counter.even}");
#endregion

#region Lock
Thread[] threads = new Thread[5];
object o = new();

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new(() =>
    {

        for (int j = 0; j < 1000000; j++)
        {
            lock (o)
            {
                if (Counter.count % 2 == 0)
                    Counter.even++;
                Counter.count++;
            }
        }
    });
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}

for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine($" Count: {Counter.count}");
Console.WriteLine($"Even count: {Counter.even}");
#endregion

// Mutex, Semaphore