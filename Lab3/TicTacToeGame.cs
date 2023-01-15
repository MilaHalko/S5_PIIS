namespace Lab3;

public class TicTacToeGame
{
    private Field _field;
    private bool _playerTurn;
    private INegaMax _negaMax;

    public TicTacToeGame(bool playerTurn, INegaMax negaMax)
    {
        _playerTurn = playerTurn;
        _negaMax = negaMax;
        _field = new Field(_playerTurn ? Cell.X : Cell.O);
    }

    public void Play()
    {
        Console.WriteLine(_field);
        Cell winner = Cell.Empty;
        while (!_field.GameFinished(out winner))
        {
            if (_playerTurn)
            {
                PlayerMove();
            }
            else
            {
                ComputerMove();
            }
    
            _playerTurn = !_playerTurn;
            Console.Clear();
            Console.WriteLine(_field);
        }

        Console.WriteLine($"Winner is {winner}");
    }

    private void ComputerMove()
    {
        _field = _negaMax.GetBestMove(_field);
    }

    private void PlayerMove()
    {
        int i;
        int j;
        do
        {
            Console.Write("I: ");
            i = InputValidate();
            
            Console.Write("\nJ: ");
            j = InputValidate();
        } while (_field[i, j] != Cell.Empty);
        
        _field[i, j] = _field.Player;
    }

    private static int InputValidate()
    {
        int i;
        while (!(int.TryParse(Console.ReadKey().KeyChar.ToString(), out i) && i is > 0 and < 4))
        {
        }

        return i -1;
    }
}