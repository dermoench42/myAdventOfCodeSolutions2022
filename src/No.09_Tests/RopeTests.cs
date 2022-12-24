// (c) 2022 Ervin Peters (coder@ervnet.de)

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
        [DataRow("content.txt", 2, 6018)]
        [DataRow("content.txt", 10, 2619)]
        [DataRow("testContent.txt", 2, 13)]
        [DataRow("testContent.txt", 3, 7)]
        [DataRow("testContent.txt", 4, 4)]
        [DataRow("testContent.txt", 5, 3)]
        [DataRow("testContent.txt", 6, 2)]
        [DataRow("testContent.txt", 7, 1)]
        [DataRow("testContent.txt", 8, 1)]
        [DataRow("testContent.txt", 9, 1)]
        [DataRow("testContent.txt", 10, 1)]
        [DataRow("testContent1.txt", 10, 36)]
        [DataRow("circle.txt", 2, 1)]
        [DataRow("circle2.txt", 2, 1)]
        [DataRow("step0.txt", 2, 1)]
        [DataRow("bigCircle.txt", 2, 13)]
        [DataRow("bigCircle.txt", 3, 8)]
        [DataRow("bigCircle.txt", 4, 4)]
        [DataRow("bigCircle.txt", 5, 1)]
        [DataRow("bigCircleStepwise.txt", 2, 13)]
        [DataRow("bigCircleStepwise.txt", 3, 8)]
        [DataRow("bigCircleStepwise.txt", 4, 4)]
        [DataRow("bigCircleStepwise.txt", 5, 1)]
        [DataRow("circle.txt", 2, 1)]
        [DataRow("circle2.txt", 2, 1)]
        public void calcTouchedPositions(string fn, int cntKnots, int expected)
        {
            List<string> data = File.ReadAllText(fn)
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            int touchedPositions = MovingRope.touchedPositions(data, cntKnots);

            Assert.AreEqual(expected, touchedPositions);
        }

        [DataTestMethod]
        [DataRow("L 1", 2, 1)]
        [DataRow("L 2", 2, 2)]
        [DataRow("L 3", 2, 3)]
        [DataRow("R 1", 2, 1)]
        [DataRow("R 2", 2, 2)]
        [DataRow("R 3", 2, 3)]
        [DataRow("D 1", 2, 1)]
        [DataRow("D 2", 2, 2)]
        [DataRow("D 3", 2, 3)]
        [DataRow("U 1", 2, 1)]
        [DataRow("U 2", 2, 2)]
        [DataRow("U 3", 2, 3)]
        [DataRow("L 1", 3, 1)]
        [DataRow("L 2", 3, 1)]
        [DataRow("L 3", 3, 2)]
        [DataRow("R 1", 3, 1)]
        [DataRow("R 2", 3, 1)]
        [DataRow("R 3", 3, 2)]
        [DataRow("D 1", 3, 1)]
        [DataRow("D 2", 3, 1)]
        [DataRow("D 3", 3, 2)]
        [DataRow("U 1", 3, 1)]
        [DataRow("U 2", 3, 1)]
        [DataRow("U 3", 3, 2)]
        [DataRow("L 1", 4, 1)]
        [DataRow("L 2", 4, 1)]
        [DataRow("L 3", 4, 1)]
        [DataRow("R 1", 4, 1)]
        [DataRow("R 2", 4, 1)]
        [DataRow("R 3", 4, 1)]
        [DataRow("D 1", 4, 1)]
        [DataRow("D 2", 4, 1)]
        [DataRow("D 3", 4, 1)]
        [DataRow("U 1", 4, 1)]
        [DataRow("U 2", 4, 1)]
        [DataRow("U 3", 4, 1)]
        public void calcTouchedPositionsOfSingleMove(string move, int cntKnots, int expected)
        {
            List<string> data = new() { move };

            int touchedPositions = MovingRope.touchedPositions(data, cntKnots);

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

            int touchedPositions = MovingRope.touchedPositions(data, 2);

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
        [DataRow("L 2", "U 1", 1)]
        [DataRow("L 2", "D 1", 1)]
        [DataRow("R 2", "U 1", 1)]
        [DataRow("R 2", "D 1", 1)]
        [DataRow("U 2", "L 1", 1)]
        [DataRow("U 2", "R 1", 1)]
        [DataRow("D 2", "L 1", 1)]
        [DataRow("D 2", "R 1", 1)]
        [DataRow("L 1", "U 2", 1)]
        [DataRow("L 1", "D 2", 1)]
        [DataRow("R 1", "U 2", 1)]
        [DataRow("R 1", "D 2", 1)]
        [DataRow("U 1", "L 2", 1)]
        [DataRow("U 1", "R 2", 1)]
        [DataRow("D 1", "L 2", 1)]
        [DataRow("D 1", "R 2", 1)]
        [DataRow("L 3", "U 1", 2)]
        [DataRow("L 3", "D 1", 2)]
        [DataRow("R 3", "U 1", 2)]
        [DataRow("R 3", "D 1", 2)]
        [DataRow("U 3", "L 1", 2)]
        [DataRow("U 3", "R 1", 2)]
        [DataRow("D 3", "L 1", 2)]
        [DataRow("D 3", "R 1", 2)]
        [DataRow("L 3", "U 3", 3)]
        [DataRow("L 3", "D 3", 3)]
        [DataRow("R 3", "U 3", 3)]
        [DataRow("R 3", "D 3", 3)]
        [DataRow("U 3", "L 3", 3)]
        [DataRow("U 3", "R 3", 3)]
        [DataRow("D 3", "L 3", 3)]
        [DataRow("D 3", "R 3", 3)]
        public void calcTouchedPositionsOfDoubleMove3(string move, string move1, int expected)
        {
            List<string> data = new() { move, move1 };

            int touchedPositions = MovingRope.touchedPositions(data, 3);

            Assert.AreEqual(expected, touchedPositions);
        }
    }
}