// (c) 2022 Ervin Peters (coder@ervnet.de)

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._2;

namespace No._02_Tests
{
    [TestClass]
    public class ResultCalculatorTest
    {
        readonly Dictionary<string, Chosen> opponentsChoices = new()
        {
            { "A", Chosen.Rock }, { "B", Chosen.Paper }, { "C", Chosen.Scissor }
        };

        readonly Dictionary<string, Chosen> myChoices = new()
        {
            { "X", Chosen.Rock }, { "Y", Chosen.Paper }, { "Z", Chosen.Scissor }
        };

        readonly Dictionary<string, WinState> wantedResultState =
            new() { { "X", WinState.Loose }, { "Y", WinState.Draw }, { "Z", WinState.Win } };

        [TestMethod]
        public void returns_zero_onEmptyData()
        {
            int result = ResultCalculator.calc("", this.opponentsChoices, this.myChoices);

            Assert.AreEqual(0, result);
        }

        [DataTestMethod]
        [DataRow("A Y", 8)]
        [DataRow("B X", 1)]
        [DataRow("C Z", 6)]
        public void returns_result_of_single_game(string data, int expected)
        {
            int result = ResultCalculator.calc(data, this.opponentsChoices, this.myChoices);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("A Y", 4)]
        [DataRow("B X", 1)]
        [DataRow("C Z", 7)]
        public void part2_returns_result_of_single_game(string data, int expected)
        {
            int result = ResultCalculator.calcpart2(data, this.opponentsChoices, this.wantedResultState);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void return_exampleDataResult()
        {
            string data = @"
                A Y
                B X
                C Z
            ";

            int expected = 15;

            int result = ResultCalculator.calc(data, this.opponentsChoices, this.myChoices);

            Assert.AreEqual(expected, result);
        }
    }
}