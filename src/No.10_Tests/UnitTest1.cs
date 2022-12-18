using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using No._10;

using Xunit;

namespace No._10_Tests
{
    public class SignalStrengthTesting
    {
        [Fact]
        public void Register_values()
        {
            List<string> data = File.ReadAllText("smallTestProgram.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            Dictionary<int, int> expected = new()
            {
                { 1, 1 },
                { 2, 1 },
                { 3, 1 },
                { 4, 4 },
                { 5, 4 },
                { 6, -1 }
            };

            Cpu cpu = new(true);

            cpu.run(data, expected.Keys.ToList());

            List<CycleData> cycleData = cpu.executionLog;

            foreach (int key in expected.Keys)
            {
                CycleData? result = cycleData.Where(d => d.cycle == key).FirstOrDefault();
                Assert.NotNull(result);
                Assert.Equal(expected[key], result!.X);
            }
        }

        [Fact]
        public void Strengths_of_Testfile()
        {
            List<string> data = File.ReadAllText("testProgramm.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            Dictionary<int, int> expected = new()
            {
                { 20, 420 },
                { 60, 1140 },
                { 100, 1800 },
                { 140, 2940 },
                { 180, 2880 },
                { 220, 3960 }
            };

            const int EXPECTED_SUM = 13140;

            Cpu cpu = new();

            int result = cpu.run(data, expected.Keys.ToList());

            Dictionary<int, int> partResults = cpu.partResults(expected.Keys.ToList());

            foreach (int key in expected.Keys)
            {
                Assert.Equal(expected[key], partResults[key]);
            }

            Assert.Equal(EXPECTED_SUM, result);
        }

        [Fact]
        public void testDisplay()
        {
            List<string> data = File.ReadAllText("testProgramm.txt")
                .Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            Dictionary<int, int> expected = new()
            {
                { 20, 420 },
                { 60, 1140 },
                { 100, 1800 },
                { 140, 2940 },
                { 180, 2880 },
                { 220, 3960 }
            };

            const int EXPECTED_SUM = 13140;

            Cpu cpu = new();

            int result = cpu.run(data, expected.Keys.ToList());

            Dictionary<int, int> partResults = cpu.partResults(expected.Keys.ToList());

            foreach (int key in expected.Keys)
            {
                Assert.Equal(expected[key], partResults[key]);
            }

            Assert.Equal(EXPECTED_SUM, result);

            string d = @"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
.";

            Assert.Equal(d.Replace("\r\n","\n"), cpu.display());
        }
    }
}