// (c) 2022 Ervin Peters (coder@ervnet.de)
// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Linq;

using No._12;

string[] topoData = File.ReadAllText("content.txt")
    .Split("\n")
    .Where(row => !string.IsNullOrWhiteSpace(row)).ToArray();

RasterMap rasterMap = new(topoData);

uint result = rasterMap.findPath();

Console.WriteLine($"Part 1: found Path with {result} steps.");