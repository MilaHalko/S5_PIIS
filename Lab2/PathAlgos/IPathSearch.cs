using Pacman.PacmanClasses;
namespace Pacman.PathAlgos;

public interface IPathSearch
{
    public int FindPath(Field maze, Cell start, Cell end);
}

public class PathSearchNode
{ 
    public int Distance { get; }
    public Cell Cell { get; }
    public PathSearchNode(Cell cell, int distance)
    {
        Cell = cell;
        Distance = distance;
    }
}