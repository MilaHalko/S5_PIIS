using Pacman.PacmanClasses;
using Pacman.MiniMaxAlgos;

public class MiniMaxStandard : IMiniMax
{
    public int Apply(State state, int depth, bool maxPlayer)
    {
        if (depth == 0 || state.IsTerminal)
        {
            return state.GetScore();
        }

        int bestScore = maxPlayer ? Int32.MinValue : Int32.MaxValue;
        foreach (var adjacent in state.GetAdjacents(!maxPlayer))
        {
            int score = Apply(adjacent, depth - 1, !maxPlayer);
            bestScore = maxPlayer ? Math.Max(bestScore, score) : Math.Min(bestScore, score);
        }

        return bestScore;
    }

    public Cell GetBestMove(State state, int depth)
    {
        var adjacents = state.GetAdjacents(false);
        State bestState = null;
        var bestScore = Int32.MinValue;
        foreach (var adj in adjacents)
        {
            var adjScore = Apply(adj, depth, false);
            if (bestScore < adjScore)
            {
                bestScore = adjScore;
                bestState = adj;
            }
        }

        return bestState.Enemy;
    }
}