using System.Text;
using Pacman.PathAlgos;

namespace Pacman.PacmanClasses;

public class State
{
    public Field Field;
    public Cell Pacman;
    public Cell Enemy;
    public Cell Destination;
    private IPathSearch _searchAlgo;

    public State(Field field, Cell pacman, Cell enemy, Cell destination)
    {
        Field = field;
        Pacman = pacman;
        Enemy = enemy;
        Destination = destination;
        _searchAlgo = new AStar();
    }

    public bool IsTerminal => Pacman == Destination || Enemy == Pacman;
    
    public int GetScore() => _searchAlgo.FindPath(Field, Pacman, Destination)
                             - _searchAlgo.FindPath(Field, Enemy, Pacman) * 10;

    public IEnumerable<State> GetAdjacents(bool isPacman)
    {
        Cell curr = isPacman ? Pacman : Enemy;
        List<State> states = new List<State>();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 || j == 0)
                {
                    Cell adj = new Cell(curr.X + i, curr.Y + j);
                    if (Field.CellIsValid(adj))
                    {
                        if (isPacman)
                        {
                            states.Add(new State(Field, adj, Enemy, Destination));    
                        }
                        else
                        {
                            states.Add(new State(Field, Pacman, adj, Destination));
                        }
                    }
                }
            }
        }

        return states;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string[,] stringMaze = new string[Field.Height, Field.Width];
        for (int i = 0; i < Field.Height; i++)
        {
            for (int j = 0; j < Field.Width; j++)
            {
                stringMaze[i, j] = Field[i, j] == 0 ? "🟪" : "  ";
            }
        }

        stringMaze[Pacman.X, Pacman.Y] = "😇";
        stringMaze[Enemy.X, Enemy.Y] = "👿";
        stringMaze[Destination.X, Destination.Y] = "🟥";

        sb.AppendLine("🟪🟪🟪🟪🟪🟪🟪🟪🟪");
        for (int i = 0; i < Field.Height; i++)
        {
            sb.Append("🟪");
            for (int j = 0; j < Field.Width; j++)
            {
                sb.Append(stringMaze[i, j]);
            }

            sb.AppendLine("🟪");
        }

        sb.AppendLine("🟪🟪🟪🟪🟪🟪🟪🟪🟪");
        return sb.ToString();
    }
}