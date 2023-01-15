namespace Lab3;

public class NegaScout : INegaMax
{
    private int Apply(Field board, int depth, int color, int alpha, int beta)
    {
        if (depth == 9 || board.GameFinished(out _))
        {
            return color * board.GetScore(depth);
        }

        // foreach (var adjacent in board.GetAdjacents(color == 1))
        // {
        //     value = Math.Max(value, -1 * Apply(adjacent, depth + 1, color * -1, -1 * beta, -1 * alpha));
        //
        //     alpha = Math.Max(alpha, value);
        //     if (alpha >= beta)
        //     {
        //         break;
        //     }
        // }

        int b = beta;
        var adjacents = board.GetAdjacents(color == 1);
        for (var i = 0; i < adjacents.Count; i++)
        {
            int value = -1 * Apply(adjacents[i], depth + 1, -1 * color, -1 * b, -1 * alpha);
            if (value > alpha && value < beta && i != 0)
            {
                value = -1 * Apply(adjacents[i], depth + 1, -1 * color, -1 * beta, -1 * alpha);
            }


            alpha = Math.Max(alpha, value);
            if (alpha >= beta)
            {
                break;
            }

            b = alpha + 1;
        }

        return alpha;
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