using System;
using System.Linq;
using Strategy.Core;
using Strategy.Core.Behaviors;

namespace Strategy.Demo
{
    /*
     * Достоинства паттерна Strategy:
     * - систему проще поддерживать и модифицировать, так как семейство алгоритмов перенесено в отдельную иерархию классов;
     * - есть возможность замены одного алгоритма другим в процессе выполнения программы;
     * - скрыты детали реализации алгоритмов от клиента.
     * Недостатки паттерна Strategy:
     * - для правильной настройки системы пользователь должен знать об особенностях всех алгоритмов;
     * - число классов в системе, построенной с применением паттерна Strategy, возрастает.
     */

    class Program : StrategyContext
    {
        private static void Main()
        {
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    "Choose sort strategy:",
                    $"1. {SortType.Bubble}",
                    $"2. {SortType.Heap}",
                    $"3. {SortType.Shell}",
                    string.Empty,
                    "Press Ctrl+C to exit"));

            Console.CancelKeyPress += (_, e) => Environment.Exit(0);

            var random = new Random();

            while (true)
            {
                Console.Write("> ");

                IStrategyBehavior sortBehavior;

                try
                {
                    sortBehavior = GetSortBehavior(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Unknown strategy.");
                    continue;
                }

                var array = Enumerable.Repeat(0, 10).Select(i => random.Next(1, 99)).ToArray();
                Console.WriteLine($"Source array: {string.Join(" ", array)}");

                DoSort(array, sortBehavior);
                Console.WriteLine($"Sorted array: {string.Join(" ", array)}");

                Console.WriteLine();
            }
        }

        private static IStrategyBehavior GetSortBehavior(string s)
        {
            if (!Enum.TryParse(typeof(SortType), s, true, out var strategy))
                throw new ArgumentException();

            switch ((SortType)strategy)
            {
                case SortType.Bubble:
                    return new BubbleSortBehavior();
                case SortType.Heap:
                    return new HeapSortBehavior();
                case SortType.Shell:
                    return new ShellSortBehavior();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
