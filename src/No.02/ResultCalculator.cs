﻿// See https://aka.ms/new-console-template for more information

namespace No._2
{
    public class ResultCalculator
    {
        public int calc(string data, Dictionary<string, Chosen> opponentsChoices, Dictionary<string, Chosen> myChoices)
        {
            string[] rows = data.Split("\n");

            int result = rows.Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList()
                .ConvertAll(game => new Game(game, opponentsChoices, myChoices).result())
                .Sum();

            return result;
        }

        public int calcpart2(string data, Dictionary<string, Chosen> opponentsChoices, Dictionary<string, WinState> wantedResultState)
        {
            string[] rows = data.Split("\n");

            int result = rows.Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList()
                .ConvertAll(game => new Game(game, opponentsChoices, wantedResultState).result())
                .Sum();

            return result;
        }
    }
}