namespace Algorithms.Sorting;

public static class MergeSort
{
    public static IList<int> Sort(IList<int> array)
    {
        if (array.Count == 1)
        {
            return array;
        }
        if (array.Count == 2)
        {
            Swap(array);
            return array;
        }

        var lengthA = array.Count / 2;

        var arrayA = array.Take(lengthA).ToArray();
        var arrayB = array.Skip(lengthA).ToArray();

        var newA = Sort(arrayA);
        var newB = Sort(arrayB);

        return [.. Merge(newA, newB)];

    }

    private static void Swap(IList<int> array)
    {
        if (array[0] > array[1])
        {
            (array[1], array[0]) = (array[0], array[1]);
        }
    }

    private static ICollection<int> Merge(IList<int> arrayA, IList<int> arrayB)
    {
        var mergedArrayCount = arrayA.Count + arrayB.Count;
        var mergedList = new List<int>(mergedArrayCount);

        var a = arrayA.GetEnumerator();
        var b = arrayB.GetEnumerator();
        var isEndA = true;
        var isEndB = true;
        a.MoveNext();
        b.MoveNext();

        while (true)
        {
            if (isEndA && a.Current < b.Current)
            {
                mergedList.Add(a.Current);
                isEndA = a.MoveNext();
            }
            else
            {
                mergedList.Add(b.Current);
                isEndB = b.MoveNext();
            }

            if (!isEndA)
            {
                do
                {
                    mergedList.Add(b.Current);
                } while (b.MoveNext());

                break;
            }

            if (!isEndB)
            {
                do
                {
                    mergedList.Add(a.Current);
                } while (a.MoveNext());

                break;
            }
        }

        return [.. mergedList];
    }
}
