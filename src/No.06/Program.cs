// (c) 2022 Ervin Peters (coder@ervnet.de)
// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

using No._06;

int pos = StartOfPaketDetector.findStart(File.ReadAllText("content.txt"), 4);
Console.WriteLine($"start packet found at {pos}");

pos = StartOfPaketDetector.findStart(File.ReadAllText("content.txt"), 14);
Console.WriteLine($"start message found at {pos}");