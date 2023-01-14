namespace Pacman.PacmanClasses;

public class Cell
{
    
    /// <summary>
    /// I index
    /// </summary>
    public int X { get; set; }
    
    /// <summary>
    /// J index
    /// </summary>
    public int Y { get; set; }

    public Cell(Cell old) : this(old.X, old.Y) {}
    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }
    private bool Equals(Cell other)
    {
        return X == other.X && Y == other.Y;
    }

    public static bool operator ==(Cell left, Cell right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Cell left, Cell right)
    {
        return !left.Equals(right);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}