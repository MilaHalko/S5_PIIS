using System.Security.Cryptography;
using Lab4;

int[,] matrix =
{
    {0, 5, 0, 0, 8, 0},
    {0, 0, 0, 1, 0, 0},
    {0, 7, 0, 0, 0, 2},
    {0, 0, 0, 0, 0, 9},
    {0, 0, 4, 3, 0, 2},
    {0, 0, 0, 0, 0, 0}
};

var dijkstra = new DijkstraAlgo();
var results = dijkstra.Solve(matrix, 0);
Console.WriteLine(string.Join(", ", results));