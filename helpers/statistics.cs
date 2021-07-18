
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
}