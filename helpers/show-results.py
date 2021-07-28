import os
import matplotlib.pyplot as plt
import numpy as np
# algorithmName:Quicksort
# numberOfComparisons:37
# totalTimeOfExecution:00:00:00.0111925
# dataType:number
# numberType:integer
# instanceSize:10
# dataState:notrepeated
# ===================================
# algorithmName:Quicksort
# numberOfComparisons:34
# totalTimeOfExecution:00:00:00.0000163
# dataType:number
# numberType:double
# instanceSize:10
# dataState:notrepeated
# =======================

bogoSort = []
bubbleSort = []
heapSort = []
inserctionSort = []
mergeSort = []
quickSort = []
selectionSort = []
instances = []

statistics = os.listdir('results')
dataArrayShift = 7
instanceSeparator = "==================================="


def plotGraphicComparison(instancesOne, instancesTwo):
    instanceSizesOne = []
    timesProcessingOne = []
    numberOfComparisonsOne = []
    algorithmNameOne = instancesOne[0]["algorithmName"]

    instanceSizesTwo = []
    timesProcessingTwo = []
    numberOfComparisonsTwo = []
    algorithmNameTwo = instancesTwo[0]["algorithmName"]

    for instance in instancesOne:
        instanceSizesOne.append(instance['instanceSize'])
        timesProcessingOne.append(instance["totalTimeOfExecution"])
        numberOfComparisonsOne.append(instance["numberOfComparisons"])

    for instance in instancesTwo:
        instanceSizesTwo.append(instance['instanceSize'])
        timesProcessingTwo.append(instance["totalTimeOfExecution"])
        numberOfComparisonsTwo.append(instance["numberOfComparisons"])

    # Plot some data on the (implicit) axes.
    plt.plot(instanceSizesOne, numberOfComparisonsOne, label=algorithmNameOne)
    # etc.
    plt.plot(instanceSizesTwo, numberOfComparisonsTwo, label=algorithmNameTwo)
    plt.xlabel('Tamanho da instância')
    plt.ylabel('Número de comparações')
    plt.title("Número de comparações  realizadas")
    plt.legend()
    plt.show()


for statistic in statistics:
    data = open('results/'+statistic, "r")
    currentLine = str(data.readline()).strip('\n')
    while (currentLine != ''):
        instance = dict()
        if(currentLine == instanceSeparator):
            currentLine = str(data.readline()).strip('\n')
            instance = dict()
            continue
        instance["algorithmName"] = currentLine.split(":")[1]
        currentLine = str(data.readline()).strip('\n')
        print(currentLine)

        instance["numberOfComparisons"] = currentLine.split(":")[1]
        currentLine = str(data.readline()).strip('\n')
        instance["totalTimeOfExecution"] = currentLine.split(":")[1]
        currentLine = str(data.readline()).strip('\n')
        instance["dataType"] = currentLine.split(":")[1]
        currentLine = str(data.readline()).strip('\n')
        instance["numberType"] = currentLine.split(":")[1]
        currentLine = str(data.readline()).strip('\n')
        instance["instanceSize"] = currentLine.split(":")[1]
        currentLine = str(data.readline()).strip('\n')
        instance["dataState"] = currentLine.split(":")[1]
        currentLine = str(data.readline()).strip('\n')

        if(instance["algorithmName"] == 'SelectionSort'):
            selectionSort.append(instance)
        elif(instance["algorithmName"] == 'Quicksort'):
            quickSort.append(instance)
        elif(instance["algorithmName"] == 'MergeSort'):
            mergeSort.append(instance)
        elif(instance["algorithmName"] == 'InserctionSort'):
            inserctionSort.append(instance)
        elif(instance["algorithmName"] == 'HeapSort'):
            heapSort.append(instance)
        elif(instance["algorithmName"] == 'BubbleSort'):
            bubbleSort.append(instance)
        else:
            bogoSort.append(instance)


plotGraphicComparison(quickSort, quickSort)
