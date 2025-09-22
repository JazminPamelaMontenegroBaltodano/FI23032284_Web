using System;

class Program
{
    static void Main(string[] args)
    {
        const int Max = int.MaxValue;

        Console.WriteLine("• SumFor:");
        // Ascendente
        var (nAscFor, sumAscFor) = FindAscending(SumFor, Max);
        Console.WriteLine($"\t◦ From 1 to Max → n: {nAscFor} → sum: {sumAscFor}");
        // Descendente
        var (nDescFor, sumDescFor) = FindDescending(SumFor, Max);
        Console.WriteLine($"\t◦ From Max to 1 → n: {nDescFor} → sum: {sumDescFor}");

        Console.WriteLine("\n• SumIte:");
        // Ascendente
        var (nAscIte, sumAscIte) = FindAscending(SumIte, Max);
        Console.WriteLine($"\t◦ From 1 to Max → n: {nAscIte} → sum: {sumAscIte}");
        // Descendente
        var (nDescIte, sumDescIte) = FindDescending(SumIte, Max);
        Console.WriteLine($"\t◦ From Max to 1 → n: {nDescIte} → sum: {sumDescIte}");
    }

    // --- Métodos de suma ---
    static int SumFor(int n) => n * (n + 1) / 2;

    static int SumIte(int n)
    {
        int result = 0;
        for (int i = 1; i <= n; i++)
            result += i;
        return result;
    }

    // --- Estrategias de búsqueda ---
    static (int, int) FindAscending(Func<int, int> method, int max)
    {
        int lastValidN = 0;
        int lastValidSum = 0;
        for (int n = 1; n <= max; n++)
        {
            int sum = method(n);
            if (sum > 0)
            {
                lastValidN = n;
                lastValidSum = sum;
            }
            else break; // en cuanto se vuelve negativo por overflow
        }
        return (lastValidN, lastValidSum);
    }

    static (int, int) FindDescending(Func<int, int> method, int max)
    {
        for (int n = max; n >= 1; n--)
        {
            int sum = method(n);
            if (sum > 0)
                return (n, sum); // primer válido que encuentra
        }
        return (0, 0); // fallback
    }
}
