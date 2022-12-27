// (c) 2022 Ervin Peters (coder@ervnet.de)

using No._15;

using Xunit;

namespace No._15_Tests
{
    public class PositionTests
    {
        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(1, 1, 1, 2, 1)]
        [InlineData(1, 1, 2, 1, 1)]
        [InlineData(1, 1, 1, 3, 2)]
        [InlineData(1, 1, 3, 1, 2)]
        [InlineData(1, 1, 2, 2, 2)]
        public void checkDistance(long x1, long y1, long x2, long y2, long expected)
            => Assert.Equal(expected, new Position(x1, y1).manhattenDistance(new Position(x2, y2)));
    }
}