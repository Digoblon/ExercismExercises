public static class BinarySearch
{
    public static int Find(int[] input, int value)
{
    List<int> inputList = new List<int>(input);
    inputList.Sort();

    int left = 0;
    int right = inputList.Count - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        if (inputList[mid] == value)
            return mid;

        if (inputList[mid] > value)
            right = mid - 1;
        else
            left = mid + 1;
    }

    return -1;
}
}