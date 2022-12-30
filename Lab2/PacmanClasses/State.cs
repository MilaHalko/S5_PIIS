namespace Pacman.PacmanClasses;

public class State
{
    private Field _field;
    private Cell _pacman;
    private Cell _enemy;
    private Cell _destination;

    public State(Field field, Cell pacman, Cell enemy, Cell destination)
    {
        _field = field;
        _pacman = pacman;
        _enemy = enemy;
        _destination = destination;
    }

    // TODO: Score get by path finding 
    public int GetScore() => 1;
    public IEnumerable<State> GetAdjacents()
    {
        List<State> states = new List<State>();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 || j == 0)
                {
                    Cell adj = new Cell(_pacman.X + i, _pacman.Y + j);
                    if (ValidCell(adj))
                    {
                        states.Add(new State(_field, adj, _enemy, _destination));
                    }
                }
            }
        }
        return states;
    }
    
    public bool EnemyWon() => _pacman.SameCell(_enemy);
    private bool ValidCell(Cell cell) => cell.X >= 0 && cell.Y >= 0 && 
                                         cell.X < _field.Height && cell.Y < _field.Width && 
                                         _field[cell] != 0;

    public void FieldOutput()
    {
        string[,] stringMaze = new string[_field.Height, _field.Width];
            for (int i = 0; i < _field.Height; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    switch (_field[i, j])
                    {
                        case 0:
                            stringMaze[i, j] = "🟪";
                            break;
                        case 1:
                            stringMaze[i, j] = "⬛️";
                            break;
                        case 3:
                            stringMaze[i, j] = "😇";
                            break;
                        case 6:
                            stringMaze[i, j] = "👿";
                            break;
                        case 9:
                            stringMaze[i, j] = "🟥";
                            break;
                    }
                }
            }
            Console.WriteLine("🟪🟪🟪🟪🟪🟪🟪🟪🟪");
            for (int i = 0; i < _field.Height; i++)
            {
                Console.Write("🟪");
                for (int j = 0; j < _field.Width; j++)
                {
                    Console.Write(stringMaze[i, j]);
                }
                Console.WriteLine("🟪");
            }
            Console.WriteLine("🟪🟪🟪🟪🟪🟪🟪🟪🟪");
        }
    }