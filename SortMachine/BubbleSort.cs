namespace Algorithms.Sorting;

public static class BubbleSort
{
    public static ICollection<int> Sort(ICollection<int> collection)
    {
        var array = collection.ToArray();
        int shiftCounter;
        do
        {
            shiftCounter = 0;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                shiftCounter += ShiftElement(i, i + 1, array);
            }
        } while (shiftCounter > 0);

        return array;
    }

    private static int ShiftElement(int indexA, int indexB, IList<int> array)
    {
        if (array[indexA] > array[indexB])
        {
            (array[indexB], array[indexA]) = (array[indexA], array[indexB]);
            return 1;
        }

        return 0;
    }
}
