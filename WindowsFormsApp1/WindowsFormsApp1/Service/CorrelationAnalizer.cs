using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class CorrelationAnalyzer
{
    public Dictionary<string, double> AnalyzeCorrelation(DataTable data, List<string> featureColumns, List<string> targetColumns)
    {
        Dictionary<string, double> correlationResults = new Dictionary<string, double>();

        foreach (string targetColumn in targetColumns)
        {
            if (!data.Columns.Contains(targetColumn))
            {
                throw new ArgumentException($"Столбец {targetColumn} отсутствует в исходных данных.");
            }

            double correlation = CalculateCorrelation(data, targetColumn, featureColumns);
            correlationResults.Add(targetColumn, correlation);
        }

        return correlationResults;
    }

    private double CalculateCorrelation(DataTable data, string targetColumn, List<string> featureColumns)
    {
        double[] targetValues = data.AsEnumerable().Select(row => ParseDouble(row[targetColumn])).ToArray();

        double correlation = 0.0;

        foreach (string featureColumn in featureColumns)
        {
            if (data.Columns.Contains(featureColumn) && featureColumn != targetColumn)
            {
                double[] featureValues = data.AsEnumerable().Select(row => ParseDouble(row[featureColumn])).ToArray();
                double featureCorrelation = CalculatePearsonCorrelation(targetValues, featureValues);
                correlation += featureCorrelation;
            }
        }

        return correlation;
    }

    private double ParseDouble(object value)
    {
        return double.Parse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
    }

    private double CalculatePearsonCorrelation(double[] x, double[] y)
    {
        if (x.Length != y.Length)
        {
            throw new ArgumentException("Массивы x и y должны быть одинаковой длины.");
        }

        int n = x.Length;

        double sumX = x.Sum();
        double sumY = y.Sum();

        double sumXSquare = x.Sum(xi => xi * xi);
        double sumYSquare = y.Sum(yi => yi * yi);

        double sumXY = 0.0;
        for (int i = 0; i < n; i++)
        {
            sumXY += x[i] * y[i];
        }

        double numerator = n * sumXY - sumX * sumY;
        double denominator = Math.Sqrt((n * sumXSquare - sumX * sumX) * (n * sumYSquare - sumY * sumY));

        if (denominator == 0)
        {
            return 0;
        }

        return numerator / denominator;
    }
}
