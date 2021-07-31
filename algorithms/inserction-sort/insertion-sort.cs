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
        this.statistics.algorithmName = "InserctionSort";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        if (elements.Count <= 1 || elements == null)
        {
            this.statistics.numberOfComparisons += 2;
        }
        else
        {
            this.statistics.numberOfComparisons = 0;
            sort(sortedArray, 0, sortedArray.Length - 1, dataType);
        }
        stopwatch.Stop();
        this.statistics.totalTimeOfExecution = stopwatch.Elapsed;
        this.statistics.sortedArray = sortedArray;
        return this.statistics;
    }

    private void sort(dynamic[] array, int left, int right, string dataType)
    {
        int i, j;
        dynamic current;

        for (i = 1; i < array.Length; i++)
        {
            current = array[i];
            j = i;
            this.statistics.numberOfComparisons++;
            while ((j > 0) && CompareInsertionSort.compareElements(array[j - 1], current, dataType))
            {
                this.statistics.numberOfComparisons++;

                array[j] = array[j - 1];
                j = j - 1;
            }
            array[j] = current;

        }


    }


}