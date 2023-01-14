namespace Pacman.PacmanClasses;
public class Field
{
    private int[,] _maze;
    public int Height => _maze.GetLength(0);
    public int Width => _maze.GetLength(1);
    
    public int this[int x, int y] => _maze[x, y];
    public int this[Cell cell] => _maze[cell.X, cell.Y];

    private Field(int[,] maze)
    {
        this._maze = maze;
    }

    public static Field GetDefaultField() => new Field(new[,]
    {
        { 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 0, 1, 1, 1 },
        { 0, 0, 1, 0, 1, 0, 0 },
        { 1, 1, 1, 0, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1 },
    });

    public bool CellIsValid(Cell cell)
    {
        return cell.X < Height && cell.Y < Width && cell.X >= 0 && cell.Y >= 0 && this[cell] != 0;
    }

    /*
    🟪🟪🟪🟪🟪🟪🟪🟪🟪
    🟪👿▪️▪️▪️▪️▪️▪️🟪
    🟪▪️😇▪️🟪▪️▪️▪️🟪
    🟪🟪🟪▪️🟪▪️🟪🟪🟪
    🟪▪️▪️▪️🟪▪️❌▪️🟪
    🟪▪️▪️▪️▪️▪️▪️▪️🟪
    🟪🟪🟪🟪🟪🟪🟪🟪🟪
     */
};