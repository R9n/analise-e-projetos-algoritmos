import matplotlib
import os
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

instances = []

statistics = os.listdir('results')
dataArrayShift = 7
instanceSeparator = "==================================="

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
        instances.append(instance)

print(instances)
