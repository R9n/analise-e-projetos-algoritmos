class CompareHeapSort
{

    private static bool numberComparatorLessThan(double element1, double element2)
    {
        if (element1 < element2)
        {
            return true;
        }
        return false;
    }
    private static bool numberComparatorGreaterThan(double element1, double element2)
    {
        if (element1 > element2)
        {
            return true;
        }
        return false;
    }


    public static bool compareElements(dynamic elementOne, dynamic elementTwo, string dataType, string comparationType)
    {
        switch (dataType)
        {
            case DataTypes.number:
                {
                    return comparationType == "less" ? numberComparatorLessThan(elementOne, elementTwo) : numberComparatorGreaterThan(elementOne, elementTwo);
                }
            case DataTypes.generic:
                {
                    throw new System.Exception("Método não implementado");
                }
            default:
                {
                    return numberComparatorLessThan(elementOne, elementTwo);
                }
        }

    }

}