using Pacman.MiniMaxAlgos;

namespace Pacman.PacmanClasses;

public class PacmanGame
{
    private State _currState;
    private IMiniMax _minimax;
    private bool _playerTurn;

    public PacmanGame(Field maze, IMiniMax algorithm, (Cell pacman, Cell enemy, Cell destination) coordinates)
    {
        _minimax = algorithm;
        _currState = new State(maze, coordinates.pacman, coordinates.enemy, coordinates.destination);
        _playerTurn = true;
    }

    public void Start()
    {
        Console.WriteLine(_currState);
        while (!_currState.IsTerminal)
        {
            if (_playerTurn)
            {
                PlayerMove();
            }
            else
            {
                EnemyMove();
            }
            Console.Clear();
            Console.WriteLine(_currState);
            _playerTurn = !_playerTurn;
        }

        Console.WriteLine($"{(_playerTurn ? "Enemy" : "Player")} won!");
    }

    private void EnemyMove()
    {
        Thread.Sleep(500);
        var enemyMove = _minimax.GetBestMove(_currState, 3);
        _currState.Enemy = enemyMove;
    }

    private void PlayerMove()
    {
        while (!TryMakeMove(Console.ReadKey().Key))
        {
        }

        bool TryMakeMove(ConsoleKey key)
        {
            var choice = new Cell(_currState.Pacman);
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    choice.X--;
                    break;
                case ConsoleKey.DownArrow:
                    choice.X++;
                    break;
                case ConsoleKey.RightArrow:
                    choice.Y++;
                    break;
                case ConsoleKey.LeftArrow:
                    choice.Y--;
                    break;
                default:
                    return false;
            }

            bool moveIsValid = _currState.Field.CellIsValid(choice);
            if (moveIsValid)
            {
                _currState.Pacman = choice;
            }

            return moveIsValid;
        }
    }
}