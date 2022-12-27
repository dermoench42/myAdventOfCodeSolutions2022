// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Linq;

using No._14;

Cave cave = new(File.ReadLines("testCaveData.txt").ToList());

int unitOfSandsResting = cave.letItFall();

Console.WriteLine(cave.show());

Console.WriteLine($"testDate1 {unitOfSandsResting} units");

cave = new(File.ReadLines("CaveData.txt").ToList());

unitOfSandsResting = cave.letItFall();

Console.WriteLine($"Part1 {unitOfSandsResting} units");

cave = new(File.ReadLines("testCaveData.txt").ToList(), true);

Console.WriteLine(cave.show());

unitOfSandsResting = cave.letItFall2();

Console.WriteLine(cave.show());

Console.WriteLine($"testDate2 {unitOfSandsResting} units");

cave = new(File.ReadLines("CaveData.txt").ToList(), true);

unitOfSandsResting = cave.letItFall2();

Console.WriteLine($"Part2 {unitOfSandsResting} units");