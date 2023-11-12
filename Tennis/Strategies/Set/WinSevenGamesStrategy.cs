namespace Tennis.Strategies.Set
{
    public class WinSevenGamesStrategy : WinSetStrategy
    {
   

        public override (bool CurrentPlayerWon, WinSetStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player currentScorringPlayer, Player opponent)
        {
            if (currentScorringPlayer.Score.Games == 7 && opponent.Score.Games < 7)
            {
                //Player wins
                return (true, new StandardWinSetStrategy());
            }
            else if (currentScorringPlayer.Score.Games == 6 && opponent.Score.Games == 6)
            {
                // TieBreak
                PrintInfoMessage("TieBreak.");
                currentScorringPlayer.Score.RestartGames();
                opponent.Score.RestartGames();
                return (false, new TieBreakWinSetStrategy());
            }
            else
            {
                //The set continues
                return (false, this);
            }
        }
    }
}
