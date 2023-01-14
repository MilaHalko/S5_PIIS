using Pacman.PacmanClasses;
using Pacman.PathAlgos;

public class AStar : IPathSearch
{
    private readonly int[] _rowNum = { -1, 0, 0, 1 };
    private readonly int[] _colNum = { 0, -1, 1, 0 };

    public int FindPath(Field maze, Cell startPoint, Cell destPoint)
    {
        if (maze[startPoint] != 1 || maze[destPoint] != 1)
        {
            return -1;
        }

        bool[,] visitedNodes = new bool[maze.Height, maze.Width];
        visitedNodes[startPoint.X, startPoint.Y] = true;

        PriorityQueue<PathSearchNode, int> queue = new();
        PathSearchNode startPathSearchNode = new PathSearchNode(startPoint, 0);
        queue.Enqueue(startPathSearchNode, GetHeuristic(startPathSearchNode, destPoint));

        while (queue.Count != 0)
        {
            PathSearchNode current = queue.Dequeue();
            Cell cell = current.Cell;

            if (cell.X == destPoint.X && cell.Y == destPoint.Y)
            {
                return current.Distance;
            }

            AddAdjToQueue(queue, current, maze, destPoint, visitedNodes);
        }

        return -1;
    }

    private void AddAdjToQueue(PriorityQueue<PathSearchNode, int> nodeQueue, PathSearchNode current, Field maze,
        Cell destPoint, bool[,] visitedNodes)
    {
        for (int i = 0; i < 4; i++)
        {
            Cell adjCell = new Cell(current.Cell.X + _rowNum[i], current.Cell.Y + _colNum[i]);
            
            if (maze.CellIsValid(adjCell) && maze[adjCell] == 1 &&
                !visitedNodes[adjCell.X, adjCell.Y])
            {
                visitedNodes[adjCell.X, adjCell.Y] = true;

                PathSearchNode adjPathSearchNode = new PathSearchNode(adjCell, current.Distance + 1);
                nodeQueue.Enqueue(adjPathSearchNode, GetHeuristic(adjPathSearchNode, destPoint));
            }
        }
    }

    private int GetHeuristic(PathSearchNode current, Cell destPoint)
    {
        return current.Distance + Math.Abs(destPoint.X - current.Cell.X) + Math.Abs(destPoint.Y - current.Cell.Y);
    }
}