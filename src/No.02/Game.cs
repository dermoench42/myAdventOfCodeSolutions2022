// See https://aka.ms/new-console-template for more information

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
        {
            return winState switch
            {
                WinState.draw => opponentChoice,
                WinState.win => whichWinsAgainst(opponentChoice),
                WinState.loose => whichLoosesAgainst(opponentChoice),
                _ => throw new NotImplementedException()
            };
        }

        private static Chosen whichLoosesAgainst(Chosen opponentChoice)
        {
            return opponentChoice switch
            {
                Chosen.Scissor => Chosen.Paper,
                Chosen.Paper => Chosen.Rock,
                Chosen.Rock => Chosen.Scissor,
                _ => throw new NotImplementedException()
            };
        }

        private static Chosen whichWinsAgainst(Chosen opponentChoice)
        {
            return opponentChoice switch
            {
                Chosen.Scissor => Chosen.Rock,
                Chosen.Paper => Chosen.Scissor,
                Chosen.Rock => Chosen.Paper,
                _ => throw new NotImplementedException()
            };
        }

        public int result()
            => (int) this.myChoice + (int) this.didIWin();

        private WinState didIWin()
        {
            return this.opponentChoice == this.myChoice
                ? WinState.draw
                : (this.myChoice == whichWinsAgainst(this.opponentChoice)) ? WinState.win : WinState.loose;
        }
    }
}