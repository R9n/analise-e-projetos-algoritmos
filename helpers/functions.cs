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
        for (int k = 0; k < config.data.Count; k++)
        {
            dynamic data = config.data[k];

            Instance instance = new Instance();
            instance.dataType = data.dataType;

            if (data.dataType == DataTypes.number)
            {
                dynamic sizes = data.arraysSizes;
                List<dynamic> arrays = new List<dynamic>();

                for (int i = 0; i < sizes.Count; i++)
                {
                    List<dynamic> newArray = new List<dynamic>();
                    Int64 arrayLenght = sizes[i];
                    for (int j = 0; j < arrayLenght; j++)
                    {
                        newArray.Add(_random.NextDouble() * arrayLenght);
                    }
                    arrays.Add(newArray);
                }
                instance.data = arrays;
            }

            instanceData.Add(instance);
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