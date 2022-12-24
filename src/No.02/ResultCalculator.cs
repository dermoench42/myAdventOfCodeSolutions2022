// (c) 2022 Ervin Peters (coder@ervnet.de)

namespace No._2
{
    public static class ResultCalculator
    {
        public static int calc(string data,
                               Dictionary<string, Chosen> opponentsChoices,
                               Dictionary<string, Chosen> myChoices)
        {
            string[] rows = data.Split("\n");

            int result = rows.Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList()
                .ConvertAll(game => new Game(game, opponentsChoices, myChoices).result())
                .Sum();

            return result;
        }

        public static int calcpart2(string data,
                                    Dictionary<string, Chosen> opponentsChoices,
                                    Dictionary<string, WinState> wantedResultState)
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