using Lab5;

var data = new Arguments
{
    array = new double[,]
    {
        { -1, 1, 1, 0, 0 },
        { 5, 0, 1, 1, 1 },
        { 3, 2, 0, 0, 1 }
    },
    B = new double[] { 2, 11, 6 },
    C = new double[] { -6, 1, -2, 1, -1 },
    basisVector = new int[] { 1, 2, 3 }
};

var simplex = new SimplexMethod(data);
simplex.Solve();