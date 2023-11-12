using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Strategies.Match
{
    public class BestOfFiveWinMatchStrategy : WinMatchStrategy
    {
        public override bool CheckWin(Player setWinner, Player opponent)
        {
            if (setWinner.Score.Sets == 3)
            {
                // Player wins.
                return true;
            }
            else
            {
                // The match continues.
                return false;
            }
        }
    }
}
