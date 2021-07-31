
import sys


import os
import numpy as np
import matplotlib.pyplot as plt


bogoSortBytes = []
bubbleSortBytes = []
heapSortBytes = []
inserctionSortBytes = []
mergeSortBytes = []
quickSortBytes = []
selectionSortBytes = []
instancesBytes = []

bogoSortInteger = []
bubbleSortInteger = []
heapSortInteger = []
inserctionSortInteger = []
mergeSortInteger = []
quickSortInteger = []
selectionSortInteger = []
instancesInteger = []

bogoSortDouble = []
bubbleSortDouble = []
heapSortDouble = []
inserctionSortDouble = []
mergeSortDouble = []
quickSortDouble = []
selectionSortDouble = []
instancesDouble = []


statistics = os.listdir('results')
dataArrayShift = 7
instanceSeparator = "==================================="

doublesStatistics = []
integersStatistics = []
bytesStatistics = []


def plotGraphicComparison(instancesOne, instancesTwo):
    instanceSizesOne = []
    timesProcessingOne = []
    numberOfComparisonsOne = []
    algorithmNameOne = instancesOne[0]["algorithmName"]

    instanceSizesTwo = []
    timesProcessingTwo = []
    numberOfComparisonsTwo = []
    algorithmNameTwo = instancesTwo[0]["algorithmName"]

    for i in range(len(instancesOne), 0, -1):
        for j in range(0, i - 1):
            if (float(instancesTwo[j]["instanceSize"]) > float(instancesTwo[j+1]["instanceSize"])):
                aux = instancesTwo[j]
                instancesTwo[j] = instancesTwo[j + 1]
                instancesTwo[j + 1] = aux
            if (float(instancesOne[j]["instanceSize"]) > float(instancesOne[j+1]["instanceSize"])):
                aux = instancesOne[j]
                instancesOne[j] = instancesOne[j + 1]
                instancesOne[j + 1] = aux

    for instance in instancesOne:
        instanceSizesOne.append(instance['instanceSize'])
        timesProcessingOne.append(instance["totalTimeOfExecution"])
        numberOfComparisonsOne.append(instance["numberOfComparisons"])

    for instance in instancesTwo:
        instanceSizesTwo.append(instance['instanceSize'])
        timesProcessingTwo.append(instance["totalTimeOfExecution"])
        numberOfComparisonsTwo.append(instance["numberOfComparisons"])
        print(instance["numberOfComparisons"])

    # Plot some data on the (implicit) axes.

    labels = instanceSizesOne
    men_means = numberOfComparisonsOne
    women_means = numberOfComparisonsTwo

    x = np.arange(len(labels))  # the label locations
    width = 0.35  # the width of the bars

    fig, ax = plt.subplots()
    rects1 = ax.bar(x - width/2, men_means, width, label='Men')
    rects2 = ax.bar(x + width/2, women_means, width, label='Women')

    # Add some text for labels, title and custom x-axis tick labels, etc.
    ax.set_ylabel('Scores')
    ax.set_title('Scores by group and gender')
    ax.set_xticks(x)
    ax.set_xticklabels(labels)
    ax.legend()

    ax.bar_label(rects1, padding=3)
    ax.bar_label(rects2, padding=3)

    fig.tight_layout()

    plt.show()


def plot2(instancesOne, instancesTwo):
    instanceSizesOne = []
    timesProcessingOne = []
    numberOfComparisonsOne = []
    algorithmNameOne = instancesOne[0]["algorithmName"]

    instanceSizesTwo = []
    timesProcessingTwo = []
    numberOfComparisonsTwo = []
    algorithmNameTwo = instancesTwo[0]["algorithmName"]

    for i in range(len(instancesOne), 0, -1):
        for j in range(0, i - 1):
            if (float(instancesTwo[j]["instanceSize"]) > float(instancesTwo[j+1]["instanceSize"])):
                aux = instancesTwo[j]
                instancesTwo[j] = instancesTwo[j + 1]
                instancesTwo[j + 1] = aux
            if (float(instancesOne[j]["instanceSize"]) > float(instancesOne[j+1]["instanceSize"])):
                aux = instancesOne[j]
                instancesOne[j] = instancesOne[j + 1]
                instancesOne[j + 1] = aux

    for instance in instancesOne:
        instanceSizesOne.append(instance['instanceSize'])
        timesProcessingOne.append(instance["totalTimeOfExecution"])
        numberOfComparisonsOne.append(instance["numberOfComparisons"])

    for instance in instancesTwo:
        instanceSizesTwo.append(instance['instanceSize'])
        timesProcessingTwo.append(instance["totalTimeOfExecution"])
        numberOfComparisonsTwo.append(instance["numberOfComparisons"])
        print(instance["numberOfComparisons"])

    fig, ax = plt.subplots()
    ax.plot([np.array(instanceSizesOne)], np.array(numberOfComparisonsTwo))

    ax.set(xlabel='time (s)', ylabel='voltage (mV)',
           title='About as simple as it gets, folks')
    ax.grid()

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

        if (instance["numberType"] == 'double'):
            if(instance["algorithmName"] == 'SelectionSort'):
                selectionSortDouble.append(instance)
            elif(instance["algorithmName"] == 'Quicksort'):
                quickSortDouble.append(instance)
            elif(instance["algorithmName"] == 'MergeSort'):
                mergeSortDouble.append(instance)
            elif(instance["algorithmName"] == 'InserctionSort'):
                inserctionSortDouble.append(instance)
            elif(instance["algorithmName"] == 'HeapSort'):
                heapSortDouble.append(instance)
            elif(instance["algorithmName"] == 'BubbleSort'):
                bubbleSortDouble.append(instance)
            else:
                bogoSortDouble.append(instance)

        elif (instance["numberType"] == 'integer'):
            if(instance["algorithmName"] == 'SelectionSort'):
                selectionSortInteger.append(instance)
            elif(instance["algorithmName"] == 'Quicksort'):
                quickSortInteger.append(instance)
            elif(instance["algorithmName"] == 'MergeSort'):
                mergeSortInteger.append(instance)
            elif(instance["algorithmName"] == 'InserctionSort'):
                inserctionSortInteger.append(instance)
            elif(instance["algorithmName"] == 'HeapSort'):
                heapSortInteger.append(instance)
            elif(instance["algorithmName"] == 'BubbleSort'):
                bubbleSortInteger.append(instance)
            else:
                bogoSortInteger.append(instance)
        else:
            if(instance["algorithmName"] == 'SelectionSort'):
                selectionSortBytes.append(instance)
            elif(instance["algorithmName"] == 'Quicksort'):
                quickSortBytes.append(instance)
            elif(instance["algorithmName"] == 'MergeSort'):
                mergeSortBytes.append(instance)
            elif(instance["algorithmName"] == 'InserctionSort'):
                inserctionSortBytes.append(instance)
            elif(instance["algorithmName"] == 'HeapSort'):
                heapSortBytes.append(instance)
            elif(instance["algorithmName"] == 'BubbleSort'):
                bubbleSortBytes.append(instance)
            else:
                bogoSortDouble.append(instance)

# plotGraphicComparison(quickSort, mergeSort)
# plotGraphicComparison(mergeSort, inserctionSort)
# plotGraphicComparison(quickSort, inserctionSort)
plot2(quickSortDouble, heapSortDouble)
