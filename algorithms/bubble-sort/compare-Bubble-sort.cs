class CompareBubbleSort
{

    private static bool numberComparator(double element1, double element2)
    {
        if (element1 > element2)
        {
            return true;
        }
        return false;
    }

    public static bool compareElements(dynamic elementOne, dynamic elementTwo, string dataType)
    {
        switch (dataType)
        {
            case DataTypes.number:
                {
                    return numberComparator(elementOne, elementTwo);
                }
            case DataTypes.generic:
                {
                    throw new System.Exception("Método não implementado");
                }
            default:
                {
                    return numberComparator(elementOne, elementTwo);
                }
        }

    }

}