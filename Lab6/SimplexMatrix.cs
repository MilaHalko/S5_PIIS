using System.Collections;
using System.Text;

namespace Lab6;

public struct SimplexMatrix
{
    public double this[int row, int column]
    {
        get => _matrix[row, column];
        set => _matrix[row, column] = value;
    }

    public int Height => _matrix.GetLength(0);
    public int Width => _matrix.GetLength(1);

    private readonly double[,] _matrix;
        
    public SimplexMatrix(int rows, int columns)
    {
        _matrix = new double[rows, columns];
    }

    public double[] GetRow(int m)
    {
        var arr = new double[Width];
        for (int i = 0; i < Width; i++)
        {
            arr[i] = this[m, i];
        }

        return arr;
    }
    
    public void SetRow(int m, double[] row)
    {
        for (int i = 0; i < Width; i++)
        { 
            this[m, i] = row[i];
        }
    }

    public override string ToString()
    {
        var strBuilder = new StringBuilder();
        for (int i = 0; i < Height; i++)
        {
            strBuilder.Append(' ');
            strBuilder.AppendJoin(", ", GetRow(i));
            strBuilder.Append('\n');
        }

        return strBuilder.ToString();
    }
}