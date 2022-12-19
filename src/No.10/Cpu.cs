// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace No._10
{
    public class Cpu
    {
        public List<CycleData> executionLog = new();

        public int run(List<string> instructions, List<int> evalCycles)
        {
            if (instructions?.Count == 0)
                return 0;

            int x = 1;
            int cycle = 1;
            int instructionCounter = 0;
            int leftInstructionCycles = 0;
            string opCode = "";
            string currentInstruction = "";
            while (instructionCounter < instructions!.Count)
            {
                if (leftInstructionCycles == 0)
                {
                    currentInstruction = instructions[instructionCounter];

                    opCode = currentInstruction[..4];

                    leftInstructionCycles = opCode switch
                    {
                        "noop" => 1,
                        "addx" => 2,
                        _ => throw new InvalidOperationException()
                    };
                }

                this.executionLog.Add(new CycleData() { cycle = cycle, opcode = opCode, X = x });

                cycle++;
                leftInstructionCycles--;

                if (leftInstructionCycles > 0)
                    continue;

                if (opCode == "addx")
                    x += Convert.ToInt32(currentInstruction[5..], CultureInfo.InvariantCulture);
                instructionCounter++;
            }

            this.executionLog.Add(new CycleData() { cycle = cycle, opcode = "end", X = x });

            return this.executionLog
                .Where(item => evalCycles.Contains(item.cycle))
                .Sum(item => item.cycle * item.X);
        }

        public Dictionary<int, int> partResults(List<int> evalCycles)
        {
            return new Dictionary<int, int>(this.executionLog
                .Where(item => evalCycles.Contains(item.cycle))
                .ToList()
                .ConvertAll(item => new KeyValuePair<int, int>(item.cycle, item.cycle * item.X))
            );
        }

        public string display()
        {
            StringBuilder msg = new();
            int rowLength = 40;
            int pos = 0;

            this.executionLog.ForEach(p =>
            {
                if (pos >= rowLength)
                {
                    _ = msg.AppendLine();
                    pos = 0;
                }

                _ = msg.Append(p.X - 1 <= pos && pos <= p.X + 1 ? '#' : '.');
                pos++;
            });

            return msg.ToString();
        }
    }
}