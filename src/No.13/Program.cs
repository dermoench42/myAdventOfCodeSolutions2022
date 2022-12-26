// (c) 2022 Ervin Peters (coder@ervnet.de)
// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

using No._13;

string data = File.ReadAllText("data.txt");

int cntRightOrderedPairs = SignalDecoder.countRightOrderOfPairs(data);

Console.WriteLine($"Part1: {cntRightOrderedPairs}.");

int key = SignalDecoder.sortedInputResult(data);

Console.WriteLine($"Part2: Key {key}.");