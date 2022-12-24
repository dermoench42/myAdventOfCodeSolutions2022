// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace No._11
{
    public class MonkeyBusiness
    {
        public readonly List<Monkey> monkeys;
        public ulong round { get; private set; }

        public MonkeyBusiness(string monkeysFile)
        {
            this.monkeys = new List<Monkey>();
            string[] lines = File.ReadAllLines(monkeysFile);
            int lineNo = 0;
            while (lineNo < lines.Length)
            {
                if (lines[lineNo][0] == 'M')
                {
                    this.monkeys.Add(new Monkey(this.monkeys, lines.AsSpan(lineNo, 6)));
                    lineNo += 7;
                }
                else
                {
                    lineNo++;
                }
            }
        }

        public ulong level()
            => this.monkeys.ConvertAll(monkey => monkey.cntInspected)
                .OrderByDescending(m => m)
                .Take(2).Aggregate(1ul, (i, s) => i * s);

        public void play(ulong rounds, ulong wdiv)
        {
            while (rounds > 0)
            {
                this.monkeys.ForEach(monkey => monkey.play(wdiv));
                this.round++;
                rounds--;
            }
        }
    }
}