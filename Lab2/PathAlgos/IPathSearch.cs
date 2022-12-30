using Pacman.PacmanClasses;
namespace Pacman.PathAlgos;

public interface IPathSearch
{
    public int FindPath(Field field, Cell start, Cell end, out List<Cell> path);
}