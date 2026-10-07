using System;
using System.Threading.Tasks;

// 1. Создаем три задачи с разной задержкой
var task1 = SlowOperationAsync("Задача 1", 1500);
var task2 = SlowOperationAsync("Задача 2", 500);
var task3 = SlowOperationAsync("Задача 3", 1000);

// TODO ЗАДАНИЕ №1:
// Дождитесь завершения ВСЕХ трех задач параллельно с помощью Task.WhenAll.
// Получите массив результатов выполнения и выведите его элементы в консоль.
int[] result = await Task.WhenAll(task1, task2, task3);
foreach (var item in result)
    Console.WriteLine(item);

// 2. Сброс задач для второго задания (запускаем заново)
task1 = SlowOperationAsync("Задача 1", 1500);
task2 = SlowOperationAsync("Задача 2", 500);
task3 = SlowOperationAsync("Задача 3", 1000);

// TODO ЗАДАНИЕ №2:
// Дождитесь завершения ХОТЯ БЫ ОДНОЙ (самой быстрой) задачи с помощью Task.WhenAny.
// Выведите в консоль результат выполнения этой первой завершившейся задачи.
var result2 = await Task.WhenAny(task1, task2, task3);
Console.WriteLine(await result2);
// Имитация асинхронной работы (возвращает количество миллисекунд)
async Task<int> SlowOperationAsync(string name, int delay)
{
    await Task.Delay(delay);
    return delay;
}
