using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("--- Старт практики --- \n");

        // ЗАДАЧА 1: Вызовите метод FetchDataAsync("error"), оберните в try-catch и выведите Message ошибки.
        try
        {
            await FetchDataAsync("error");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        // ЗАДАЧА 2: Вызовите метод FireAndForgetVoidAsync("fail"). Сделайте так, чтобы приложение не упало.
        FireAndForgetVoidAsync("fail");
        await Task.Delay(1000);
        // ЗАДАЧА 3: Запустите FetchDataAsync("invalid"), сохраните объект Task в переменную. 
        // Не используя await напрямую, дождитесь завершения (например, через try { await task; } catch) 
        // и выведите в консоль свойства task.IsFaulted и task.Status.
        var task = FetchDataAsync("invalid");
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"IsFaulted: {task.IsFaulted}");
            Console.WriteLine($"Status: {task.Status}");

        }
        // ЗАДАЧА 4: Запустите одновременно три задачи с помощью Task.WhenAll:
        // FetchDataAsync("valid"), FetchDataAsync("err_A"), FetchDataAsync("err_B").
        // В блоке catch выведите абсолютно все ошибки из свойства Exception.InnerExceptions общего таска.
        var tasks = Task.WhenAll(FetchDataAsync("valid"), FetchDataAsync("err_A"), FetchDataAsync("err_B"));
        try
        {
            await tasks;
        }
        catch (Exception)
        {
            foreach (Exception ex in tasks.Exception!.InnerExceptions)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
        Console.WriteLine("\n--- Практика завершена ---");
    }

    // Вспомогательные методы для выполнения заданий
    static async Task FetchDataAsync(string mode)
    {
        await Task.Delay(100);
        if (mode.StartsWith("err") || mode == "error" || mode == "invalid")
            throw new InvalidOperationException($"Ошибка запроса с параметром: {mode}");

        Console.WriteLine($"Успешно обработано: {mode}");
    }

    static async void FireAndForgetVoidAsync(string mode)
    {
        // Подсказка к Задаче 2: async void методы требуют внутренней обработки ошибок
        try
        {
            await Task.Delay(100);
            throw new AccessViolationException("Критический сбой в async void!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


    }
}
