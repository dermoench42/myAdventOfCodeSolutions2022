// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace No._09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> data = File.ReadAllText("content.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            int touchedPositions = MovingRope.touchedPositions(data);

            Console.WriteLine($"Der Schwanz berührte {touchedPositions} Positionen.");
        }
    }
}