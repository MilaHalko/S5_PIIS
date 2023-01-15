using Lab6;

var initial = new double[] { 2, 1, 2 };
var nelderMead = new NelderMead(initial, 1);
Console.WriteLine($"Initial:\n{nelderMead.SimplexTable}");
double[] functionValues = new double[nelderMead.SimplexTable.Height];

UpdateFunctionValues();

Console.WriteLine($"Current min: {functionValues[0]}\n");
nelderMead.Apply(TargetFunction, 300, 0.01);
Console.WriteLine($"Final:\n{nelderMead.SimplexTable}");

UpdateFunctionValues();

Console.WriteLine("Final min:" + functionValues[0]);

void UpdateFunctionValues()
{
    for (int row = 0; row < functionValues.Length; row++)
    {
        functionValues[row] = TargetFunction(nelderMead.SimplexTable.GetRow(row));
    }

    Array.Sort(functionValues);
}

static double TargetFunction(double[] vector)
{
    return
        + 3 * vector[0] * vector[0] * vector[1]
        - 3 * vector[0] * vector[1] * vector[1]
        + 4 * vector[0] * vector[0] * vector[1] * vector[2]
        - 5 * vector[0] * vector[2] * vector[2];
}