namespace ChartJs.Blazor.BarChart;

public static class DatasetExtensions
{
    public static void AddValue(this BarDataset<double> dataset, int index, double value)
    {
        if (index >= 0 && index < dataset.Data.Count)
        {
            dataset[index] += value;
        }
        else if (index >= dataset.Data.Count)
        {
            // Extend the dataset if necessary
            for (int i = dataset.Data.Count; i <= index; i++)
            {
                dataset.Add(0);
            }
            dataset[index] = value;
        }
    }
}