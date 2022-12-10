// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace No._05
{
    public class ChargeStacks
    {
        private readonly Dictionary<int, Stack<char>> crateStacks = new();

        public ChargeStacks(string stackDefs)
        {
            // Struktur Annahmen:
            // - weniger als 10 Stapel
            // - fixe Positionen der Kistendefinitionen in den Zeilen

            List<string> rows = stackDefs.Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList();

            int cntCrateStacks = this.createCrateStacks(rows);

            for (int rowIdx = cntCrateStacks - 1; rowIdx >= 0; rowIdx--)
            {
                for (int stackIdx = 1; stackIdx <= cntCrateStacks; stackIdx++)
                {
                    int rowPos = 1 + 4 * (stackIdx - 1);
                    if (rowPos >= rows[rowIdx].Length)
                        break;
                    if (rows[rowIdx][rowPos] != ' ')
                        this.crateStacks[stackIdx].Push(rows[rowIdx][rowPos]);
                }
            }
        }

        private int createCrateStacks(List<string> rows)
        {
            int lastrowIdx = rows.Count - 1;

            rows[lastrowIdx].Trim()
                .Split("   ")
                .ToList()
                .ForEach(col =>
                {
                    int idx = Convert.ToInt32(col.Trim(), CultureInfo.CurrentCulture);
                    this.crateStacks[idx] = new Stack<char>();
                });

            return this.crateStacks.Count;
        }

        public string cratesOnTop()
        {
            string result = "";
            for (int crateIdx = 1; crateIdx <= this.crateStacks.Count; crateIdx++)
            {
                result += this.crateStacks[crateIdx].Peek();
            }

            return result;
        }

        public ChargeStacks applyActions(string actionDefs, int part)
        {
            actionDefs.Split("\n")
                .Where(row => !string.IsNullOrWhiteSpace(row))
                .ToList()
                .ForEach(row =>
                {
                    string[] words = row.Trim().Split(" ");

                    if (words[0] != "move")
                        throw new InvalidExpressionException($"action move expected, {words[0]} found!");

                    if (part == 0)
                        this.move(Convert.ToInt32(words[1], CultureInfo.CurrentCulture),
                            Convert.ToInt32(words[3], CultureInfo.CurrentCulture),
                            Convert.ToInt32(words[5], CultureInfo.CurrentCulture));
                    else
                        this.move2(Convert.ToInt32(words[1], CultureInfo.CurrentCulture),
                            Convert.ToInt32(words[3], CultureInfo.CurrentCulture),
                            Convert.ToInt32(words[5], CultureInfo.CurrentCulture));
                });
            return this;
        }

        private void move(int cntCrates, int fromStackIdx, int toStackIdx)
        {
            while (cntCrates-- > 0)
            {
                this.crateStacks[toStackIdx].Push(this.crateStacks[fromStackIdx].Pop());
            }
        }

        private void move2(int cntCrates, int fromStackIdx, int toStackIdx)
        {
            char[] buffer = new char[cntCrates];
            int idx = 0;
            while (idx < cntCrates)
            {
                buffer[idx++] = this.crateStacks[fromStackIdx].Pop();
            }
            while (--cntCrates >= 0)
            {
                this.crateStacks[toStackIdx].Push(buffer[cntCrates]);
            }
        }
    }
}