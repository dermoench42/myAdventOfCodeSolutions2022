// See https://aka.ms/new-console-template for more information

using System.Globalization;

const string fn = "data.txt";

Console.WriteLine(File.ReadAllText(fn)
    .Split("\n\n")
    .ToList()
    .ConvertAll(item
        => item.Split("\n")
            .ToList()
            .ConvertAll(item => string.IsNullOrWhiteSpace(item) ? 0 : Convert.ToInt64(item, CultureInfo.InvariantCulture))
            .Aggregate((s, sum) => sum += s))
    .OrderByDescending(i => i)
    .Take(3)
    .ToList()
    .Aggregate((s, sum) => sum += s))
    ;
