using AStarAndLi.PathFindClasses;
namespace AStarAndLi.PathFindAlgos;

public interface IPathFindingAlgorithm
{
    public int FindPath(Labyrinth labyrinth, Cell startPoint, Cell destPoint, out List<Cell> path);
}