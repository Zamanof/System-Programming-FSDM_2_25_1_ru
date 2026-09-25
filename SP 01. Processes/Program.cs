// Processes

using System.Diagnostics;

//Process.Start("calc");
//Process.Start("mspaint");
//Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");


//Console.WriteLine(Process.GetCurrentProcess().ProcessName);
//Console.WriteLine(Process.GetCurrentProcess().Id);
//Console.WriteLine(Process.GetCurrentProcess().BasePriority);

//Console.ReadLine();

//var processes = Process.GetProcesses();


//foreach (var process in processes)
//{
//    Console.WriteLine($"{process.Id}. {process.ProcessName} -> Threads: {process.Threads.Count}");
//}

//var calc = Process.GetProcessById(31368);

//calc.Kill();

//var calculators = Process.GetProcessesByName("CalculatorApp");
//var count = calculators.Length;
//Console.WriteLine(count);

//foreach (var process in calculators)
//{
//    Console.WriteLine($"{process.Id}. {process.ProcessName} -> Threads: {process.Threads.Count}");
//    process.Kill();
//}