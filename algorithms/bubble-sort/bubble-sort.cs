using System;
using System.Collections.Generic;
using System.Diagnostics;


class BubbleSort
{
    Statistics statistics;

    public Statistics bubbleSort(List<dynamic> elements, string dataType)
    {
        dynamic[] sortedArray = new dynamic[elements.Count];


        for (int i = 0; i < elements.Count; i++)
        {
            sortedArray.SetValue(elements[i], i);

        }

        this.statistics = new Statistics();
        statistics.algorithmName = "Bubble Sort";

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        if (elements.Count <= 1 || elements == null)
        {
            statistics.numberOfComparisons += 2;
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
        int tamanho = array.Length;


        int trocas = 0;

        for (int i = tamanho - 1; i >= 1; i--)
        {
            for (int j = 0; j < i; j++)
            {
                this.statistics.numberOfComparisons++;
                if (CompareBubbleSort.compareElements(array[j], array[j + 1], dataType))
                {
                    dynamic aux = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = aux;
                    trocas++;
                }
            }
        }





    }


}