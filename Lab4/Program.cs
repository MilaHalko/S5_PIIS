using Lab4;

// TEMPLATES
string graph1 = "21=4, 21=4, 23=3, 24=1, 31=3, 36=2, 41=3, 43=3, 56=5, 57=2, 58=3, 63=3, 67=2, 68=3, 73=5, 76=1, 78=2, 83=2, 84=2, 87=4";
string variant6_1 = "25=4, 28=4, 23=3, 24=1, 34=3, 35=2, 42=3, 47=3, 56=5, 57=2, 62=1, 63=3, 65=2, 67=1, 68=3, 76=2, 72=1, 83=2, 84=2, 87=4";
string variant6_2 = "21=4, 28=4, 23=3, 24=1, 31=3, 35=2, 42=3, 47=3, 56=5, 57=2, 62=1, 63=3, 65=2, 67=1, 68=3, 76=2, 72=1, 83=2, 84=2, 87=4";
string template1 = "Milkaaa";
string text1 = "vaKor loves Milkaaamilkaaa MiLkaaa ";
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

int[,] task1 = Parser(variant6_1, false);
int[,] task2 = Parser(variant6_2, true);
PrintGraph(task1);
PrintGraph(task2);
RabinKarp(template1, text1);
Dijkstra(task1);
Prima(task2);


// RABIN-KARP-ALGORITHM
void RabinKarp(string template, string text)
{
    var rabinKarp = new RabinKarpAlgo();
    int entries = rabinKarp.CountEntries(template, text);
    Console.WriteLine("RABIN-KARP-ALGO:");
    Console.WriteLine(entries);
    Console.WriteLine();
}

// DIJKSTRA-ALGORITHM
void Dijkstra(int[,] matrix)
{
    var dijkstra = new DijkstraAlgo();
    var results = dijkstra.Solve(matrix, 0);
    Console.WriteLine("DIJKSTRA-ALGO:");
    Console.WriteLine(string.Join(", ", results));
    Console.WriteLine();
}

// PRIMA-ALGORITHM
void Prima(int[,] matrix)
{
    var prima = new PrimaAlgo();
    var primaResult = prima.Solve(matrix);

    Console.WriteLine("PRIMA-ALGO:");
    PrintGraph(primaResult);
    Console.WriteLine($"OctTree weight: {prima.Weight}");
    Console.WriteLine();
}

int[,] Parser(string rules, bool symmetric)
{
    string[] signs = { " ", ",", "=", "." };
    foreach (var sign in signs)
    {
        rules = rules.Replace(sign, "");
    }

    int sizeGraph = 0;
    for (int i = 0; i < rules.Length; i++)
    {
        if (i % 3 != 0 && sizeGraph < rules[i] - '0')
        {
            sizeGraph = rules[i] - '0';
        }
    }

    int[,] result = new int[sizeGraph, sizeGraph];

    for (int i = 0; i < rules.Length / 3; i++)
    {
        int ver1 = rules[i * 3] - '0' - 1;
        int ver2 = rules[i * 3 + 1] - '0' - 1;
        int weight = rules[i * 3 + 2] - '0';
        result[ver1, ver2] = weight;
        if (symmetric)
        {
            result[ver2, ver1] = weight;
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