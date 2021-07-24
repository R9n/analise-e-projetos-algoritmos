using System;
using System.Collections.Generic;
using System.IO;
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
        Statistics sortedDoublesStatistics;
        Statistics sortedIntegersStatistics;
        Statistics sortedBytesStatistics;


        for (int k = 0; k < config.data.Count; k++)
        {
            dynamic data = config.data[k];


            Instance integersInstance = new Instance();
            Instance doubleInstance = new Instance();
            Instance bytesInstance = new Instance();

            integersInstance.dataType = data.dataType;
            doubleInstance.dataType = data.dataType;
            bytesInstance.dataType = data.dataType;

            integersInstance.numberType = "integer";
            doubleInstance.numberType = "double";
            bytesInstance.numberType = "bytes";

            if (data.dataType == DataTypes.number)
            {
                dynamic sizes = data.arraysSizes;

                for (int i = 0; i < sizes.Count; i++)
                {

                    Int64 arrayLenght = sizes[i];

                    byte[] randomBytes = new byte[arrayLenght];
                    _random.NextBytes(randomBytes);

                    for (int j = 0; j < arrayLenght; j++)
                    {
                        doubleInstance.unsortedData.Add(_random.NextDouble() * arrayLenght);
                        integersInstance.unsortedData.Add(_random.Next());
                        bytesInstance.unsortedData.Add(randomBytes[j]);
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

                    sortedDoublesStatistics = null;
                    sortedIntegersStatistics = null;
                    sortedBytesStatistics = null;
                }

            }

            instanceData.Add(integersInstance);
            instanceData.Add(doubleInstance);
            instanceData.Add(bytesInstance);

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






}