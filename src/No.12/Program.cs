// (c) 2022 Ervin Peters (coder@ervnet.de)
// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Linq;

using No._12;

string[] topoData = File.ReadAllText("content.txt")
    .Split("\n")
    .Where(row => !string.IsNullOrWhiteSpace(row)).ToArray();

MazePart1 mazePart1 = new(topoData);

uint result = mazePart1.findPath();

Console.WriteLine($"Part 1: found Path with {result} steps.");

MazePart2 mazePart2 = new(topoData);

result = mazePart2.findPath();

Console.WriteLine($"Part 2: found Path with {result} steps.");