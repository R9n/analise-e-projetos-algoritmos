using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.IO;

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

                        // dados não ordenados
                        Statistics quickSortStatistics = quickSort.quickSort(unsortedData, instance.dataType);
                        // Statistics selectionSortStatistics = selectionSort.selectionSort(unsortedData, instance.dataType);
                        // Statistics mergeSortStatistics = mergeSort.mergeSort(unsortedData, instance.dataType);
                        // Statistics insertionSortStatistics = insertionSort.insertionSort(unsortedData, instance.dataType);
                        Statistics heapSortStatistics = heapSort.heapSort(unsortedData, instance.dataType);
                        // Statistics bubbleStatistics = bubbleSort.bubbleSort(unsortedData, instance.dataType);
                        // Statistics bogoSortStatistics = bogoSort.bogosort(unsortedData, instance.dataType);

                        await quickSortStatistics.writeStatisticsToDisc(instance, "unsortedData");
                        // await selectionSortStatistics.writeStatisticsToDisc(instance, "unsortedData");
                        // await mergeSortStatistics.writeStatisticsToDisc(instance, "unsortedData");
                        // await insertionSortStatistics.writeStatisticsToDisc(instance, "unsortedData");
                        await heapSortStatistics.writeStatisticsToDisc(instance, "unsortedData");
                        // await bubbleStatistics.writeStatisticsToDisc(instance, "unsortedData");
                        // await bogoSortStatistics.writeStatisticsToDisc(instance, "unsortedData");


                    }


                }

                ScriptEngine engine = Python.CreateEngine();
                ScriptScope scope = engine.CreateScope();
                var paths = engine.GetSearchPaths();

              
                paths.Add("/usr/bin/python");
                paths.Add("/usr/lib");

                engine.SetSearchPaths(paths);

                 var paths2 = engine.GetSearchPaths();

                try
                {
                   
                   // engine.ExecuteFile("helpers/show-results.py", scope);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }



                // Statistics quickSortStatistics = quickSort.quickSort(loadedInstances[i].data[k], dataType);
                // Statistics selectionSortStatistics = selectionSort.selectionSort(loadedInstances[i].data[k], dataType);
                // Statistics mergeSortStatistics = mergeSort.mergeSort(loadedInstances[i].data[k], dataType);
                // Statistics insertionSortStatistics = insertionSort.insertionSort(loadedInstances[i].data[k], dataType);
                // Statistics heapSortStatistics = heapSort.heapSort(loadedInstances[i].data[k], dataType);
                // Statistics bubbleStatistics = bubbleSort.bubbleSort(loadedInstances[i].data[k], dataType);
                // Statistics bogoSortStatistics = bogoSort.bogosort(loadedInstances[i].data[k], dataType);
                // mergeSortStatistics.printStatics();
                // quickSortStatistics.printStatics();
                // heapSortStatistics.printStatics();


            }
        }
    }
}

