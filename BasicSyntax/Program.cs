void WriteThreadId()
{
    for(int i = 0; i<100; i++)
    {
        Console.WriteLine(Thread.CurrentThread.Name);
        Thread.Sleep(50); // This takes long so time slices in scheduler will change order
    }


}

Thread thread = new Thread(WriteThreadId);
Thread thread2 = new Thread(WriteThreadId);

thread2.Name = "Thead2";
thread.Name = "Thead";
Thread.CurrentThread.Name = "Main Thread";

//Assigning thread priority to influece order
thread.Priority = ThreadPriority.Highest;
thread2.Priority = ThreadPriority.Lowest;
Thread.CurrentThread.Priority = ThreadPriority.Normal;

//Executing threads
thread.Start();
thread2.Start();
WriteThreadId();

Console.ReadLine();