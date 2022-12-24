// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace No._11
{
    public class Monkey
    {
        private readonly List<Monkey> monkeys;
        public readonly ulong id;
        public readonly List<ulong> worryLevelOfItems;
        public string wOperator = "";
        public ulong wOperand;
        public ulong testDivisor;
        private ulong? productDivisors;
        public ulong cntInspected { get; private set; }

        public readonly ulong trueDestinationMonkeyId;
        private Monkey? trueDestinationMonkey;

        public readonly ulong falseDestinationMonkeyId;
        private Monkey? falseDestinationMonkey;


        public Monkey(List<Monkey> monkeys, Span<string> mData)
        {
            this.monkeys = monkeys;
            this.id = Convert.ToUInt64(mData[0].Split(' ')[1][..^1], CultureInfo.InvariantCulture);
            this.worryLevelOfItems = mData[1].Split(':')[1]
                .Split(',')
                .ToList()
                .ConvertAll(item => Convert.ToUInt64(item, CultureInfo.InvariantCulture));
            this.extractWorryLevelOperation(mData[2]);
            this.extractDivisorForTest(mData[3]);
            this.trueDestinationMonkeyId = extractMonkeyId(mData[4]);
            this.falseDestinationMonkeyId = extractMonkeyId(mData[5]);
        }

        private static ulong extractMonkeyId(string line)
            => Convert.ToUInt64(line.Split("monkey")[1].Trim(), CultureInfo.InvariantCulture);

        private void extractDivisorForTest(string line)
        {
            string[] testCondition = line.Split(':')[1]
                .Trim()
                .Split(' ');

            if (testCondition[1] != "by" || testCondition[0] != "divisible")
                throw new InvalidOperationException($"TestCondition evaluation failed: {line}");

            this.testDivisor = Convert.ToUInt64(testCondition[2], CultureInfo.InvariantCulture);
        }

        private void extractWorryLevelOperation(string line)
        {
            string[] operationParts = line.Split('=')[1]
                .Trim()
                .Split(' ');

            if (operationParts[0] != "old")
                throw new InvalidOperationException($"Operand failure {line}");

            this.wOperator = operationParts[1];

            if (operationParts[2] == "old")
                this.wOperator = "square";
            else
                this.wOperand = Convert.ToUInt64(operationParts[2], CultureInfo.InvariantCulture);
        }

        private Monkey? trueDestination()
            => this.trueDestinationMonkey
                ??= this.monkeys.FirstOrDefault(monkey => monkey.id == this.trueDestinationMonkeyId);

        private Monkey? falseDestination()
            => this.falseDestinationMonkey
                ??= this.monkeys.FirstOrDefault(monkey => monkey.id == this.falseDestinationMonkeyId);

        private ulong productOfDivisors()
            => this.productDivisors
                ??= this.monkeys
                    .Aggregate<Monkey, ulong>(1, (acc, m) => acc * m.testDivisor);

        public void play(ulong wdiv)
        {
            this.worryLevelOfItems.ForEach(item =>
            {
                //Console.Write($"    {item} ");
                item = this.worryLevelOperation(item, wdiv);

                Monkey destinationMonkey = (this.isDivisible(item)
                    ? this.trueDestination()
                    : this.falseDestination()) ?? throw new InvalidOperationException("destination");

                destinationMonkey
                    .worryLevelOfItems
                    .Add(item);

                //Console.WriteLine($"-> {item} ({item % this.testDivisor}) moved from {this.id} to {destinationMonkey.id}");

                this.cntInspected++;
            });

            this.worryLevelOfItems.Clear();
        }

        private bool isDivisible(ulong worryLevel)
            => worryLevel % this.testDivisor == 0;

        private ulong worryLevelOperation(ulong item, ulong worryDivisor)
        {
            ulong rawWl = this.wOperator switch
            {
                "*" => item * this.wOperand,
                "+" => item + this.wOperand,
                "square" => item * item,
                _ => throw new InvalidOperationException($"Operator: {this.wOperator}")
            };

            if (worryDivisor != 1)
                return rawWl / worryDivisor;
            return rawWl % this.productOfDivisors();
        }

        public string itemsAsString()
            => string.Join(", ", this.worryLevelOfItems);
    }
}