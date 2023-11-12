using System.Drawing;
using System.Xml;
using Tennis.Strategies.Game;
using Tennis.Strategies.Match;
using Tennis.Strategies.Set;
using Tennis.Utils;

namespace Tennis
{
    public class ResultManager
    {
        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        private Player LastPointScorrer { get; set; }
        private Player LastGameWinner { get; set; }
        private Player LastSetWinner { get; set; }

        public ResultManager(Player player1, Player player2, WinMatchStrategy winMatchStrategy)
        {
            Player1 = player1;
            Player2 = player2;
            CurrentWinMatchStrategy = winMatchStrategy;
        }

        private WinGameStrategy CurrentWinGameStrategy { get; set; } = new StandardWinGameStrategy();

        private WinSetStrategy CurrentWinSetStrategy { get; set; } = new StandardWinSetStrategy();

        private WinMatchStrategy CurrentWinMatchStrategy { get; set; }


        public bool MatchEnded => Winner != null;

        public Player? Winner { get; private set; } = null;

        public void SetScoreToPlayer(int playerIndex)
        {
            var currentScorringPlayer = GetPlayerAndOponentByInex(playerIndex).Player;
            var opponent = GetPlayerAndOponentByInex(playerIndex).Opponent;

            PrintInfoMessage($"Point for {playerIndex}:{currentScorringPlayer.Name}.");

            currentScorringPlayer.Score.WinPoint();
            CheckResults(currentScorringPlayer, opponent);
            PrintCurrentScore();
            LastPointScorrer = currentScorringPlayer;
        }

        private void CheckResults(Player currentScorringPlayer, Player opponent)
        {
            CheckGameEnded(LastPointScorrer, currentScorringPlayer, opponent);
            CheckSetEnded(LastGameWinner, currentScorringPlayer, opponent);
            CheckMatchEnded(currentScorringPlayer, opponent);
        }

        private void CheckGameEnded(Player? lastScoringPlayer, Player currentScorringPlayer, Player opponent)
        {
            if (lastScoringPlayer != null)
            {
                //Check for game winner
                var (CurrentPlayerWon, NextStrategy) = CurrentWinGameStrategy.CheckWin(lastScoringPlayer, currentScorringPlayer, opponent);
                CurrentWinGameStrategy = NextStrategy;
                if (CurrentPlayerWon)
                {
                    currentScorringPlayer.Score.WinGame();
                    PrintInfoMessage($"{currentScorringPlayer.Name} Won the Game.");
                    LastGameWinner = currentScorringPlayer;
                    RestartPoints();
                }
            }
        }

        private void CheckSetEnded(Player? lastScoringPlayer, Player currentScorringPlayer, Player opponent)
        {
            if (lastScoringPlayer != null)
            {
                //Check for Set winner
                var (CurrentPlayerWon, NextStrategy) = CurrentWinSetStrategy.CheckWin(lastScoringPlayer, currentScorringPlayer, opponent);
                CurrentWinSetStrategy = NextStrategy;
                if (CurrentPlayerWon)
                {
                    currentScorringPlayer.Score.WinSet();
                    PrintInfoMessage($"{currentScorringPlayer.Name} Won the Set.");
                    LastSetWinner = currentScorringPlayer;
                    RestartGames();
                }
            }
        }

        private void CheckMatchEnded(Player currentScorringPlayer, Player opponent)
        {
            var win = CurrentWinMatchStrategy.CheckWin(currentScorringPlayer, opponent);
            if (win)
            {
                // The player wins the match
                Winner = currentScorringPlayer;
                PrintInfoMessage($"{currentScorringPlayer.Name} Won the Match.");
            }
            // Else the match continues
        }

        private void RestartPoints()
        {
            Player1.Score.RestartPoints();
            Player2.Score.RestartPoints();
        }

        private void RestartGames()
        {
            Player1.Score.RestartGames();
            Player2.Score.RestartGames();
        }

        private (Player Player, Player Opponent) GetPlayerAndOponentByInex(int index)
        {
            if (index == 1)
            {
                return (Player1, Player2);
            }
            else if (index == 2)
            {
                return (Player2, Player1);
            }
            else
            {
                throw new Exception("Invalid Player index.");
            }
        }

        private void PrintCurrentScore()
        {
            string message = $"Current Score is {Player1.Name} - Sets({Player1.Score.Sets}), Games({Player1.Score.Games}), Points({Player1.Score.Points}) : Points({Player2.Score.Points}), Games({Player2.Score.Games}), Sets({Player2.Score.Sets}) - {Player2.Name}"; 
            Logger.PrintLineHighLightedMessage(message);
        }

        private void PrintInfoMessage(string message) => Logger.PrintLineCyanTextMessage(message);
        
    }
}