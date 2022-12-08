using No._2;

namespace No._02_Tests
{
    [TestClass]
    public class ResultCalculatorTest
    {
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

        Dictionary<string, WinState> wantedResultState = new Dictionary<string, WinState>() {
                { "X", WinState.loose },
                { "Y", WinState.draw },
                { "Z", WinState.win }
            };

        [TestMethod]
        public void returns_zero_onEmptyData()
        {
            ResultCalculator calc = new();

            int result = calc.calc("", opponentsChoices, myChoices);

            Assert.AreEqual(0, result);
        }

        [DataTestMethod]
        [DataRow("A Y", 8)]
        [DataRow("B X", 1)]
        [DataRow("C Z", 6)]
        public void returns_result_of_single_game(string data, int expected)
        {
            ResultCalculator calc = new();

            int result = calc.calc(data, opponentsChoices, myChoices);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("A Y", 4)]
        [DataRow("B X", 1)]
        [DataRow("C Z", 7)]
        public void part2_returns_result_of_single_game(string data, int expected)
        {
            ResultCalculator calc = new();

            int result = calc.calcpart2(data, opponentsChoices, wantedResultState);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void return_exampleDataResult()
        {
            ResultCalculator calc = new();

            string data = @"
                A Y
                B X
                C Z
            ";

            int expected = 15;

            int result = calc.calc(data, opponentsChoices, myChoices);

            Assert.AreEqual(expected, result);
        }
    }
}