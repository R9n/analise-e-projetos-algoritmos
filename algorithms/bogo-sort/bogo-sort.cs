using System;
using System.Collections.Generic;
using System.Diagnostics;


class BogoSort
{
    Statistics statistics;

    public Statistics bogosort(List<dynamic> elements, string dataType)
    {
        dynamic[] sortedArray = new dynamic[elements.Count];


        for (int i = 0; i < elements.Count; i++)
        {
            sortedArray.SetValue(elements[i], i);

        }

        this.statistics = new Statistics();
        statistics.algorithmName = "Bogo Sort";

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        statistics.numberOfComparisons++;
        if (elements.Count <= 1 || elements == null)
        {
            statistics.numberOfComparisons++;
        }
        else
        {
            sort(sortedArray, dataType);
        }
        stopwatch.Start();
        statistics.totalTimeOfExecution = stopwatch.Elapsed;
        statistics.sortedArray = sortedArray;
        return statistics;
    }

    private void sort(dynamic[] array, string dataType)
    {
        while (!IsSorted(array, dataType))
            Shuffle(array);

    }

    private bool IsSorted(dynamic[] data, string dataType)
    {
        int count = data.Length;

        while (--count >= 1)
        {
            this.statistics.numberOfComparisons++;
            if (CompareBogoSort.compareElements(data[count], data[count - 1], dataType))
                return false;
        }
        return true;
    }

    private void Shuffle(dynamic[] data)
    {
        dynamic temp, rnd;
        Random rand = new Random();

        for (int i = 0; i < data.Length; ++i)
        {
            rnd = rand.Next(data.Length);
            temp = data[i];
            data[i] = data[rnd];
            data[rnd] = temp;
        }
    }



}