using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.IO;
using System.Runtime.InteropServices;

namespace trabalho
{
    class Program
    {
        static void Main(string[] args)
        {

            runMain();

        }

        static async void runMain()
        {
            Console.WriteLine(Messages.loadingConfig);

            dynamic config = Functions.loadConfig();

            QuickSort quickSort = new QuickSort();
            SelectionSort selectionSort = new SelectionSort();
            MergeSort mergeSort = new MergeSort();
            InsertionSort insertionSort = new InsertionSort();
            HeapSort heapSort = new HeapSort();
            BubbleSort bubbleSort = new BubbleSort();
            BogoSort bogoSort = new BogoSort();


            List<dynamic> sortedInstances = new List<dynamic>();

            if (!Functions.isValidConfig(config))
            {
                Functions.clearConsoleAndShowMessage(Messages.erroLoadingConfig);
                System.Environment.Exit(1);
            }

            dynamic loadedInstances = Functions.generateRandomArrays(config);

            string selectedOption = "";
            string algorithmOne;
            string algorithmTwo;

            Functions.clearConsoleAndShowMessage(Messages.mainMenu);

            while (selectedOption == "")
            {
                Functions.showMessage(Messages.selectAnOption);
                selectedOption = Console.ReadLine();

                if (!Constraints.validMenuOptions.Contains(selectedOption))
                {
                    selectedOption = "";
                    Functions.showMessage(Messages.invalidOption);
                    continue;
                }

                Directory.Delete("results/", true);
                Directory.CreateDirectory("results/");

                foreach (dynamic instances in loadedInstances)
                {

                    foreach (dynamic instance in instances)
                    {
                        List<dynamic> sortedData = instance.sortedData;
                        List<dynamic> unsortedData = instance.unsortedData;
                        List<dynamic> inversedSortedData = instance.inversedSortedData;
                        List<dynamic> noRepeatedElements = instance.noRepeatedElements;

                        if (selectedOption == "1")
                        {
                            foreach (dynamic instances in loadedInstances)
                            {

                                foreach (dynamic instance in instances)
                                {
                                    List<dynamic> sortedData = instance.sortedData;
                                    List<dynamic> unsortedData = instance.unsortedData;
                                    List<dynamic> inversedSortedData = instance.inversedSortedData;
                                    List<dynamic> noRepeatedElements = instance.noRepeatedElements;
                                }
                            }
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
                        if (selectedOption == "2")
                        {

                            Console.WriteLine(Messages.selectAlgorithm);
                            algorithmOne = Console.ReadLine();

                            Console.WriteLine(Messages.selectAlgorithm);
                            algorithmTwo = Console.ReadLine();


                            switch (algorithmOne)
                            {
                                case AlgorithmsTypes.Quicksort:
                                    {
                                        await quickSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await quickSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await quickSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await quickSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.BogoSort:
                                    await bogoSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                    await bogoSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                    await bogoSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                    await bogoSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                    {
                                        break;
                                    }
                                case AlgorithmsTypes.BubbleSort:
                                    {
                                        await bubbleStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await bubbleStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await bubbleStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await bubbleStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.MergeSort:
                                    {
                                        await mergeSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await mergeSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await mergeSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await mergeSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.SelectionSort:
                                    {
                                        await selectionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await selectionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await selectionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await selectionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.HeapSort:
                                    {
                                        await heapSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await heapSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await heapSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await heapSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.InsertionSort:
                                    {
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
                                        await quickSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await quickSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await quickSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await quickSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.BogoSort:
                                    await bogoSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                    await bogoSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                    await bogoSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                    await bogoSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                    {
                                        break;
                                    }
                                case AlgorithmsTypes.BubbleSort:
                                    {
                                        await bubbleStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await bubbleStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await bubbleStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await bubbleStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.MergeSort:
                                    {
                                        await mergeSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await mergeSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await mergeSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await mergeSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.SelectionSort:
                                    {
                                        await selectionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await selectionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await selectionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await selectionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.HeapSort:
                                    {
                                        await heapSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await heapSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await heapSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await heapSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                                case AlgorithmsTypes.InsertionSort:
                                    {
                                        await insertionSortStatisticsSorted.writeStatisticsToDisc(instance, "sorted");
                                        await insertionSortStatisticsUnsorted.writeStatisticsToDisc(instance, "unsorted");
                                        await insertionSortStatisticsNotRepeated.writeStatisticsToDisc(instance, "not-repeated");
                                        await insertionSortStatisticsReversedSorted.writeStatisticsToDisc(instance, "reversed-sorted");

                                        break;
                                    }
                            }

                        }

                    }


                }
                try
                {
                    Process proc = new System.Diagnostics.Process();
                    string command = "python helpers/show-results.py";


                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        proc.StartInfo.FileName = "/bin/bash";
                        proc.StartInfo.Arguments = "-c \" " + command + " \"";
                    }

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        proc.StartInfo.FileName = "cmd";
                        proc.StartInfo.Arguments = "-c \" " + command + " \"";
                    }

                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.Start();

                    // engine.ExecuteFile("helpers/show-results.py", scope);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }




            }
        }
    }
}

