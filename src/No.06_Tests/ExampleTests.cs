// (c) 2022 Ervin Peters (coder@ervnet.de)

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._06;

namespace No._06_Tests
{
    [TestClass]
    public class ExampleTests
    {
        [DataTestMethod]
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void check_examples2(string msg, int expectedPos)
            => Assert.AreEqual(expectedPos, StartOfPaketDetector.findStart(msg, 4));

        [DataTestMethod]
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void check_examples(string msg, int expectedPos)
            => Assert.AreEqual(expectedPos, StartOfPaketDetector.findStart(msg, 14));
    }
}