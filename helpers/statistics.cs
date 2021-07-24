

using System.IO;
using System.Threading.Tasks;
class Statistics
{
    public string algorithmName = "";
    public int numberOfComparisons = 0;

    public dynamic totalTimeOfExecution = 0;

    public dynamic[] sortedArray;

    public void printStatics()
    {
        Functions.showMessage("Nome do algortimo: " + this.algorithmName);
        Functions.showMessage("Numero de comparações: " + this.numberOfComparisons);
        Functions.showMessage("Tempo total de execução: " + this.totalTimeOfExecution);
        for (int i = 0; i < this.sortedArray.Length; i++)
        {
            Functions.showMessage(sortedArray[i]);
        }
    }

    public int getInstanceSize()
    {
        return this.sortedArray.Length;
    }


    public async void writeStatisticsToDisc(Instance instance)
    {
        string resultsPath = "results/instance-of-" + this.sortedArray.Length.ToString() + "-elements.txt";

        string instanceSeparator = "===================================";

        string algorithmName = "algorithmName:" + this.algorithmName;
        string numberOfComparisons = "numberOfComparisons:" + this.numberOfComparisons;
        string totalTimeOfExecution = "totalTimeOfExecution:" + this.totalTimeOfExecution;
        string dataType = "dataType:" + instance.dataType;
        string numberType = "numberType:" + instance.numberType;
        string instanceSize = "instanceSize:" + this.sortedArray.Length;


        using StreamWriter file = new(resultsPath, append: true);

        await file.WriteLineAsync(algorithmName);
        await file.WriteLineAsync(numberOfComparisons);
        await file.WriteLineAsync(totalTimeOfExecution);
        await file.WriteLineAsync(dataType);
        await file.WriteLineAsync(numberType);
        await file.WriteLineAsync(instanceSize);
        await file.WriteLineAsync(instanceSeparator);



    }
}