// (c) 2022 Ervin Peters (coder@ervnet.de)
// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

using No._03;

string data = File.ReadAllText("content.txt");

int result = Calculator3.calc(data);

Console.WriteLine($"result: {result}");

result = Calculator3Part2.calc(data);

Console.WriteLine($"result Part2: {result}");