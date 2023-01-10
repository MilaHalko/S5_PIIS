namespace Lab4;

public class DijkstraAlgo
{
    private int _size;
    private int[] _shortestPathes;
    private bool[] _visitedNodes;
    private int[,] _matrix;

    public int[] Solve(int[,] matrix, int start)
    {
        _size = matrix.GetLength(0);
        _visitedNodes = new bool[_size];
        _shortestPathes = Enumerable.Repeat(int.MaxValue, _size).ToArray();
        _shortestPathes[start] = 0;
        _matrix = matrix;
        
        int node;
        while ((node = NearestNodeIndex()) != -1)
        {
            UpdatePathesLength(node);
            _visitedNodes[node] = true;
        }

        return _shortestPathes.Select(path => path == int.MaxValue ? -1 : path).ToArray();
    }

    private int NearestNodeIndex()
    {
        int pathLength = int.MaxValue;
        int nearestNode = -1;
        for (int node = 0; node < _size; node++)
        {
            if (!_visitedNodes[node] && _shortestPathes[node] < pathLength)
            {
                pathLength = _shortestPathes[node];
                nearestNode = node;
            }
        }

        return nearestNode;
    }

    private void UpdatePathesLength(int node)
    {
        for (int dest = 0; dest < _size; dest++)
        {
            int length = _matrix[node, dest];
            if (_matrix[node, dest] != 0 &&
                !_visitedNodes[dest] &&
                length + _shortestPathes[node] < _shortestPathes[dest])
            {
                _shortestPathes[dest] = length + _shortestPathes[node];
            }
        }
    }
}