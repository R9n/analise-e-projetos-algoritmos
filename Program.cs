using System;

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

                for (int i = 0; i < loadedInstances.Count; i++)
                {
                    string dataType = loadedInstances[i].dataType;
                    for (int k = 0; k < loadedInstances[i].data.Count; k++)
                    {
                        Statistics quickSortStatistics = quickSort.quickSort(loadedInstances[i].data[k], dataType);
                        Statistics selectionSortStatistics = selectionSort.selectionSort(loadedInstances[i].data[k], dataType);
                        Statistics mergeSortStatistics = mergeSort.mergeSort(loadedInstances[i].data[k], dataType);
                        Statistics insertionSortStatistics = insertionSort.insertionSort(loadedInstances[i].data[k], dataType);
                        Statistics heapSortStatistics = heapSort.heapSort(loadedInstances[i].data[k], dataType);
                        Statistics bubbleStatistics = bubbleSort.bubbleSort(loadedInstances[i].data[k], dataType);
                        Statistics bogoSortStatistics = bogoSort.bogosort(loadedInstances[i].data[k], dataType);
                        mergeSortStatistics.printStatics();
                        quickSortStatistics.printStatics();
                        heapSortStatistics.printStatics();

                    }
                }
            }

        }

    }
}

