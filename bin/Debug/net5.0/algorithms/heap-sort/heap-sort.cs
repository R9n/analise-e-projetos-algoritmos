using System;
using System.Collections.Generic;
using System.Diagnostics;


class HeapSort
{
    Statistics statistics;

    public Statistics heapSort(List<dynamic> elements, string dataType)
    {
        dynamic[] sortedArray = new dynamic[elements.Count];


        for (int i = 0; i < elements.Count; i++)
        {
            sortedArray.SetValue(elements[i], i);

        }

        this.statistics = new Statistics();
        statistics.algorithmName = "HeapSort";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        this.statistics.numberOfComparisons = 0;
        this.statistics.numberOfComparisons++;
        if (elements.Count <= 1 || elements == null)
        {
            statistics.numberOfComparisons++;
        }
        else
        {
            sort(sortedArray, dataType);
        }
        stopwatch.Stop();
        this.statistics.totalTimeOfExecution = stopwatch.Elapsed;
        this.statistics.sortedArray = sortedArray;
        return statistics;
    }


    private dynamic[] sort(dynamic[] vetor, string dataType)

    {

        buildMaxHeap(vetor, dataType);

        int n = vetor.Length;
        for (int i = vetor.Length - 1; i > 0; i--)
        {
            swap(vetor, i, 0);
            maxHeapify(vetor, dataType, 0, --n);
        }
        return vetor;
    }

    private void buildMaxHeap(dynamic[] v, string dataType)

    {
        for (int i = v.Length / 2 - 1; i >= 0; i--)
        {
            maxHeapify(v, dataType, i, v.Length);
        }

    }


    private void maxHeapify(dynamic[] v, string dataType, int pos, int n)

    {
        int max = 2 * pos + 1;
        int right = max + 1;
        this.statistics.numberOfComparisons++;
        if (CompareHeapSort.compareElements(max, n, dataType, "less"))
        {
            statistics.numberOfComparisons++;
            if (CompareHeapSort.compareElements(right, n, dataType, "less") &&
                CompareHeapSort.compareElements(v[max], v[right], dataType, "less")
            )
            {
                this.statistics.numberOfComparisons++;
                max = right;
            }

            this.statistics.numberOfComparisons++;
            if (CompareHeapSort.compareElements(v[max], v[pos], dataType, "greater"))
            {
                swap(v, max, pos);
                maxHeapify(v, dataType, max, n);
            }
        }

    }


    private static void swap(dynamic[] v, int j, int aposJ)

    {
        dynamic aux = v[j];
        v[j] = v[aposJ];
        v[aposJ] = aux;

    }


}