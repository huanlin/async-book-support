
await MyMethod();

async Task MyMethod()
{
    try
    {
        await new HttpClient().GetStringAsync("https://microsoft.com");
        throw new NotImplementedException();
    }
    catch
    {
        Console.WriteLine("捕捉到異常!");
    }
}

// Output: 捕捉到異常! 