using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Set
{
    public class WinSetWithTwoGamesInARowStrategy : WinSetStrategy
    {
        public override (bool CurrentPlayerWon, WinSetStrategy NextStrategy) CheckWin(Player? previousScorringPlayer, Player currentScorringPlayer, Player opponent)
        {
            if (currentScorringPlayer == previousScorringPlayer && previousScorringPlayer.Score.Games - opponent.Score.Games == 2)
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
