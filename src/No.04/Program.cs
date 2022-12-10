// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._04;

List<string> data = File.ReadAllText("content.txt")
    .Split("\n")
    .Where(line => !string.IsNullOrWhiteSpace(line))
    .ToList();

int result = Calculator.calc(data);

Console.WriteLine($"result: {result}");

result = Calculator.calc2(data);

Console.WriteLine($"result Part2: {result}");