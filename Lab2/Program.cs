using Lab2.MiniMaxAlgos;
using Pacman.PacmanClasses;

PacmanGame game = new PacmanGame(Field.GetDefaultField(), new MinimaxAlphaBetaPruning(),
    (new Cell(1, 1), new Cell(0, 0), new Cell(3, 5)));
game.Start();

/*
        🟪🟪🟪🟪🟪🟪🟪🟪🟪
        🟪👿▪️▪️▪️▪️▪️▪️🟪
        🟪▪️😇▪️🟪▪️▪️▪️🟪
        🟪🟪🟪▪️🟪▪️🟪🟪🟪
        🟪▪️▪️▪️🟪▪️❌▪️🟪
        🟪▪️▪️▪️▪️▪️▪️▪️🟪
        🟪🟪🟪🟪🟪🟪🟪🟪🟪
 */