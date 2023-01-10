namespace Lab5;

public class Arguments
{
    public double[,] array;
    public double[] B;
    public double[] C;
    public int[] basisVector;

    public int Height => array.GetLength(0);
    public int Width => array.GetLength(1);

    public double this[int i, int j]
    {
        get => array[i, j];
        set => array[i, j] = value;
    }
}