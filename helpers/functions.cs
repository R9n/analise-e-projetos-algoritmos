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
        Statistics sortedStatistics;

        for (int k = 0; k < config.data.Count; k++)
        {
            dynamic data = config.data[k];

            Instance unsortedInstance = new Instance();
            Instance sortedInstance = new Instance();

            unsortedInstance.dataType = data.dataType;
            sortedInstance.dataType = data.dataType;

            if (data.dataType == DataTypes.number)
            {

                dynamic sizes = data.arraysSizes;
                List<dynamic> unsortedArrays = new List<dynamic>();
                List<dynamic> sortedArrays = new List<dynamic>();

                for (int i = 0; i < sizes.Count; i++)
                {
                    Int64 arrayLenght = sizes[i];

                    List<dynamic> randomDoubles = new List<dynamic>();
                    List<dynamic> randomIntegers = new List<dynamic>();
                    byte[] randomBytes = new byte[Constraints.maxByteArraySize];

                    List<dynamic> sortedDoubles = new List<dynamic>();
                    List<dynamic> sortedIntegers = new List<dynamic>();
                    byte[] sortedBytes = new byte[Constraints.maxByteArraySize];


                    _random.NextBytes(randomBytes);

                    for (int j = 0; j < arrayLenght; j++)
                    {
                        randomDoubles.Add(_random.NextDouble() * arrayLenght);
                        randomIntegers.Add(_random.Next());
                    }

                    unsortedArrays.Add(randomDoubles);
                    unsortedArrays.Add(randomIntegers);
                    unsortedArrays.Add(randomBytes);

                    sortedStatistics = mergeSort.mergeSort(randomDoubles, "number");
                    sortedArrays.Add(sortedStatistics.sortedArray);

                    sortedStatistics = mergeSort.mergeSort(randomIntegers, "number");
                    sortedArrays.Add(sortedStatistics.sortedArray);

                }
                unsortedInstance.data.Add(unsortedArrays);
                sortedInstance.data.Add(sortedArrays);
            }

            instanceData.Add(unsortedInstance);
            instanceData.Add(sortedInstance);
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