// See https://aka.ms/new-console-template for more information

namespace No._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ResultCalculator calculator = new();

            string data = File.ReadAllText("input");

            Dictionary<string, Chosen> opponentsChoices = new Dictionary<string, Chosen>()
            {
                { "A", Chosen.Rock },
                { "B", Chosen.Paper },
                { "C", Chosen.Scissor }
            };

            Dictionary<string, Chosen> myChoices = new Dictionary<string, Chosen>()
            {
                { "X", Chosen.Rock },
                { "Y", Chosen.Paper },
                { "Z", Chosen.Scissor }
            };

            Console.WriteLine($"result: {calculator.calc(data, opponentsChoices, myChoices)}");

            // part2

            Dictionary<string, WinState> wantedResultState = new Dictionary<string, WinState>() {
                { "X", WinState.loose },
                { "Y", WinState.draw },
                { "Z", WinState.win }
            };

            Console.WriteLine($"result Part2: {calculator.calcpart2(data,opponentsChoices,wantedResultState)}");
        }
    }
}