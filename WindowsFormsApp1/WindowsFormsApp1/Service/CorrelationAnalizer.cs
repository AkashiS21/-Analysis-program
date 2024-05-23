using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class CorrelationAnalyzer
{
    public double[,] AnalyzeCorrelation(DataTable data, List<string> featureColumns, List<string> targetColumns)
    {
        var columns = featureColumns.Concat(targetColumns).ToList();
        var matrix = new double[columns.Count, columns.Count];

        for (var row = 0; row < columns.Count; row++)
        {
            for (var column = 0; column < columns.Count; column++)
            {
                var rowName = columns[row];
                var columnName = columns[column];

                var x = data.AsEnumerable().Select(v => ParseDouble(v[rowName])).ToArray();
                var y = data.AsEnumerable().Select(v => ParseDouble(v[columnName])).ToArray();

                matrix[row, column] = CalculatePearsonCorrelation(x, y);
            }
        }
        return matrix;
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
