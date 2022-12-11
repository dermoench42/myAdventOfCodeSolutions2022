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

Calculator calc = new Calculator(data);
long size = calc.sizeOfDirsWithContentBelow(100000);

Console.WriteLine($"Size to Remove: {size}");

const long FS_SIZE = 70000000;
const long NEEDED_FREE_SPACE = 30000000;

long usedSpace = calc.rootDirSize();

long needToFree = usedSpace - (FS_SIZE - NEEDED_FREE_SPACE);

Console.WriteLine($"needTofree: {needToFree}");

long dirSizeToRemove = calc.findSmallestDirAboveSize(needToFree);

Console.WriteLine($"found Dir of Size: {dirSizeToRemove}");