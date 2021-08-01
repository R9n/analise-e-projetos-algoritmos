using System;
using System.Collections.Generic;
using System.Diagnostics;


class SelectionSort
{

    Statistics statistics;

    public Statistics selectionSort(List<dynamic> elements, string dataType)
    {
        dynamic[] sortedArray = new dynamic[elements.Count];


        for (int i = 0; i < elements.Count; i++)
        {
            sortedArray.SetValue(elements[i], i);

        }

        this.statistics = new Statistics();
        statistics.algorithmName = "SelectionSort";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        this.statistics.numberOfComparisons = 0;
        statistics.numberOfComparisons++;
        if (elements.Count <= 1 || elements == null)
        {
            statistics.numberOfComparisons++;
        }
        else
        {
            sort(sortedArray, dataType);
        }
        stopwatch.Stop();
        statistics.totalTimeOfExecution = stopwatch.Elapsed;
        statistics.sortedArray = sortedArray;
        return statistics;
    }

    private void sort(dynamic[] array, string dataType)
    {
        double temp;
        int smallest;
        int arraySize = array.Length;
        for (int i = 0; i < arraySize - 1; i++)
        {
            smallest = i;
            for (int j = i + 1; j < arraySize; j++)
            {
                statistics.numberOfComparisons++;
                if (CompareSelectionSort.compareElements(array[j], array[smallest], dataType))
                {
                    smallest = j;
                }
            }
            temp = array[smallest];
            array[smallest] = array[i];
            array[i] = temp;
        }
    }
}