namespace Lab3;

public class NegaMaxStandard : INegaMax
{
    public int Apply(Field field, int depth, bool maxPlayer)
    {
        if (depth == 0 || field.GameFinished(out Cell winner))
        {
            return field.GetScore(depth);
        }

        int bestScore = maxPlayer ? Int32.MinValue : Int32.MaxValue;
        foreach (var adjacent in field.GetAdjacents(!maxPlayer))
        {
            int score = Apply(adjacent, depth - 1, !maxPlayer);
            bestScore = maxPlayer ? Math.Max(bestScore, score) : Math.Min(bestScore, score);
        }

        return bestScore;
    }

    public Cell GetBestMove(Field field, int depth)
    {
        var adjacents = field.GetAdjacents(false);
        Field bestField = null;
        var bestScore = Int32.MinValue;
        foreach (var adj in adjacents)
        {
            var adjScore = Apply(adj, depth, false);
            if (bestScore < adjScore)
            {
                bestScore = adjScore;
                bestField = adj;
            }
        }

        return bestField.Enemy;
    }
}