using Pacman.MiniMaxAlgos;
namespace Pacman.PacmanClasses;

public class PacmanGame
{
    private State _state;
    private IMiniMax minimax;
    private bool _gameFinished;

    public PacmanGame(Cell pacman, Cell enemy, Cell destination)
    {
        _state = new State(Field.GetDefaultField(), pacman, enemy, destination);
    }

    public void Start()
    {
        while (!_gameFinished)
        {
            Iterate();
        }
    }

    private void Iterate()
    {
        // foreach(var e in players) e.MakeTurn
        _state.FieldOutput();
    }
}