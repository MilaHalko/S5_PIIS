using Pacman.MiniMaxAlgos;
namespace Pacman.PacmanClasses;

public class PacmanGame
{
    private State _state;
    private IMiniMax minimax;

    public PacmanGame(Cell pacman, Cell enemy, Cell destination)
    {
        _state = new State(Field.GetDefaultField(), pacman, enemy, destination);
    }

    public void Start()
    {
        _state.FieldOutput();
        
    }
}