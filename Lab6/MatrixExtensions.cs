namespace Lab6;

public static class MatrixExtensions
{
    public static double FindDeterminant(this ref  Matrix mat)
    {
        double D = 0;

        if (mat.M == 1)
            return mat[0, 0];

        Matrix cofactor = new Matrix(mat.M - 1);

        int sign = 1;

        for (int i = 0; i < mat.N; i++)
        {
            GetCofactor(ref mat, ref cofactor, 0, i);
            D += sign * mat[0, i] *
                 FindDeterminant(ref cofactor);

            sign = -sign;
        }

        return D;
    }

    public static void GetCofactor(ref Matrix mat, ref Matrix cofactor, int p, int q)
    {
        int i = 0, j = 0;

        foreach (var indexes in mat)
        {
            if (indexes.i != p && indexes.j != q)
            {
                cofactor[i, j] = mat[indexes];

                j++;
                if (j == cofactor.N)
                {
                    j = 0;
                    i++;
                }
            }
        }
    }

    public static Matrix GetColumnsSubMatrix(this ref Matrix mat, params int[] includeColumns)
    {
        int j = 0;
        var resultingMat = new Matrix(mat.M, includeColumns.Length);
        
        foreach (var indexes in mat)
        {
            if (includeColumns.Contains(indexes.j))
            {
                resultingMat[indexes.i, j] = mat[indexes];

                j++;
                if (j == includeColumns.Length)
                    j = 0;
            }
        }

        return resultingMat;
    }

    public static bool IsInvertible(this ref Matrix mat) => mat.FindDeterminant() != 0;
    
    public static bool IsSingular(this ref Matrix mat) => mat.FindDeterminant() == 0;

    public static void AddRows(this ref Matrix mat, int fromRow, int subRow, double factor)
    {
        for (int i = 0; i < mat.N; i++)
        {
            mat[fromRow, i] += mat[subRow, i] * factor;
        }
    }
    
    public static void SubtractRows(this ref Matrix mat, int fromRow, int subRow, double factor)
    {
        for (int i = 0; i < mat.N; i++)
        {
            mat[fromRow, i] -= mat[subRow, i] * factor;
        }
    }
    
    public static void MultipleRow(this ref Matrix mat, int targetRow, double factor)
    {
        for (int i = 0; i < mat.N; i++)
        {
            mat[targetRow, i] *= factor;
        }
    }

    public static void GaussianDiagonal(ref Matrix mat, double[] bVector, int[] indexes)
    {
        GaussianBottomTriangle(ref mat, bVector, indexes);
        GaussianTopTriangle(ref mat, bVector, indexes);
    }
    
    public static void GaussianBottomTriangle(ref Matrix mat, double[] bVector, int[] indexes)
    {
        for (int i = 0; i < indexes.Length; i++)
        {
            int topRowIndex = -1;
            for (int row = i; row < mat.M; row++)
            {
                if(mat[row, indexes[i]] == 0)
                    continue;

                if (topRowIndex == -1)
                {
                    topRowIndex = row;
                    continue;
                }

                double divideFactor = 1f / mat[topRowIndex, indexes[i]];
                double multFactor = mat[row, indexes[i]];
                mat.MultipleRow(topRowIndex, divideFactor);
                
                bVector[topRowIndex] *= divideFactor;
                bVector[row] -= bVector[topRowIndex] * multFactor;
            
                mat.SubtractRows(row, topRowIndex, multFactor);
            }

            if (topRowIndex != i)
            {
                double tmp = 0;
                for (int j = 0; j < mat.N; j++)
                {
                    tmp = mat[topRowIndex, j];
                    mat[topRowIndex, j] = mat[i, j];
                    mat[i, j] = tmp;
                }

                tmp = bVector[topRowIndex];
                bVector[topRowIndex] = bVector[i];
                bVector[i] = tmp;
            }
        }

        int lastIndex = indexes.Length - 1;
        double lastDivideFactor = 1f / mat[lastIndex, indexes[lastIndex]];
        mat.MultipleRow(lastIndex, lastDivideFactor);
        bVector[lastIndex] *= lastDivideFactor;
    }

    public static void GaussianTopTriangle(ref Matrix mat, double[] bVector, int[] indexes)
    {
        for (int i = indexes.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                double factor = mat[j, indexes[i]];

                bVector[j] -= bVector[i] * factor;
                mat.SubtractRows(j, i, factor);
            }
        }
    }
}