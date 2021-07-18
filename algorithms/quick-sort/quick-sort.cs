using System;
using System.Collections.Generic;
using System.Diagnostics;


class QuickSort
{

    Statistics statistics;

    public Statistics quickSort(List<dynamic> elements, string dataType)
    {
        dynamic[] sortedArray = new dynamic[elements.Count];


        for (int i = 0; i < elements.Count; i++)
        {
            sortedArray.SetValue(elements[i], i);

        }
        this.statistics = new Statistics();
        statistics.algorithmName = "Quicksort";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        if (elements.Count <= 1 || elements == null)
        {
            statistics.numberOfComparisons += 2;
        }
        else
        {
            sort(sortedArray, dataType, 0, sortedArray.Length - 1);
        }
        stopwatch.Start();
        statistics.totalTimeOfExecution = stopwatch.Elapsed;
        statistics.sortedArray = sortedArray;
        return statistics;
    }

    private void sort(dynamic[] array, string dataType, int low, int high)
    {
        if (low < high)
        {
            statistics.numberOfComparisons++;
            int partIndex = partition(array, dataType, low, high);
            sort(array, dataType, low, partIndex - 1);
            sort(array, dataType, partIndex + 1, high);
        }
    }

    private int partition(dynamic[] arr, string dataType, int start, int end)
    {
        double temp;
        double p = arr[end];
        int i = start - 1;

        for (int j = start; j <= end - 1; j++)
        {
            statistics.numberOfComparisons++;
            if (CompareQuickSort.compareElements(arr[j], p, dataType))
            {
                statistics.numberOfComparisons++;
                i++;
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        temp = arr[i + 1];
        arr[i + 1] = arr[end];
        arr[end] = temp;
        return i + 1;
    }


}