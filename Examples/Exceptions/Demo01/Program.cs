
Console.WriteLine("Main thread ID: " + Thread.CurrentThread.ManagedThreadId);

MyMethod();

Thread.Sleep(500); // 確保來得及輸出 Worker thread ID。

void MyMethod()
{
    try
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Worker thread ID: " + Thread.CurrentThread.ManagedThreadId);
            throw new NotImplementedException();
        });

        task.Wait();
    }
    catch (Exception ex) 
    {
        Console.WriteLine("捕捉到異常! " + ex.GetType().FullName);
    }
}


// Output: (注意程式並未顯示補捉到異常!)
// Main thread ID: 1
// Worker thread ID: 6