namespace Lab4;

public class Prima
{
    private int[,] _matrix;
    private int matrixSize;
    private int[,] _octoTree;
    private bool[] _addedVertices;

    public int[,] Solve(int[,] matrix)
    {
        _matrix = matrix;
        matrixSize = matrix.GetLength(0);
        _octoTree = new int[matrixSize, matrixSize];
        _addedVertices = new bool[matrixSize];

        for (int i = 0; i < matrixSize - 1; i++)
        {
            var edge = GetMinEdge(_addedVertices);
            SetEdge(edge);
        }

        return _octoTree;
    }

    private (int ver1, int ver2, int weight) GetMinEdge(bool[] vertices)
    {
        bool firstIteration = vertices.All(ver => !ver);
        (int ver1, int ver2, int weight) edge = (-1, -1, int.MaxValue);
        for (var ver1 = 0; ver1 < vertices.Length; ver1++)
        {
            if (vertices[ver1] || firstIteration)
            {
                for (int ver2 = 0; ver2 < matrixSize; ver2++)
                {
                    if (!vertices[ver2] && _matrix[ver1, ver2] > 0 && _matrix[ver1, ver2] < edge.weight)
                    {
                        edge = (ver1, ver2, _matrix[ver1, ver2]);
                    }
                }
            }
        }

        return edge;
    }

    private void SetEdge((int ver1, int ver2, int weight) edge)
    {
        _addedVertices[edge.ver1] = true;
        _addedVertices[edge.ver2] = true;
        _octoTree[edge.ver1, edge.ver2] = edge.weight;
        _octoTree[edge.ver2, edge.ver1] = edge.weight;
        Console.WriteLine($"Edge: {edge.ver1}-{edge.ver2}  |  Weight: {edge.weight}");
    }
}