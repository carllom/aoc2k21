﻿using aoc2k21;
using System.Diagnostics;

/// <summary>
/// https://adventofcode.com/2021
/// </summary>

var tasks = new (IAocTask Prog, string InputFile)[]
{
    new (new Day1(), "data/1-sonar-sweep.txt"),
    new (new Day2(), "data/2-dive.txt"),
    new (new Day3(), "data/3-binary-diagnostic.txt"),
    //new (new DayX(), "data/X-???.txt"),
};

// Param "all" runs all days
if (args.Length > 0 && args[0].ToLowerInvariant() == "all")
{
    for (int i = 0; i < tasks.Length; i++)
    {
        var t = tasks[i];
        Run(i+1, t.Prog, t.InputFile);
    }
    return;
}

// Param is Day# to run (default to last day in task list)
if (args.Length == 0 || !int.TryParse(args[0].ToString(), out var day))
    day = tasks.Length;

day = Math.Clamp(day, 1, tasks.Length); // Ensure day# is in valid range

var task = tasks[day - 1];
Run(day, task.Prog, task.InputFile);


static void Run(int day, IAocTask task, string inputFile)
{
    var sw = new Stopwatch();
    Console.WriteLine($"=== Day {day} ===");
    sw.Restart();
    var task1result = task.Task1(inputFile);
    sw.Stop();
    Console.WriteLine($"Task #1({sw.Elapsed.TotalMilliseconds}ms) = {task1result}");
    sw.Restart();
    var task2result = task.Task2(inputFile);
    sw.Stop();
    Console.WriteLine($"Task #2({sw.Elapsed.TotalMilliseconds}ms) = {task2result}");
}