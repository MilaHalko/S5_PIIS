namespace Lab6;

public class NelderMead
{
    private const double Alpha = 1;
    private const double Beta = 0.5;
    private const double Gamma = 2.5;
    private const double Delta = 0.5;

    private SimplexMatrix _simplexTable;
    private double[] _functionValues;
    private int[] _indexes;

    public SimplexMatrix SimplexTable => _simplexTable;

    public NelderMead(double[] initialVector, double distanceBetweenTwoPoints)
    {
        GenerateSimplexMatrix(initialVector, distanceBetweenTwoPoints);
    }

    public void Apply(Func<double[], double> function, int iterationCount, double precision)
    {
        _functionValues = new double[_simplexTable.Height];
        _indexes = new int[_simplexTable.Height];
        
        for (int i = 0; i < iterationCount; i++)
        {
            for (int row = 0; row < _functionValues.Length; row++)
            {
                _functionValues[row] = function(_simplexTable.GetRow(row));
                _indexes[row] = row;
            }

            Array.Sort(_functionValues, _indexes);
            Array.Reverse(_functionValues);
            Array.Reverse(_indexes);
            //Sorting by descending

            double maxFuncValue = _functionValues[0];
            double secMaxFuncValue = _functionValues[1];
            double minFuncValue = _functionValues[^1];

            if (!double.IsFinite(maxFuncValue) || !double.IsFinite(minFuncValue))
            {
                return;
            }

            int indexMax = _indexes[0];
            int indexMin = _indexes[^1];
            double[] maxRow = _simplexTable.GetRow(indexMax);
            double[] centroid = new double[_simplexTable.Width];
            
            for (int row = 0; row < _simplexTable.Height; row++)
            {
                if (row == indexMax)
                    continue;

                AddRow(centroid,_simplexTable, row);
            }
            DivideByFactor(centroid,_simplexTable.Width);

            if (Math.Sqrt(_functionValues
                    .Select(functionValue => Math.Pow(functionValue - function(centroid), 2))
                    .Sum() / (_simplexTable.Height)) <= precision)
            {
                break;
            }

            double[] reflected = new double[_simplexTable.Width];
            for (int row = 0; row < reflected.Length; row++)
            {
                reflected[row] = centroid[row] + Alpha * (centroid[row] - maxRow[row]);
            }

            double reflectedFuncValue = function(reflected);
            if (reflectedFuncValue < secMaxFuncValue &&
                reflectedFuncValue >= minFuncValue)
            {
                _simplexTable.SetRow(indexMax, reflected);
                continue;
            }

            if (reflectedFuncValue < minFuncValue)
            {
                double[] expandedPoint = new double[_simplexTable.Width];
                for (int row = 0; row < expandedPoint.Length; row++)
                {
                    expandedPoint[row] = centroid[row] + Gamma * (reflected[row] - centroid[row]);
                }

                _simplexTable.SetRow(indexMax,
                    function(expandedPoint) <= reflectedFuncValue ? expandedPoint : reflected);
                continue;
            }

            double[] contracted = new double[_simplexTable.Width];
            if (reflectedFuncValue >= secMaxFuncValue)
            {
                for (int row = 0; row < contracted.Length; row++)
                {
                    contracted[row] = centroid[row] + Beta * (reflected[row] - centroid[row]);
                }

                if (function(contracted) <= maxFuncValue)
                {
                    _simplexTable.SetRow(indexMax, contracted);
                    continue;
                }
            }

            var minRow = _simplexTable.GetRow(indexMin);
            for (var j = 0; j < _simplexTable.Height; j++)
            {
                if (j == indexMin) continue;

                var currentRow = _simplexTable.GetRow(j);
                for (int k = 0; k < currentRow.Length; k++)
                {
                    currentRow[k] = minRow[k] + Delta * (currentRow[k] - minRow[k]);
                }

                _simplexTable.SetRow(j, currentRow);
            }
        }
    }

    private static void DivideByFactor(double[] arr, double divider)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] /= divider;
        }
    }

    private static void AddRow(double[] arr, in SimplexMatrix mat, int row, double factor = 1)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] += mat[row, i] * factor;
        }
    }

    private void GenerateSimplexMatrix(double[] initial, double twoPointsDistance)
    {
        _simplexTable = new SimplexMatrix(initial.Length + 1, initial.Length);
        int N = _simplexTable.Width;
        for (int i = 0; i < N; i++)
        {
            _simplexTable[0, i] = initial[i];
        }

        for (int i = 1; i < _simplexTable.Height; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (j == i - 1)
                {
                    _simplexTable[i, j] = _simplexTable[0, j] + D1();
                }
                else
                {
                    _simplexTable[i, j] = _simplexTable[0, j] + D2();
                }
            }
        }

        double D1() => twoPointsDistance / (N * Math.Sqrt(2)) * (Math.Sqrt(N + 1) + N - 1);

        double D2() => twoPointsDistance / (N * Math.Sqrt(2)) * (Math.Sqrt(N + 1) - 1);
    }
}