// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._05;

List<string> data = File.ReadAllText("content.txt")
    .Split("\n\n")
    .Where(line => !string.IsNullOrWhiteSpace(line))
    .ToList();

string result = Calculator.calc(data[0], data[1]);

Console.WriteLine($"result: {result}");

result = Calculator.calc2(data[0], data[1]);

Console.WriteLine($"result Part2: {result}");