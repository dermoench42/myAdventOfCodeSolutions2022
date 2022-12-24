// (c) 2022 Ervin Peters (coder@ervnet.de)

namespace No._2
{
    internal static class Program
    {
        private static void Main()
        {
            string data = File.ReadAllText("input");

            Dictionary<string, Chosen> opponentsChoices = new()
            {
                { "A", Chosen.Rock },
                { "B", Chosen.Paper },
                { "C", Chosen.Scissor }
            };

            Dictionary<string, Chosen> myChoices = new()
            {
                { "X", Chosen.Rock },
                { "Y", Chosen.Paper },
                { "Z", Chosen.Scissor }
            };

            Console.WriteLine($"result: {ResultCalculator.calc(data, opponentsChoices, myChoices)}");

            // part2

            Dictionary<string, WinState> wantedResultState = new() {
                { "X", WinState.Loose },
                { "Y", WinState.Draw },
                { "Z", WinState.Win }
            };

            Console.WriteLine($"result Part2: {ResultCalculator.calcpart2(data, opponentsChoices, wantedResultState)}");
        }
    }
}