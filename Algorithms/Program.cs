using Algorithms.Sorting;

namespace Algorithms;

internal class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        var array = Enumerable
            .Range(1, 17)
            .OrderBy(x => random.Next())
            .ToArray();
        Console.WriteLine(string.Join(' ', array));

        var r = MergeSort.Sort(array);
        Console.WriteLine(string.Join(' ', r));
    }
}
