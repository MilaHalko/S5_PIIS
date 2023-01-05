using System.Security.Cryptography;
using System.Threading.Channels;
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

//var dijkstra = new DijkstraAlgo();
//var results = dijkstra.Solve(matrix, 0);
//Console.WriteLine(string.Join(", ", results));

// string template = "Milka";
// string text = "vaKor loves Milkamilka MiLka ";
// var rabinKarp = new RabinKarpAlgo();
// int entries = rabinKarp.CountEntries(template, text);
// Console.WriteLine(entries);


int[,] prima_matrix =
{
    {0, 4, 3, 4, 0, 0, 0, 0},
    {4, 0, 3, 0, 0, 1, 0, 0},
    {3, 3, 0, 3, 0, 3, 5, 2},
    {4, 0, 3, 0, 0, 0, 0, 2},
    {0, 0, 0, 0, 0, 1, 2, 3},
    {0, 1, 3, 0, 1, 0, 1, 0},
    {0, 0, 5, 0, 2, 1, 0, 1},
    {0, 0, 2, 2, 3, 0, 1, 0}
};

var prima = new Prima();
var primaResult = prima.Solve(prima_matrix);

var finalWeight = 0;
Console.WriteLine();
for (int i = 0; i < primaResult.GetLength(0); i++)
{
    for (int j = 0; j < primaResult.GetLength(1); j++)
    {
        if (i < j)
        {
            finalWeight += primaResult[i, j];
        }
        Console.Write(primaResult[i,j] + "  ");
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine($"Final weight: {finalWeight}");