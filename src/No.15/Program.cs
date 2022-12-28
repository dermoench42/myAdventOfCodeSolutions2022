// (c) 2022 Ervin Peters (coder@ervnet.de)
// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Linq;

using No._15;

Area area = new(File.ReadLines("testSensorData.txt").ToList());

long cntPositions = area.cntPositionsWithNoBeacon(10);

Console.WriteLine($"testData: {cntPositions} (26)");

area = new(File.ReadLines("sensorData.txt").ToList());

cntPositions = area.cntPositionsWithNoBeacon(2000000);

Console.WriteLine($"Part1: {cntPositions}");