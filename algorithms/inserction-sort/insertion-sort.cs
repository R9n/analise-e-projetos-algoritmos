using System;
using System.Collections.Generic;
using System.Diagnostics;


class InsertionSort
{
    Statistics statistics;

    public Statistics insertionSort(List<dynamic> elements, string dataType)
    {
        dynamic[] sortedArray = new dynamic[elements.Count];


        for (int i = 0; i < elements.Count; i++)
        {
            sortedArray.SetValue(elements[i], i);

        }

        this.statistics = new Statistics();
        statistics.algorithmName = "InserctionSort";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        if (elements.Count <= 1 || elements == null)
        {
            statistics.numberOfComparisons += 2;
        }
        else
        {
            sort(sortedArray, 0, sortedArray.Length - 1, dataType);
        }
        stopwatch.Start();
        statistics.totalTimeOfExecution = stopwatch.Elapsed;
        statistics.sortedArray = sortedArray;
        return statistics;
    }

    private void sort(dynamic[] array, int left, int right, string dataType)
    {
        int i, j;
        dynamic current;

        for (i = 1; i < array.Length; i++)
        {
            current = array[i];
            j = i;
            statistics.numberOfComparisons++;
            while ((j > 0) && CompareInsertionSort.compareElements(array[j - 1], current, dataType))
            {
                statistics.numberOfComparisons++;

                array[j] = array[j - 1];
                j = j - 1;
            }
            array[j] = current;

        }


    }


}