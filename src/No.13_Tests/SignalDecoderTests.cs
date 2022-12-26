using System.IO;

using No._13;

using Xunit;

namespace No._13_Tests
{
    public class SignalDecoderTests
    {
        [Fact]
        public void testEndresult()
        {
            string data = File.ReadAllText("testData.txt");

            int cntRightOrderedPairs = SignalDecoder.countRightOrderOfPairs(data);

            Assert.Equal(13, cntRightOrderedPairs);
        }

        [Theory]
        [InlineData("[]", "[2]", CompareResults.IsGreater)]
        [InlineData("[]", "[]", CompareResults.IsEqual)]
        [InlineData("[[]]", "[[2]]", CompareResults.IsGreater)]
        [InlineData("[1]", "[2]", CompareResults.IsGreater)]
        [InlineData("[1]", "[]", CompareResults.IsLower)]
        [InlineData("[[1]]", "[[]]", CompareResults.IsLower)]
        [InlineData("[2]", "[2]", CompareResults.IsEqual)]
        [InlineData("[[2]]", "[[2]]", CompareResults.IsEqual)]
        [InlineData("[1]", "[[2]]", CompareResults.IsGreater)]
        [InlineData("[2]", "[[1]]", CompareResults.IsLower)]
        [InlineData("[[1]]", "[2]", CompareResults.IsGreater)]
        [InlineData("[[2]]", "[1]", CompareResults.IsLower)]
        [InlineData("[1]", "[[2,0,0]]", CompareResults.IsGreater)]
        [InlineData("[2]", "[[1,0,0]]", CompareResults.IsLower)]
        [InlineData("[[1,0,0]]", "[2]", CompareResults.IsGreater)]
        [InlineData("[[2,0,0]]", "[1]", CompareResults.IsLower)]
        // example
        [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", CompareResults.IsGreater)]
        [InlineData("[[1],[2,3,4]]", "[[1],4]", CompareResults.IsGreater)]
        [InlineData("[9]", "[[8,7,6]]", CompareResults.IsLower)]
        [InlineData("[[4,4],4,4]", "[[4,4],4,4,4]", CompareResults.IsGreater)]
        [InlineData("[7,7,7,7]", "[7,7,7]", CompareResults.IsLower)]
        [InlineData("[]", "[3]", CompareResults.IsGreater)]
        [InlineData("[[[]]]", "[[]]", CompareResults.IsLower)]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", CompareResults.IsLower)]
        public void testPairs(string leftData, string rightData, CompareResults expected)
        {
            ListFragment left = new(leftData);
            ListFragment right = new(rightData);

            Assert.Equal(expected, left.compare(right));
        }

        [Fact]
        public void testEndresultPart2()
        {
            string data = File.ReadAllText("testData.txt");

            int cntRightOrderedPairs = SignalDecoder.sortedInputResult(data);

            Assert.Equal(140, cntRightOrderedPairs);
        }
    }
}