namespace AStarAndLi.PathFindClasses;

public class Labyrinth
{
    private readonly int[,] _matrix;
    public int this[int x, int y] => _matrix[x, y];
    public int this[Cell cell] => _matrix[cell.X, cell.Y];
    public int Height => _matrix.GetLength(0);
    public int Width => _matrix.GetLength(1);

    private Labyrinth(int[,] matrix)
    {
        _matrix = matrix;
    }
    public static Labyrinth GenerateDefaultMaze() => new(new[,]
    {
        { 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1 },
    });
}