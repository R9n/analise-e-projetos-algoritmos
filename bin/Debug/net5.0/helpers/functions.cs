using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Functions
{

    private static readonly Random _random = new Random();

    public static void clearConsoleScreen()
    {
        Console.Clear();
    }


    public static void clearConsoleAndShowMessage(string message)
    {
        clearConsoleScreen();
        System.Console.WriteLine(message);
    }

    public static void showMessage(dynamic message)
    {
        System.Console.WriteLine(message);
    }



    public static dynamic loadConfig()
    {
        try
        {
            return JsonConvert.DeserializeObject(File.ReadAllText("conf/config.json"));
        }
        catch
        {
            System.Console.WriteLine("Erro ao ler o conteúdo do arquivo de configuração");
            System.Console.WriteLine("Por favor, verifique o arquivo de configuração presnete em conf/config.json");

            return new { };
        }
    }

    public static bool isValidConfig(dynamic config)
    {
        return (config != null &&
        config.data != null &&
        config.data.Count != 0);
    }

    public static dynamic generateRandomArrays(dynamic config)
    {
        List<dynamic> instanceData = new List<dynamic>();
        MergeSort mergeSort = new MergeSort();


        for (int k = 0; k < config.data.Count; k++)
        {
            dynamic data = config.data[k];

            Statistics sortedDoublesStatistics;
            Statistics sortedIntegersStatistics;
            Statistics sortedBytesStatistics;

            List<dynamic> integerInstances = new List<dynamic>();
            List<dynamic> doubleInstances = new List<dynamic>();
            List<dynamic> bytesInstances = new List<dynamic>();

            if (data.dataType == DataTypes.number)
            {
                dynamic sizes = data.arraysSizes;

                for (int i = 0; i < sizes.Count; i++)
                {
                    Instance integersInstance = new Instance();
                    Instance doubleInstance = new Instance();
                    Instance bytesInstance = new Instance();

                    integersInstance.dataType = data.dataType;
                    doubleInstance.dataType = data.dataType;
                    bytesInstance.dataType = data.dataType;

                    integersInstance.numberType = "integer";
                    doubleInstance.numberType = "double";
                    bytesInstance.numberType = "bytes";

                    Int64 arrayLenght = sizes[i];

                    byte[] randomBytes = new byte[arrayLenght];

                    _random.NextBytes(randomBytes);

                    for (int j = 0; j < arrayLenght; j++)
                    {
                        doubleInstance.unsortedData.Add(_random.NextDouble() * arrayLenght);
                        integersInstance.unsortedData.Add(_random.Next());
                        bytesInstance.unsortedData.Add(randomBytes[j]);
                    }


                    //
                    for (int j = 0; j < arrayLenght; j++)
                    {
                        doubleInstance.noRepeatedElements.Add(getNonRepeatedElement(doubleInstance.noRepeatedElements, "double", arrayLenght));
                        integersInstance.noRepeatedElements.Add(getNonRepeatedElement(integersInstance.noRepeatedElements, "integer", arrayLenght));
                    }



                    sortedDoublesStatistics = mergeSort.mergeSort(doubleInstance.unsortedData, "number");
                    sortedIntegersStatistics = mergeSort.mergeSort(integersInstance.unsortedData, "number");
                    sortedBytesStatistics = mergeSort.mergeSort(bytesInstance.unsortedData, "number");



                    for (int t = 0; t < sortedDoublesStatistics.sortedArray.Length - 1; t++)
                    {
                        doubleInstance.sortedData.Add(sortedDoublesStatistics.sortedArray[t]);
                        integersInstance.sortedData.Add(sortedDoublesStatistics.sortedArray[t]);
                        bytesInstance.sortedData.Add(sortedBytesStatistics.sortedArray[t]);
                    }


                    for (Int64 t = arrayLenght - 1; t > 0; t--)
                    {

                        integersInstance.inversedSortedData.Add(sortedIntegersStatistics.sortedArray[t]);
                        doubleInstance.inversedSortedData.Add(sortedDoublesStatistics.sortedArray[t]);
                        bytesInstance.inversedSortedData.Add(sortedBytesStatistics.sortedArray[t]);

                    }


                    integerInstances.Add(integersInstance);
                    doubleInstances.Add(doubleInstance);
                    bytesInstances.Add(bytesInstance);

                    sortedDoublesStatistics = null;
                    sortedIntegersStatistics = null;
                    sortedBytesStatistics = null;
                }


            }
            instanceData.Add(integerInstances);
            instanceData.Add(doubleInstances);
            instanceData.Add(bytesInstances);
        }
        return instanceData;
    }


    public static void printGeneatedArraysLenghts(List<List<int>> arrays)
    {
        Console.WriteLine("Foram gerados os seguintes arryas: ");
        for (int i = 0; i < arrays.Count; i++)
        {
            Console.WriteLine("Array {0} com {1} elementos aleatórios", i, arrays[i].Count);
        }
    }


    public static dynamic getNonRepeatedElement(List<dynamic> array, string numberType, Int64 maxDouble)
    {
        dynamic value = null;

        switch (numberType)
        {
            case "double":
                {
                    while (value == null)
                    {
                        dynamic randomValue = _random.NextDouble() * maxDouble;
                        if (!array.Contains(randomValue))
                        {
                            value = randomValue;
                        }
                    }
                    break;
                }

            case "integer":
                {
                    while (value == null)
                    {
                        dynamic randomValue = _random.Next();
                        if (!array.Contains(randomValue))
                        {
                            value = randomValue;
                        }

                    }
                    break;
                }

        }
        return value;

    }


    public static async Task<string> writePlotConfig(
        string comparisonType,
     string firstMethod,
     string secondMethod,
     string comparisonMetric,
     string numberType,
     string dataState)
    {
        string configPath = @"config-plot/plotConfig.txt";

        Directory.Delete("config-plot/", true);
        Directory.CreateDirectory("config-plot/");

        using StreamWriter file = new(configPath, append: true);

        await file.WriteLineAsync(comparisonType);
        await file.WriteLineAsync(firstMethod);
        await file.WriteLineAsync(secondMethod);
        await file.WriteLineAsync(comparisonMetric);
        await file.WriteLineAsync(numberType);
        await file.WriteLineAsync(dataState);

        return configPath;
    }

}