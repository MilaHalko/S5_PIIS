using Pacman.PacmanClasses;
namespace Pacman.MiniMaxAlgos;

public interface IMiniMax
{ 
    Cell GetBestMove(State state, int depth);
}