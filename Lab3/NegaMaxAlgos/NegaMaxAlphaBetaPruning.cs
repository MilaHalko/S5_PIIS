namespace Lab3;

public class NegaMaxAlphaBetaPruning : INegaMax
{
    private int Apply(Field board, int depth, int color, int alpha, int beta)
    {
        if (depth == 9 || board.GameFinished(out _))
        {
            return color * board.GetScore(depth);
        }

        int value = int.MinValue;
        foreach (var adjacent in board.GetAdjacents(color == 1))
        {
            value = Math.Max(value, -1 * Apply(adjacent, depth + 1, color * -1, -1 * beta, -1 * alpha));
            
            alpha = Math.Max(alpha, value);
            if (alpha >= beta)
            {
                break;
            }
        }

        return value;
    }


    public Field GetBestMove(Field field)
    {
        var adjacents = field.GetAdjacents(true);
        Field bestField = null;
        var bestScore = Int32.MinValue;
        foreach (var adj in adjacents)
        {
            var adjScore = -1*Apply(adj, 1, -1,int.MinValue, int.MaxValue);
            if (bestScore < adjScore)
            {
                bestScore = adjScore;
                bestField = adj;
            }
        }

        return bestField;
    }
}