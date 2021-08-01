
import sys


import os
import numpy as np
import matplotlib.pyplot as plt

bogoSort = dict()
bubbleSort = dict()
heapSorts = dict()
inserctionSort = dict()
mergeSort = dict()
quickSort = dict()
selectionSort = dict()
instances = dict()
allAlgorithms = []


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


def plotTimeComparison(instancesOne, instancesTwo):
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

    plt.plot(np.array(instanceSizesOne),
             np.array(numberOfComparisonsOne))

    plt.plot(np.array(instanceSizesTwo),
             np.array(numberOfComparisonsTwo))

    plt.title('Coparação de tempos de execução entre {} e {}'.format(
        algorithmNameOne, algorithmNameTwo))
    plt.ylabel('Tempo de execução')
    plt.xlabel('Tamanho da instância')

    plt.show()


def plotNumberOfComparisonsComparison(instancesOne, instancesTwo):
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

    plt.plot(np.array(instanceSizesOne),
             np.array(numberOfComparisonsOne))

    plt.plot(np.array(instanceSizesOne),
             np.array(numberOfComparisonsTwo))

    plt.title('Coparação do número de comparações entre {} e {}'.format(
        algorithmNameOne, algorithmNameTwo))
    plt.ylabel('Número de comparações')
    plt.xlabel('Tamanho da instância')

    plt.show()


# inicialização das chaves dos dicionários que vão conter os resultados
dataStates = ['sorted', 'unsorted', 'not-repeated', 'reversed-sorted']
numberTypes = ['double', 'integer', 'bytes']

