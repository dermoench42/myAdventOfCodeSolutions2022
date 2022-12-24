// See https://aka.ms/new-console-template for more information

using System;

using No._11;

MonkeyBusiness mb = new("content.txt");

mb.play(20, 3);

Console.WriteLine($"Monkey business level after round {mb.round} is {mb.level()}");

mb = new("content.txt");

mb.play(10000, 1);

Console.WriteLine($"Monkey business level after round {mb.round} is {mb.level()}");