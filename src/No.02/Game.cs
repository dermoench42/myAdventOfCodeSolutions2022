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
            this.myChoice = this.choiceToFitResult(this.opponentChoice, wantedResultState[parts[1]]);
        }

        private Chosen choiceToFitResult(Chosen opponentChoice, WinState winState)
        {
            return winState switch
            {
                WinState.draw => opponentChoice,
                WinState.win => opponentChoice switch
                {
                    Chosen.Scissor => Chosen.Rock,
                    Chosen.Paper => Chosen.Scissor,
                    Chosen.Rock => Chosen.Paper
                },
                WinState.loose => opponentChoice switch
                {
                    Chosen.Scissor => Chosen.Paper,
                    Chosen.Paper => Chosen.Rock,
                    Chosen.Rock => Chosen.Scissor
                }
            };
        }

        public int result()
            => (int)this.myChoice + (int)this.didIWin();

        private WinState didIWin()
        {
            if (this.opponentChoice == this.myChoice)
                return WinState.draw;

            else if (this.myChoice == Chosen.Rock && this.opponentChoice == Chosen.Scissor
                || this.myChoice == Chosen.Scissor && this.opponentChoice == Chosen.Paper
                || this.myChoice == Chosen.Paper && this.opponentChoice == Chosen.Rock)
                return WinState.win;

            else
                return WinState.loose;

        }
    }
}