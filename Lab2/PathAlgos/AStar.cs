using Pacman.PacmanClasses;
using Pacman.PathAlgoClasses;
namespace Pacman.PathAlgos;

public class AStar : IPathSearch
{
    private int[] _rowNum = { -1, 0, 0, 1 };
    private int[] _colNum = { 0, -1, 1, 0 };
    public int FindPath(Field field, Cell start, Cell end, out List<Cell> path)
    {
        path = null;
        if (field[start] == 0 || field[end] == 0)
        {
            return -1;
        }

        bool[,] visitedNodes = new bool[field.Height, field.Width];
        visitedNodes[start.X, start.Y] = true;

        PriorityQueue<PathSearchNode, int> queue = new();
        PathSearchNode currentNode = new PathSearchNode(start, 0, null);
        return 1;
    }
    
    private Cell[] ReconstructPath()
    {
        
    }
}

class PathNode
{
    public PathNode parent { get; }
    public Cell cell { get; }
    public int g { get; }
    public int h { get; }

    public PathNode(Cell cell, PathNode parent, int distance, int heuristic = 1)
    {
        this.cell = cell;
        this.parent = parent;
        g = distance;
        h = heuristic;
    }
    public int GetF()
    {
        return g + h;
    }
}