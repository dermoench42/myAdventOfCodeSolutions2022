// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._07;

List<string> data = File.ReadAllText("content.txt")
    .Split("\n")
    .Where(row => !string.IsNullOrWhiteSpace(row))
    .ToList();

long size = new Calculator(data).sizeOfDirsWithContentBelow(100_000);

Console.WriteLine($"Size to Remove: {size}");