using No._11;

using Xunit;

namespace No._11_Tests
{
    public class PlayingMonkeyTests
    {
        [Theory]
        [InlineData("content.txt", 8)]
        [InlineData("testContent.txt", 4)]
        public void createMonkeys(string fileName, int countMonkeys)
        {
            MonkeyBusiness mb = new(fileName);
            Assert.Equal(countMonkeys, mb.monkeys.Count);
        }

        [Fact]
        public void checkFirstMonkey()
        {
            MonkeyBusiness mb = new("testContent.txt");
            Monkey m = mb.monkeys[0];
            Assert.Equal(2, m.worryLevelOfItems.Count);
            Assert.Equal("*", m.wOperator);
            Assert.Equal(19u, m.wOperand);
            Assert.Equal(2u, m.trueDestinationMonkeyId);
            Assert.Equal(3u, m.falseDestinationMonkeyId);
            Assert.Equal(23u, m.testDivisor);
        }

        [Theory]
        [InlineData(20, 3, 10605, "testContent.txt")]
        [InlineData(10000, 1, 2713310158, "testContent.txt")]
        [InlineData(20, 3, 110888, "content.txt")]
        public void checkTestDataResult(uint rounds, uint wDiv, uint expected, string fileName)
        {
            MonkeyBusiness mb = new(fileName);
            mb.play(rounds, wDiv);
            Assert.Equal(rounds, mb.round);
            Assert.Equal(expected, mb.level());
        }

        [Theory]
        [InlineData(1, 3, "20, 23, 27, 26", "2080, 25, 167, 207, 401, 1046")]
        [InlineData(2,3,"695, 10, 71, 135, 350","43, 49, 58, 55, 362")]
        [InlineData(3,3,"16, 18, 21, 20, 122","1468, 22, 150, 286, 739")]
        [InlineData(4,3,"491, 9, 52, 97, 248, 34","39, 45, 43, 258")]
        [InlineData(5,3,"15, 17, 16, 88, 1037","20, 110, 205, 524, 72")]
        [InlineData(6,3,"8, 70, 176, 26, 34","481, 32, 36, 186, 2190")]
        [InlineData(7,3,"162, 12, 14, 64, 732, 17","148, 372, 55, 72")]
        [InlineData(8,3,"51, 126, 20, 26, 136","343, 26, 30, 1546, 36")]
        [InlineData(9,3,"116, 10, 12, 517, 14","108, 267, 43, 55, 288")]
        [InlineData(10,3,"91, 16, 20, 98","481, 245, 22, 26, 1092, 30")]
        [InlineData(15,3,"83, 44, 8, 184, 9, 20, 26, 102","110, 36")]
        [InlineData(20, 3, "10, 12, 14, 26, 34", "245, 93, 53, 199, 115")]
        public void checkTestRound(uint rounds, uint wDiv, string m1, string m2)
        {
            MonkeyBusiness mb = new("testContent.txt");
            mb.play(rounds, wDiv);
            Assert.Equal(m1, string.Join(", ", mb.monkeys[0].worryLevelOfItems));
            Assert.Equal(m2, string.Join(", ", mb.monkeys[1].worryLevelOfItems));
        }

        [Theory]
        [InlineData(1, 1, "testContent.txt", "2, 4, 3, 6")]
        [InlineData(20, 1, "testContent.txt", "99, 97, 8, 103")]
        [InlineData(20, 3, "testContent.txt", "101, 95, 7, 105")]
        [InlineData(1000, 1, "testContent.txt", "5204, 4792, 199, 5192")]
        [InlineData(2000, 1, "testContent.txt", "10419, 9577, 392, 10391")]
        [InlineData(3000, 1, "testContent.txt", "15638, 14358, 587, 15593")]
        [InlineData(4000, 1, "testContent.txt", "20858, 19138, 780, 20797")]
        [InlineData(5000, 1, "testContent.txt", "26075, 23921, 974, 26000")]
        [InlineData(6000, 1, "testContent.txt", "31294, 28702, 1165, 31204")]
        [InlineData(7000, 1, "testContent.txt", "36508, 33488, 1360, 36400")]
        [InlineData(8000, 1, "testContent.txt", "41728, 38268, 1553, 41606")]
        [InlineData(9000, 1, "testContent.txt", "46945, 43051, 1746, 46807")]
        [InlineData(10000, 1, "testContent.txt", "52166, 47830, 1938, 52013")]
        public void checkInspectedItems(uint rounds, uint wDiv, string fileName, string expected)
        {
            MonkeyBusiness mb = new(fileName);
            mb.play(rounds, wDiv);
            Assert.Equal(expected, string.Join(", ", mb.monkeys.ConvertAll(monkey => monkey.cntInspected)));
        }
    }
}