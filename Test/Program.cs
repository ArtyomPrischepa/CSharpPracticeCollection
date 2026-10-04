var result = Task.Run(async () => 5);
await result;
Console.WriteLine(result.Result);