using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Strategies.Game;

namespace Tennis.Strategies.Match
{
    public abstract class WinMatchStrategy
    {
        public abstract bool CheckWin(Player setWinner, Player opponent);
    }
}
