using Pacman.PacmanClasses;
namespace Pacman.MiniMaxAlgos;

public interface IMiniMax
{ 
    int Apply(State state, int depth, bool maxPlayer);
}