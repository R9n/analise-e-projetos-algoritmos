using System;
using System.Collections.Generic;
using System.Diagnostics;


class MergeSort
{

    Statistics statistics;

    public Statistics mergeSort(List<dynamic> elements, string dataType)
    {
        dynamic[] sortedArray = new dynamic[elements.Count];


        for (int i = 0; i < elements.Count; i++)
        {
            sortedArray.SetValue(elements[i], i);

        }

        this.statistics = new Statistics();
        statistics.algorithmName = "Merge Sort";

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        statistics.numberOfComparisons++;

        if (elements.Count <= 1 || elements == null)
        {
            statistics.numberOfComparisons++;
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

    private void sort(dynamic[] input, int left, int right, string dataType)
    {
        statistics.numberOfComparisons++;
        if (left < right)
        {
            int middle = (left + right) / 2;

            sort(input, left, middle, "");
            sort(input, middle + 1, right, "");

            merge(input, left, middle, right, dataType);
        }

    }

    private void merge(dynamic[] input, int left, int middle, int right, string dataType)
    {
        dynamic[] leftArray = new dynamic[middle - left + 1];
        dynamic[] rightArray = new dynamic[right - middle];

        Array.Copy(input, left, leftArray, 0, middle - left + 1);
        Array.Copy(input, middle + 1, rightArray, 0, right - middle);

        int i = 0;
        int j = 0;
        for (int k = left; k < right + 1; k++)
        {
            statistics.numberOfComparisons++;
            if (i == leftArray.Length)
            {
                input[k] = rightArray[j];
                j++;
            }
            else
            {
                statistics.numberOfComparisons++;
                if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    statistics.numberOfComparisons++;
                    if (CompareMergeSort.compareElements(leftArray[i], rightArray[j], dataType))
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }

    }

}