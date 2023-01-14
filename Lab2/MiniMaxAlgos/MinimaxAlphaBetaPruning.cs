using Pacman.MiniMaxAlgos;
using Pacman.PacmanClasses;

namespace Lab2.MiniMaxAlgos;

public class MinimaxAlphaBetaPruning : IMiniMax
{
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

    private int Apply(State curr, int depth, bool maxPlayer, int alpha = Int32.MinValue, int beta = Int32.MaxValue)
    {
        if (depth == 0 || curr.IsTerminal)
        {
            return curr.GetScore();
        }

        if (maxPlayer)
        {
            int maxEvaluation = Int32.MinValue;
            foreach (var child in curr.GetAdjacents(!maxPlayer))
            {
                int evaluation = Apply(child, depth - 1, false, alpha,beta);
                maxEvaluation = Math.Max(maxEvaluation, evaluation);
                alpha = Math.Max(alpha, evaluation);
                if (beta<=alpha)
                {
                    break;
                }
            }
            return maxEvaluation;
        }
        else
        {
            int minEvaluation = Int32.MaxValue;
            foreach (var child in curr.GetAdjacents(!maxPlayer))
            {
                int evaluation = Apply(child, depth - 1, true, alpha,beta);
                minEvaluation = Math.Min(minEvaluation, evaluation);
                beta = Math.Min(beta, evaluation);
                if (beta<=alpha)
                {
                    break;
                }
            }
            return minEvaluation;
        }
    }
}