// (c) 2022 QSOFT Development

using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using No._09;

namespace No._09_Tests
{
    [TestClass]
    public class RopeTests
    {
        [DataTestMethod]
        [DataRow("testContent.txt", 13)]
        [DataRow("circle.txt", 1)]
        [DataRow("circle2.txt", 1)]
        [DataRow("step0.txt", 1)]
        [DataRow("bigCircle.txt", 13)]
        public void calcTouchedPositions(string fn, int expected)
        {
            List<string> data = File.ReadAllText(fn)
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            int touchedPositions = MovingRope.touchedPositions(data);

            Assert.AreEqual(expected, touchedPositions);
        }

        [DataTestMethod]
        [DataRow("L 1", 1)]
        [DataRow("L 2", 2)]
        [DataRow("L 3", 3)]
        [DataRow("R 1", 1)]
        [DataRow("R 2", 2)]
        [DataRow("R 3", 3)]
        [DataRow("D 1", 1)]
        [DataRow("D 2", 2)]
        [DataRow("D 3", 3)]
        [DataRow("U 1", 1)]
        [DataRow("U 2", 2)]
        [DataRow("U 3", 3)]
        public void calcTouchedPositionsOfSingleMove(string move, int expected)
        {
            List<string> data = new() { move };

            int touchedPositions = MovingRope.touchedPositions(data);

            Assert.AreEqual(expected, touchedPositions);
        }

        [DataTestMethod]
        [DataRow("L 1", "U 1", 1)]
        [DataRow("L 1", "D 1", 1)]
        [DataRow("R 1", "U 1", 1)]
        [DataRow("R 1", "D 1", 1)]
        [DataRow("U 1", "L 1", 1)]
        [DataRow("U 1", "R 1", 1)]
        [DataRow("D 1", "L 1", 1)]
        [DataRow("D 1", "R 1", 1)]
        [DataRow("L 2", "U 1", 2)]
        [DataRow("L 2", "D 1", 2)]
        [DataRow("R 2", "U 1", 2)]
        [DataRow("R 2", "D 1", 2)]
        [DataRow("U 2", "L 1", 2)]
        [DataRow("U 2", "R 1", 2)]
        [DataRow("D 2", "L 1", 2)]
        [DataRow("D 2", "R 1", 2)]
        [DataRow("L 1", "U 2", 2)]
        [DataRow("L 1", "D 2", 2)]
        [DataRow("R 1", "U 2", 2)]
        [DataRow("R 1", "D 2", 2)]
        [DataRow("U 1", "L 2", 2)]
        [DataRow("U 1", "R 2", 2)]
        [DataRow("D 1", "L 2", 2)]
        [DataRow("D 1", "R 2", 2)]
        [DataRow("L 3", "U 1", 3)]
        [DataRow("L 3", "D 1", 3)]
        [DataRow("R 3", "U 1", 3)]
        [DataRow("R 3", "D 1", 3)]
        [DataRow("U 3", "L 1", 3)]
        [DataRow("U 3", "R 1", 3)]
        [DataRow("D 3", "L 1", 3)]
        [DataRow("D 3", "R 1", 3)]
        [DataRow("L 3", "U 3", 5)]
        [DataRow("L 3", "D 3", 5)]
        [DataRow("R 3", "U 3", 5)]
        [DataRow("R 3", "D 3", 5)]
        [DataRow("U 3", "L 3", 5)]
        [DataRow("U 3", "R 3", 5)]
        [DataRow("D 3", "L 3", 5)]
        [DataRow("D 3", "R 3", 5)]
        public void calcTouchedPositionsOfDoubleMove(string move, string move1, int expected)
        {
            List<string> data = new() { move, move1 };

            int touchedPositions = MovingRope.touchedPositions(data);

            Assert.AreEqual(expected, touchedPositions);
        }
    }
}