using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.IO;
using System.Runtime.InteropServices;

namespace trabalho
{
    class Program
    {
        static void Main(string[] args)
        {

            runMain();

        }

        static async void runMain()
        {
            Console.WriteLine(Messages.loadingConfig);

            dynamic config = Functions.loadConfig();




            List<dynamic> sortedInstances = new List<dynamic>();

            if (!Functions.isValidConfig(config))
            {
                Functions.clearConsoleAndShowMessage(Messages.erroLoadingConfig);
                System.Environment.Exit(1);
            }

            dynamic loadedInstances = Functions.generateRandomArrays(config);

            string selectedOption = "";


            RunAllAlgorithms runAll = new RunAllAlgorithms();
            RunSelectedAlgorithms runSelected = new RunSelectedAlgorithms();

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

                Directory.Delete("results/", true);
                Directory.CreateDirectory("results/");

                if (selectedOption == "1")
                {
                    try
                    {
                        await runAll.runAllAlgorithms(loadedInstances);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
                }
                if (selectedOption == "2")
                {
                    try
                    {
                        await runSelected.runSelectedAlgorithms(loadedInstances);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                try
                {
                    Process proc = new System.Diagnostics.Process();
                    string command = "python helpers/show-results.py";

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        proc.StartInfo.FileName = "/bin/bash";
                        proc.StartInfo.Arguments = "-c \" " + command + " \"";
                    }

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        proc.StartInfo.FileName = "cmd";
                        proc.StartInfo.Arguments = "-c \" " + command + " \"";
                    }

                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.Start();

                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}

