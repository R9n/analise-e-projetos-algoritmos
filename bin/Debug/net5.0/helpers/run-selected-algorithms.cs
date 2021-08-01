using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class RunSelectedAlgorithms
{
    QuickSort quickSort = new QuickSort();
    SelectionSort selectionSort = new SelectionSort();
    MergeSort mergeSort = new MergeSort();
    InsertionSort insertionSort = new InsertionSort();
    HeapSort heapSort = new HeapSort();
    BubbleSort bubbleSort = new BubbleSort();
    BogoSort bogoSort = new BogoSort();

    string comparisonType;
    string firstMethod;
    string secondMethod;



    public async Task<string> runSelectedAlgorithms(dynamic loadedInstances)
    {
        string algorithmOne;
        string algorithmTwo;
        comparisonType = "selected";

        Functions.showMessage(Messages.selectFirstAlgorithm);
        algorithmOne = Console.ReadLine();

        Functions.showMessage(Messages.selectSecondAlgorithm);
        algorithmTwo = Console.ReadLine();

        Functions.showMessage(Messages.selectCompareType);
        string comparisonMetric = Console.ReadLine();
        switch (comparisonMetric)
        {
            case "1":
                {
                    comparisonMetric = "time";
                    break;
                }
            case "2":
                {
                    comparisonMetric = "number-of-comparisons";
                    break;
                }
        }

        Functions.showMessage(Messages.selecNumberType);
        string numberType = Console.ReadLine();

        switch (numberType)
        {
            case "1":
                {
                    numberType = "double";
                    break;
                }
            case "2":
                {
                    numberType = "integer";
                    break;
                }
            case "3":
                {
                    numberType = "bytes";
                    break;
                }
        }

        Functions.showMessage(Messages.selectDataState);
        string dataState = Console.ReadLine();

        switch (dataState)
        {
            case "1":
                {
                    dataState = "sorted";
                    break;
                }
            case "2":
                {
                    dataState = "unsorted";
                    break;
                }
            case "3":
                {
                    dataState = "reversed-sorted";
                    break;
                }
            case "4":
                {
                    dataState = "not-repeated";
                    break;

                }
        }


        foreach (dynamic instances in loadedInstances)
        {

            foreach (dynamic instance in instances)
            {
                List<dynamic> sortedData = instance.sortedData;
                List<dynamic> unsortedData = instance.unsortedData;
                List<dynamic> inversedSortedData = instance.inversedSortedData;
                List<dynamic> noRepeatedElements = instance.noRepeatedElements;



                switch (algorithmOne)
                {
                    case AlgorithmsTypes.Quicksort:
                        {
                            firstMethod = "quicksort";


                            Statistics quickSortStatisticsUnsorted = quickSort.quickSort(unsortedData, instance.dataType);
                            Statistics quickSortStatisticsSorted = quickSort.quickSort(unsortedData, instance.dataType);
                            Statistics quickSortStatisticsReversedSorted = quickSort.quickSort(unsortedData, instance.dataType);
                            Statistics quickSortStatisticsNotRepeated = quickSort.quickSort(unsortedData, instance.dataType);

                            await quickSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await quickSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await quickSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await quickSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.BogoSort:
                        firstMethod = "bogosort";
                        Statistics bogoSortStatisticsNotRepeated = bogoSort.bogosort(unsortedData, instance.dataType);
                        Statistics bogoSortStatisticsReversedSorted = bogoSort.bogosort(unsortedData, instance.dataType);
                        Statistics bogoSortStatisticsSorted = bogoSort.bogosort(unsortedData, instance.dataType);
                        Statistics bogoSortStatisticsUnsorted = bogoSort.bogosort(unsortedData, instance.dataType);


                        await bogoSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                        await bogoSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                        await bogoSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                        await bogoSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                        {
                            break;
                        }
                    case AlgorithmsTypes.BubbleSort:

                        {
                            firstMethod = "bubblesort";
                            Statistics bubbleStatisticsReversedSorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                            Statistics bubbleStatisticsNotRepeated = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                            Statistics bubbleStatisticsSorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                            Statistics bubbleStatisticsUnsorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);

                            await bubbleStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await bubbleStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await bubbleStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await bubbleStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.MergeSort:
                        {
                            firstMethod = "mergesort";
                            Statistics mergeSortStatisticsNotRepeated = mergeSort.mergeSort(unsortedData, instance.dataType);
                            Statistics mergeSortStatisticsReversedSorted = mergeSort.mergeSort(unsortedData, instance.dataType);
                            Statistics mergeSortStatisticsUnsorted = mergeSort.mergeSort(unsortedData, instance.dataType);

                            Statistics mergeSortStatisticsSorted = mergeSort.mergeSort(unsortedData, instance.dataType);

                            await mergeSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await mergeSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await mergeSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await mergeSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.SelectionSort:
                        {
                            firstMethod = "selectionsort";
                            Statistics selectionSortStatisticsNotRepeated = selectionSort.selectionSort(unsortedData, instance.dataType);
                            Statistics selectionSortStatisticsReversedSorted = selectionSort.selectionSort(unsortedData, instance.dataType);
                            Statistics selectionSortStatisticsSorted = selectionSort.selectionSort(unsortedData, instance.dataType);
                            Statistics selectionSortStatisticsUnsorted = selectionSort.selectionSort(unsortedData, instance.dataType);

                            await selectionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await selectionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await selectionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await selectionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.HeapSort:
                        {
                            firstMethod = "heapsort";
                            Statistics heapSortStatisticsNotRepeated = heapSort.heapSort(unsortedData, instance.dataType);
                            Statistics heapSortStatisticsReversedSorted = heapSort.heapSort(unsortedData, instance.dataType);
                            Statistics heapSortStatisticsSorted = heapSort.heapSort(unsortedData, instance.dataType);
                            Statistics heapSortStatisticsUnsorted = heapSort.heapSort(unsortedData, instance.dataType);

                            await heapSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await heapSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await heapSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await heapSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.InsertionSort:
                        {
                            firstMethod = "inserctionsort";
                            Statistics insertionSortStatisticsNotRepeated = insertionSort.insertionSort(unsortedData, instance.dataType);
                            Statistics insertionSortStatisticsReversedSorted = insertionSort.insertionSort(unsortedData, instance.dataType);
                            Statistics insertionSortStatisticsSorted = insertionSort.insertionSort(unsortedData, instance.dataType);
                            Statistics insertionSortStatisticsUnsorted = insertionSort.insertionSort(unsortedData, instance.dataType);

                            await insertionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await insertionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await insertionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await insertionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                }

                switch (algorithmTwo)
                {
                    case AlgorithmsTypes.Quicksort:
                        {
                            secondMethod = "quicksort";

                            Statistics quickSortStatisticsUnsorted = quickSort.quickSort(unsortedData, instance.dataType);
                            Statistics quickSortStatisticsSorted = quickSort.quickSort(unsortedData, instance.dataType);
                            Statistics quickSortStatisticsReversedSorted = quickSort.quickSort(unsortedData, instance.dataType);
                            Statistics quickSortStatisticsNotRepeated = quickSort.quickSort(unsortedData, instance.dataType);

                            await quickSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await quickSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await quickSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await quickSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.BogoSort:
                        {
                            secondMethod = "bogosort";

                            Statistics bogoSortStatisticsNotRepeated = bogoSort.bogosort(unsortedData, instance.dataType);
                            Statistics bogoSortStatisticsReversedSorted = bogoSort.bogosort(unsortedData, instance.dataType);
                            Statistics bogoSortStatisticsSorted = bogoSort.bogosort(unsortedData, instance.dataType);
                            Statistics bogoSortStatisticsUnsorted = bogoSort.bogosort(unsortedData, instance.dataType);


                            await bogoSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await bogoSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await bogoSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await bogoSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");


                            break;
                        }
                    case AlgorithmsTypes.BubbleSort:
                        {
                            secondMethod = "bubblesort";

                            Statistics bubbleStatisticsReversedSorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                            Statistics bubbleStatisticsNotRepeated = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                            Statistics bubbleStatisticsSorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                            Statistics bubbleStatisticsUnsorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);

                            await bubbleStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await bubbleStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await bubbleStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await bubbleStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.MergeSort:
                        {
                            secondMethod = "mergesort";

                            Statistics mergeSortStatisticsNotRepeated = mergeSort.mergeSort(unsortedData, instance.dataType);
                            Statistics mergeSortStatisticsReversedSorted = mergeSort.mergeSort(unsortedData, instance.dataType);
                            Statistics mergeSortStatisticsUnsorted = mergeSort.mergeSort(unsortedData, instance.dataType);

                            Statistics mergeSortStatisticsSorted = mergeSort.mergeSort(unsortedData, instance.dataType);

                            await mergeSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await mergeSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await mergeSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await mergeSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.SelectionSort:
                        {
                            secondMethod = "selectionsort";

                            Statistics selectionSortStatisticsNotRepeated = selectionSort.selectionSort(unsortedData, instance.dataType);
                            Statistics selectionSortStatisticsReversedSorted = selectionSort.selectionSort(unsortedData, instance.dataType);
                            Statistics selectionSortStatisticsSorted = selectionSort.selectionSort(unsortedData, instance.dataType);
                            Statistics selectionSortStatisticsUnsorted = selectionSort.selectionSort(unsortedData, instance.dataType);

                            await selectionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await selectionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await selectionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await selectionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.HeapSort:
                        {
                            secondMethod = "heapsort";

                            Statistics heapSortStatisticsNotRepeated = heapSort.heapSort(unsortedData, instance.dataType);
                            Statistics heapSortStatisticsReversedSorted = heapSort.heapSort(unsortedData, instance.dataType);
                            Statistics heapSortStatisticsSorted = heapSort.heapSort(unsortedData, instance.dataType);
                            Statistics heapSortStatisticsUnsorted = heapSort.heapSort(unsortedData, instance.dataType);

                            await heapSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await heapSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await heapSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await heapSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                    case AlgorithmsTypes.InsertionSort:
                        {
                            secondMethod = "inserctionsort";

                            Statistics insertionSortStatisticsNotRepeated = insertionSort.insertionSort(unsortedData, instance.dataType);
                            Statistics insertionSortStatisticsReversedSorted = insertionSort.insertionSort(unsortedData, instance.dataType);
                            Statistics insertionSortStatisticsSorted = insertionSort.insertionSort(unsortedData, instance.dataType);
                            Statistics insertionSortStatisticsUnsorted = insertionSort.insertionSort(unsortedData, instance.dataType);

                            await insertionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                            await insertionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                            await insertionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                            await insertionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                            break;
                        }
                }

            }


        }

        try
        {
            await Functions.writePlotConfig(this.comparisonType, this.firstMethod, this.secondMethod, comparisonMetric, numberType, dataState);
        }
        catch (Exception e)
        {
            throw e;
        }
        return "OK";
    }
}