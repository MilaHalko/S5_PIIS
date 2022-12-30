using Pacman.PacmanClasses;
using Pacman.MiniMaxAlgos;

public class MiniMaxStandard : IMiniMax
{
    public MiniMaxStandard()
    {
    }

    public int Apply(State state, int depth, bool maxPlayer)
    {
        if (depth == 0 || state.EnemyWon())
        {
            return state.GetScore();
        }

        int bestScore = maxPlayer? Int32.MinValue : Int32.MaxValue;
        foreach (var adjacent in state.GetAdjacents()) 
        {
            int score = Apply(adjacent, depth - 1, !maxPlayer);
            bestScore = maxPlayer? Math.Max(bestScore, score) : Math.Min(bestScore, score);
        }
        return bestScore;
    }
}