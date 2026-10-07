using System;
using System.Linq;
using System.Collections.Generic;

// --- Исходные данные ---
string[] basicSkills = { "C#", "Git", "SQL", "HTML" };
string[] advancedSkills = { "SQL", "Docker", "C#", "Kubernetes" };

string[] dirtyData = { "C#", "SQL", "C#", "Git", "SQL" };

var teamAlpha = new List<Developer> { new("Tom"), new("Bob"), new("Sam") };
var teamBeta = new List<Developer> { new("Tom"), new("Alice"), new("Sam") };


// === ЗАДАНИЯ ДЛЯ САМОСТОЯТЕЛЬНОГО ВЫПОЛНЕНИЯ ===

// Задача 1: Получи навыки из basicSkills, которых нет в advancedSkills
var task1 = basicSkills.Except(advancedSkills);// Твой код здесь
Print("Задача 1 (Except):", task1);

// Задача 2: Найди общие навыки для basicSkills и advancedSkills
var task2 = basicSkills.Intersect(advancedSkills);// Твой код здесь
Print("Задача 2 (Intersect):", task2);

// Задача 3: Очисти массив dirtyData от повторений
var task3 = dirtyData.Distinct();// Твой код здесь
Print("Задача 3 (Distinct):", task3);

// Задача 4: Собери уникальный список навыков из basicSkills и advancedSkills (без дубликатов)
var task4 = basicSkills.Union(advancedSkills);// Твой код здесь
Print("Задача 4 (Union):", task4);

// Задача 5: Соедини basicSkills и advancedSkills так, чтобы дубликаты остались
var task5 = basicSkills.Concat(advancedSkills);// Твой код здесь
Print("Задача 5 (Concat):", task5);

// Задача 6: Найди разработчиков, которые есть ОДНОВРЕМЕННО и в teamAlpha, и в teamBeta
var task6 = teamAlpha.Intersect(teamBeta);// Твой код здесь
Print("Задача 6 (Сложные объекты):", task6.Select(d => d.Name));


// --- Вспомогательный код (не менять) ---
void Print<T>(string title, IEnumerable<T> collection) =>
    Console.WriteLine($"{title} [{string.Join(", ", collection)}]");

class Developer
{
    public string Name { get; }
    public Developer(string name) => Name = name;

    public override bool Equals(object? obj) => obj is Developer dev && Name == dev.Name;
    public override int GetHashCode() => Name?.GetHashCode() ?? 0;
}
