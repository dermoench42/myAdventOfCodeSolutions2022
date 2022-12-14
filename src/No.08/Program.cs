// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._08;

List<string> data = File.ReadAllText("content.txt")
    .Split("\n")
    .Where(row => !string.IsNullOrWhiteSpace(row))
    .ToList();

Checker checker = new Checker(data);

int visibleTrees = checker.countVisibleTrees();

Console.WriteLine($"found: {visibleTrees} visible Trees,");

int maxScenic = Checker.calcMaxScenic(data);

Console.WriteLine($"maxScneic: {maxScenic}");