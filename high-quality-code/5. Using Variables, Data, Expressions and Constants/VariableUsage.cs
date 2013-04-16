public void PrintStatistics(double[] data, int count)
{
    double max = data[0];
    for (int i = 0; i < count; i++)
    {
        if (data[i] > max)
        {
            max = data[i];
        }
    }
    PrintMax(max);
	
    double min = data[0];
    for (int i = 0; i < count; i++)
    {
        if (data[i] < min)
        {
            min = data[i];
        }
    }
    PrintMin(min);

    double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += data[i];
    }
	
	double average = sum / count;
    PrintAvg(average);
}
