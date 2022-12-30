using Pacman.PacmanClasses;
namespace Pacman.PathAlgoClasses;

public class PathSearchNode
{
    public Cell Cell { get; }
    public int Distance { get; }
    public PathSearchNode Parent { get; }

    public PathSearchNode(Cell cell, int distance, PathSearchNode parent)
    {
        Cell = cell;
        Distance = distance;
        Parent = parent;
    }
}