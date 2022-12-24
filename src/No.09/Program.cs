// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace No._09
{
    internal class Program
    {
        static void Main()
        {
            List<string> data = File.ReadAllText("content.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            int cntKnots = 2;
            int touchedPositions = MovingRope.touchedPositions(data, cntKnots);

            Console.WriteLine($"Der Schwanz nach {cntKnots} Knoten berührte {touchedPositions} Positionen.");
            cntKnots = 10;
            touchedPositions = MovingRope.touchedPositions(data, cntKnots);

            Console.WriteLine($"Der Schwanz nach {cntKnots} Knoten berührte {touchedPositions} Positionen.");
        }
    }
}