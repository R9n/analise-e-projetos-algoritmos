using System;
using System.Collections.Generic;


namespace trabalho
{
    class Program
    {
        static void Main(string[] args)
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

                foreach (Instance instance in loadedInstances)
                {
                    Functions.showMessage(instance.numberType);
                    Statistics quickSortStatistics = quickSort.quickSort(instance.unsortedData, instance.dataType);
                    quickSortStatistics.printStatics();
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

