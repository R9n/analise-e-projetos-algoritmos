using System.Collections.Generic;
using System;
using System.Threading.Tasks;

class RunAllAlgorithms
{
    QuickSort quickSort = new QuickSort();
    SelectionSort selectionSort = new SelectionSort();
    MergeSort mergeSort = new MergeSort();
    InsertionSort insertionSort = new InsertionSort();
    HeapSort heapSort = new HeapSort();
    BubbleSort bubbleSort = new BubbleSort();
    BogoSort bogoSort = new BogoSort();

    public async Task<string> runAllAlgorithms(dynamic loadedInstances)
    {
        foreach (dynamic instances in loadedInstances)
        {

            foreach (dynamic instance in instances)
            {
                List<dynamic> sortedData = instance.sortedData;
                List<dynamic> unsortedData = instance.unsortedData;
                List<dynamic> inversedSortedData = instance.inversedSortedData;
                List<dynamic> noRepeatedElements = instance.noRepeatedElements;

                // dados não ordenados
                Statistics quickSortStatisticsUnsorted = quickSort.quickSort(unsortedData, instance.dataType);
                Statistics selectionSortStatisticsUnsorted = selectionSort.selectionSort(unsortedData, instance.dataType);
                Statistics mergeSortStatisticsUnsorted = mergeSort.mergeSort(unsortedData, instance.dataType);
                Statistics insertionSortStatisticsUnsorted = insertionSort.insertionSort(unsortedData, instance.dataType);
                Statistics heapSortStatisticsUnsorted = heapSort.heapSort(unsortedData, instance.dataType);
                Statistics bubbleStatisticsUnsorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                Statistics bogoSortStatisticsUnsorted = bogoSort.bogosort(unsortedData, instance.dataType);

                //dados ordenados
                Statistics quickSortStatisticsSorted = quickSort.quickSort(unsortedData, instance.dataType);
                Statistics selectionSortStatisticsSorted = selectionSort.selectionSort(unsortedData, instance.dataType);
                Statistics mergeSortStatisticsSorted = mergeSort.mergeSort(unsortedData, instance.dataType);
                Statistics insertionSortStatisticsSorted = insertionSort.insertionSort(unsortedData, instance.dataType);

                Statistics heapSortStatisticsSorted = heapSort.heapSort(unsortedData, instance.dataType);
                Statistics bubbleStatisticsSorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                Statistics bogoSortStatisticsSorted = bogoSort.bogosort(unsortedData, instance.dataType);

                //dados inversamente ordenados
                Statistics quickSortStatisticsReversedSorted = quickSort.quickSort(unsortedData, instance.dataType);
                Statistics selectionSortStatisticsReversedSorted = selectionSort.selectionSort(unsortedData, instance.dataType);
                Statistics mergeSortStatisticsReversedSorted = mergeSort.mergeSort(unsortedData, instance.dataType);
                Statistics insertionSortStatisticsReversedSorted = insertionSort.insertionSort(unsortedData, instance.dataType);
                Statistics heapSortStatisticsReversedSorted = heapSort.heapSort(unsortedData, instance.dataType);
                Statistics bubbleStatisticsReversedSorted = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                Statistics bogoSortStatisticsReversedSorted = bogoSort.bogosort(unsortedData, instance.dataType);


                //dados não repetidos
                Statistics quickSortStatisticsNotRepeated = quickSort.quickSort(unsortedData, instance.dataType);
                Statistics selectionSortStatisticsNotRepeated = selectionSort.selectionSort(unsortedData, instance.dataType);
                Statistics mergeSortStatisticsNotRepeated = mergeSort.mergeSort(unsortedData, instance.dataType);

                Statistics insertionSortStatisticsNotRepeated = insertionSort.insertionSort(unsortedData, instance.dataType);
                Statistics heapSortStatisticsNotRepeated = heapSort.heapSort(unsortedData, instance.dataType);
                Statistics bubbleStatisticsNotRepeated = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                Statistics bogoSortStatisticsNotRepeated = bogoSort.bogosort(unsortedData, instance.dataType);


                await quickSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                await selectionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                await mergeSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                await insertionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                await heapSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                await bubbleStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                await bogoSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");


                await quickSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                await selectionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                await mergeSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                await insertionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                await heapSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                await bubbleStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                await bogoSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");


                await quickSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");
                await selectionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");
                await mergeSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");
                await insertionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");
                await heapSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");
                await bubbleStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");
                await bogoSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");


                await quickSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                await selectionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                await mergeSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                await insertionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                await heapSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                await bubbleStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                await bogoSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");

            }
        }
        try
        {
            await Functions.writePlotConfig("all", "", "", "", "", "");
        }
        catch (Exception e)
        {
            throw e;
        }
        return "OK";
    }


}