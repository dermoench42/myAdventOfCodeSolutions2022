// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._10;

// 20th, 60th, 100th, 140th, 180th, and 220th

List<string> instructions = File.ReadAllText("content.txt")
    .Split("\n")
    .Where(row => !string.IsNullOrWhiteSpace(row))
    .ToList();

Cpu cpu = new();

List<int> keys = new()
{
    20,
    60,
    100,
    140,
    180,
    220
};

Console.WriteLine($"the SumOfStrength is {cpu.run(instructions, keys)}");

Console.WriteLine(cpu.display());