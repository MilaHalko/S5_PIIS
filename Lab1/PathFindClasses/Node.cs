namespace AStarAndLi.PathFindClasses;

public class Node
{
    public Node Parent { get; }
    public int Distance { get; }
    public Cell Cell { get; }
    public Node(Cell cell, int distance, Node parent)
    {
        Cell = cell;
        Distance = distance;
        Parent = parent;
    }
}