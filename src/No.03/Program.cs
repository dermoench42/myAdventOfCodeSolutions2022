// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

using No._03;

string data = File.ReadAllText("content.txt");

int result = Calculator3.calc(data);

Console.WriteLine($"result {result}");