for nType in numberTypes:
    quickSort[nType] = {}
    bogoSort[nType] = {}
    bubbleSort[nType] = {}
    heapSorts[nType] = {}
    inserctionSort[nType] = {}
    selectionSort[nType] = {}
    mergeSort[nType] = {}
    for state in dataStates:
        quickSort[nType][state] = []
        bogoSort[nType][state] = []
        bubbleSort[nType][state] = []
        heapSorts[nType][state] = []
        inserctionSort[nType][state] = []
        selectionSort[nType][state] = []
        mergeSort[nType][state] = []


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
                if (instance["dataState"] == 'sorted'):
                    selectionSort["double"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    selectionSort["double"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    selectionSort["double"]['reversed-sorted'].append(instance)
                else:
                    selectionSort["double"]['not-repeated'].append(instance)

            elif(instance["algorithmName"] == 'Quicksort'):
                if (instance["dataState"] == 'sorted'):
                    quickSort["double"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    quickSort["double"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    quickSort["double"]['reversed-sorted'].append(instance)
                else:
                    quickSort["double"]['not-repeated'].append(instance)

            elif(instance["algorithmName"] == 'MergeSort'):
                if (instance["dataState"] == 'sorted'):
                    mergeSort["double"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    mergeSort["double"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    mergeSort["double"]['reversed-sorted'].append(instance)
                else:
                    mergeSort["double"]['not-repeated'].append(instance)
            elif(instance["algorithmName"] == 'InserctionSort'):
                if (instance["dataState"] == 'sorted'):
                    inserctionSort["double"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    inserctionSort["double"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    inserctionSort["double"]['reversed-sorted'].append(
                        instance)
                else:
                    inserctionSort["double"]['not-repeated'].append(instance)
            elif(instance["algorithmName"] == 'HeapSort'):
                if (instance["dataState"] == 'sorted'):
                    heapSorts["double"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    heapSorts["double"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    heapSorts["double"]['reversed-sorted'].append(instance)
                else:
                    heapSorts["double"]['not-repeated'].append(instance)
            elif(instance["algorithmName"] == 'BubbleSort'):
                if (instance["dataState"] == 'sorted'):
                    bubbleSort["double"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    bubbleSort["double"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    bubbleSort["double"]['reversed-sorted'].append(instance)
                else:
                    bubbleSort["double"]['not-repeated'].append(instance)
            else:
                if (instance["dataState"] == 'sorted'):
                    bogoSort["double"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    bogoSort["double"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    bogoSort["double"]['reversed-sorted'].append(instance)
                else:
                    bogoSort["double"]['not-repeated'].append(instance)

        if (instance["numberType"] == 'integer'):
            if(instance["algorithmName"] == 'SelectionSort'):
                if (instance["dataState"] == 'sorted'):
                    selectionSort["integer"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    selectionSort["integer"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    selectionSort["integer"]['reversed-sorted'].append(
                        instance)
                else:
                    selectionSort["integer"]['not-repeated'].append(instance)

            elif(instance["algorithmName"] == 'Quicksort'):
                if (instance["dataState"] == 'sorted'):
                    quickSort["integer"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    quickSort["integer"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    quickSort["integer"]['reversed-sorted'].append(instance)
                else:
                    quickSort["integer"]['not-repeated'].append(instance)

            elif(instance["algorithmName"] == 'MergeSort'):
                if (instance["dataState"] == 'sorted'):
                    mergeSort["integer"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    mergeSort["integer"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    mergeSort["integer"]['reversed-sorted'].append(instance)
                else:
                    mergeSort["integer"]['not-repeated'].append(instance)
            elif(instance["algorithmName"] == 'InserctionSort'):
                if (instance["dataState"] == 'sorted'):
                    inserctionSort["integer"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    inserctionSort["integer"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    inserctionSort["integer"]['reversed-sorted'].append(
                        instance)
                else:
                    inserctionSort["integer"]['not-repeated'].append(instance)
            elif(instance["algorithmName"] == 'HeapSort'):
                if (instance["dataState"] == 'sorted'):
                    heapSorts["integer"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    heapSorts["integer"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    heapSorts["integer"]['reversed-sorted'].append(instance)
                else:
                    heapSorts["integer"]['not-repeated'].append(instance)
            elif(instance["algorithmName"] == 'BubbleSort'):
                if (instance["dataState"] == 'sorted'):
                    bubbleSort["integer"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    bubbleSort["integer"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    bubbleSort["integer"]['reversed-sorted'].append(instance)
                else:
                    bubbleSort["integer"]['not-repeated'].append(instance)
            else:
                if (instance["dataState"] == 'sorted'):
                    bogoSort["integer"]['sorted'].append(instance)
                elif (instance["dataState"] == 'unsorted'):
                    bogoSort["integer"]['unsorted'].append(instance)
                elif (instance["dataState"] == 'reversed-sorted'):
                    bogoSort["integer"]['reversed-sorted'].append(instance)
                else:
                    bogoSort["integer"]['not-repeated'].append(instance)


allAlgorithms.append(quickSort)
allAlgorithms.append(heapSorts)
allAlgorithms.append(mergeSort)
allAlgorithms.append(bogoSort)
allAlgorithms.append(selectionSort)
allAlgorithms.append(bubbleSort)
allAlgorithms.append(inserctionSort)
# inicialização das chaves dos dicionários que vão conter os resultados
dataStates = ['sorted', 'unsorted', 'not-repeated', 'reversed-sorted']
numberTypes = ['double', 'integer', 'bytes']
methodsToCompare = []


def plotAll(compareType):
    for algorith in allAlgorithms:
        for ntype in numberTypes:
            for dataState in dataStates:
                if (compareType == 'time'):
                    plotTimeComparison(algorith[ntype][dataState],
                                       algorith[ntype][dataState])
                else:
                    plotNumberOfComparisonsComparison(algorith[ntype][dataState],
                                                      algorith[ntype][dataState])


plotConfig = open('config-plot/plotConfig.txt', "r")
comparisonType = str(plotConfig.readline()).strip('\n')
firstMethod = str(plotConfig.readline()).strip('\n')
secondMethod = str(plotConfig.readline()).strip('\n')
comparisonMetric = str(plotConfig.readline()).strip('\n')
numberType = str(plotConfig.readline()).strip('\n')
dataState = str(plotConfig.readline()).strip('\n')


if comparisonType == 'all':
    plotAll(comparisonMetric)
else:

    if(firstMethod == 'quicksort' or secondMethod == 'quicksort'):
        methodsToCompare.append(quickSort)

    if(firstMethod == 'mergesort' or secondMethod == 'mergesort'):
        methodsToCompare.append(mergeSort)

    if(firstMethod == 'bubblesort' or secondMethod == 'bubblesort'):
        methodsToCompare.append(bubbleSort)

    if(firstMethod == 'heapsort' or secondMethod == 'heapsort'):
        methodsToCompare.append(heapSorts)

    if(firstMethod == 'selectionsort' or secondMethod == 'selectionsort'):
        methodsToCompare.append(selectionSort)

    if(firstMethod == 'insertionsort' or secondMethod == 'insertionsort'):
        methodsToCompare.append(inserctionSort)

    if(firstMethod == 'bogosort' or secondMethod == 'bogosort'):
        methodsToCompare.append(bogoSort)

    if (comparisonMetric == 'time'):
        plotTimeComparison(methodsToCompare[0][numberType][dataState],
                           methodsToCompare[1][numberType][dataState])
    else:
        plotNumberOfComparisonsComparison(methodsToCompare[0][numberType][dataState],
                                          methodsToCompare[1][numberType][dataState])
