﻿// (c) 2022 Ervin Peters (coder@ervnet.de)

namespace No._2
{
    internal class Game
    {
        private readonly Chosen opponentChoice;
        private readonly Chosen myChoice;

        public Game(string data, Dictionary<string, Chosen> opponentsChoices, Dictionary<string, Chosen> myChoices)
        {
            string[] parts = data.Trim().Split(" ");
            this.opponentChoice = opponentsChoices[parts[0]];
            this.myChoice = myChoices[parts[1]];
        }

        public Game(string data, Dictionary<string, Chosen> opponentsChoices, Dictionary<string, WinState> wantedResultState)
        {
            string[] parts = data.Trim().Split(" ");
            this.opponentChoice = opponentsChoices[parts[0]];
            this.myChoice = choiceToFitResult(this.opponentChoice, wantedResultState[parts[1]]);
        }

        private static Chosen choiceToFitResult(Chosen opponentChoice, WinState winState)
            => winState switch
            {
                WinState.Draw => opponentChoice,
                WinState.Win => whichWinsAgainst(opponentChoice),
                WinState.Loose => whichLoosesAgainst(opponentChoice),
                _ => throw new ArgumentOutOfRangeException(nameof(winState), winState, null)
            };

        private static Chosen whichLoosesAgainst(Chosen opponentChoice)
            => opponentChoice switch
            {
                Chosen.Scissor => Chosen.Paper,
                Chosen.Paper => Chosen.Rock,
                Chosen.Rock => Chosen.Scissor,
                _ => throw new ArgumentOutOfRangeException(nameof(opponentChoice), opponentChoice, null)
            };

        private static Chosen whichWinsAgainst(Chosen opponentChoice)
            => opponentChoice switch
            {
                Chosen.Scissor => Chosen.Rock,
                Chosen.Paper => Chosen.Scissor,
                Chosen.Rock => Chosen.Paper,
                _ => throw new ArgumentOutOfRangeException(nameof(opponentChoice), opponentChoice, null)
            };

        public int result()
            => (int) this.myChoice + (int) this.didIWin();

        private WinState didIWin() =>
            this.opponentChoice == this.myChoice
                ? WinState.Draw
                : (this.myChoice == whichWinsAgainst(this.opponentChoice)) ? WinState.Win : WinState.Loose;
    }
}