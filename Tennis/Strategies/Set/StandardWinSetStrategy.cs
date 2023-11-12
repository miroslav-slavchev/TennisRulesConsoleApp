using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Set
{
    public class StandardWinSetStrategy : WinSetStrategy
    {
        public override (bool CurrentPlayerWon, WinSetStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player currentScorringPlayer, Player opponent)
        {
            if (currentScorringPlayer.Score.Games == 6 && opponent.Score.Games < 5)
            {
                // Player wins the set
                return (true, this);
            }
            else if (currentScorringPlayer.Score.Games == 5 && opponent.Score.Games == 5)
            {
                // First Player to score 7 wins
                PrintInfoMessage("First Player to score 7 wins.");
                return (false, new WinSevenGamesStrategy());
            }
            else
            {
                // The set continues
                return (false, this);
            }
        }

    }
}
