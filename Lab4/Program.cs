using Lab4;

// DATA
string template1 = "owners";
string text1 = "When Mila's dog barks like 'doGS and ownersOwneRs go out', oWners are not responding";
string variant6_1 = "25=4, 28=4, 23=3, 24=1, 34=3, 35=2, 42=3, 47=3, 56=5, 57=2, 62=1, 63=3, 65=2, 67=1, 68=3, 76=2, 72=1, 83=2, 84=2, 87=4";
string variant6_2 = "21=4, 28=4, 23=3, 24=1, 31=3, 35=2, 42=3, 47=3, 56=5, 57=2, 62=1, 63=3, 65=2, 67=1, 68=3, 76=2, 72=1, 83=2, 84=2, 87=4";


// CALLING
int[,] task1 = Parser(variant6_1, 9, false);
int[,] task2 = Parser(variant6_2, 8, true);

RabinKarp(template1, text1);
Dijkstra(task1, 1);
Prima(task2);


// RABIN-KARP-ALGORITHM
void RabinKarp(string template, string text)
{
    var rabinKarp = new RabinKarpAlgo();
    int entries = rabinKarp.CountEntries(template, text);
    
    Console.WriteLine("RABIN-KARP-ALGO:");
    Console.WriteLine($"Text: {text1} \nTemplate: {template1}");
    Console.WriteLine($"Entries: {entries}");
    Console.WriteLine();
}

// DIJKSTRA-ALGORITHM
void Dijkstra(int[,] matrix, int start = 0)
{
    var dijkstra = new DijkstraAlgo();
    var results = dijkstra.Solve(matrix, start);
    
    Console.WriteLine("DIJKSTRA-ALGO:");
    PrintGraph(matrix);
    Console.WriteLine(string.Join(", ", results));
    Console.WriteLine();
}

// PRIMA-ALGORITHM
void Prima(int[,] matrix)
{
    var prima = new PrimaAlgo();
    var primaResult = prima.Solve(matrix);

    Console.WriteLine("PRIMA-ALGO:");
    PrintGraph(matrix);
    PrintGraph(primaResult);
    Console.WriteLine($"OctTree weight: {prima.Weight}");
    Console.WriteLine();
}

int[,] Parser(string input, int size, bool symmetric)
{
    string[] signs = { ",", "=" };
    var connections = input.Split(signs, StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
    int[,] result = new int[size, size];
    for (var i = 0; i < connections.Length - 1; i += 2)
    {
        result[connections[i] / 10 - 1, connections[i] % 10 - 1] = connections[i + 1];
        if (symmetric)
        {
            result[connections[i] % 10 - 1, connections[i] / 10 - 1] = connections[i + 1];
        }
    }

    return result;
}


void PrintGraph(int[,] m)
{
    for (int i = 0; i < m.GetLength(0); i++)
    {
        for (int j = 0; j < m.GetLength(1); j++)
        {
            Console.Write($"{m[i, j]}  ");
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}


// EXTENSION GRAPHS
string variant1_1 =
    "21=4, 21=4, 23=3, 24=1, 31=3, 36=2, 41=3, 43=3, 56=5, 57=2, 58=3, 63=3, 67=2, 68=3, 73=5, 76=1, 78=2, 83=2, 84=2, 87=4";

int[,] orientedGraph66 =
{
    { 0, 5, 0, 0, 8, 0 },
    { 0, 0, 0, 1, 0, 0 },
    { 0, 7, 0, 0, 0, 2 },
    { 0, 0, 0, 0, 0, 9 },
    { 0, 0, 4, 3, 0, 2 },
    { 0, 0, 0, 0, 0, 0 }
};
int[,] symmetricalGraph88 =
{
    { 0, 4, 3, 4, 0, 0, 0, 0 },
    { 4, 0, 3, 0, 0, 1, 0, 0 },
    { 3, 3, 0, 3, 0, 3, 5, 2 },
    { 4, 0, 3, 0, 0, 0, 0, 2 },
    { 0, 0, 0, 0, 0, 1, 2, 3 },
    { 0, 1, 3, 0, 1, 0, 1, 0 },
    { 0, 0, 5, 0, 2, 1, 0, 1 },
    { 0, 0, 2, 2, 3, 0, 1, 0 }
};