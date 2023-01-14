namespace Lab3;

public enum Cell
{
    Empty,
    X,
    O
};

public class Field
{
    public Cell this[int i, int j]
    {
        get => _field[i, j];
        set => _field[i, j] = value;
    }

    public Field(Cell player)
    {
        _player = player;
    }

    public Cell Player => _player;
    private Cell _player;
    private Cell[,] _field = new Cell[3, 3];

    public bool GameFinished(out Cell winner)
    {
        for (int i = 0; i < 3; i++)
        {
            // Check rows and columns
            if ((_field[i, 0] == _field[i, 1]
                 && _field[i, 1] == _field[i, 2]
                 && _field[i, 0] != Cell.Empty)
                ||
                (_field[0, i] == _field[1, i]
                 && _field[1, i] == _field[2, i]
                 && _field[0, i] != Cell.Empty))
            {
                winner = _field[i, 0];
                return true;
            }
        }

        //Check diagonals
        if (_field[1, 1] != Cell.Empty
            &&
            (_field[0, 0] == _field[1, 1]
             && _field[1, 1] == _field[2, 2]
             ||
             _field[0, 2] == _field[1, 1]
             && _field[1, 1] == _field[2, 0]
            ))
        {
            winner = _field[1, 1];
            return true;
        }

        //Check move possibility
        winner = Cell.Empty;
        foreach (var cell in _field)
        {
            if (cell == Cell.Empty)
            {
                return false;
            }
        }

        return true;
    }

    public int GetScore(int depth)
    {
        if (!GameFinished(out Cell winner) || winner == Cell.Empty)
        {
            return 0;
        }

        return winner == _player ? -500 * depth : 500 * depth;
    }

    public IEnumerable<Field> GetAdjacents(Cell player)
    {
        var newStates = new List<Field>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_field[i, j] == Cell.Empty)
                {
                    var state = _field.Clone() as Field;
                    state[i, j] = player;
                    newStates.Add(state);
                }
            }
            
        }
    }
}