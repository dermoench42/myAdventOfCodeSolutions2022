// (c) 2022 Ervin Peters (coder@ervnet.de)

using System.Globalization;

const string FILE_NAME = "data.txt";

Console.WriteLine(File.ReadAllText(FILE_NAME)
    .Split("\n\n")
    .ToList()
    .ConvertAll(block
        => block.Split("\n")
            .ToList()
            .ConvertAll(item => string.IsNullOrWhiteSpace(item) ? 0 : Convert.ToInt64(item, CultureInfo.InvariantCulture))
            .Aggregate((s, sum) => sum += s))
    .OrderByDescending(i => i)
    .Take(3)
    .ToList()
    .Aggregate((s, sum) => sum += s))
    ;