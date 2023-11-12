using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Set
{
    public class TieBreakWinSetStrategy : WinSetStrategy
    {
        public override (bool CurrentPlayerWon, WinSetStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player currentScorringPlayer, Player opponent)
        {
            bool twoGamesInARow = currentScorringPlayer== previousScorringPlayer;
            if (currentScorringPlayer.Score.Games >= 7 && twoGamesInARow)
            {
                // Player wins.
                return (true, new StandardWinSetStrategy());
            }
            else
            {
                // Set continues.
                return (false, this);
            }
        }
    }
}
