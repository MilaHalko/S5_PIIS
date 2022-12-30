namespace Pacman.PacmanClasses;

public class Cell
{
    public int X { get; set; }  // as I
    public int Y { get; set; }  // as J

    public Cell()
    {
    }
    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool SameCell(Cell cell)
    {
        return X == cell.X && Y == cell.Y;
    }
}