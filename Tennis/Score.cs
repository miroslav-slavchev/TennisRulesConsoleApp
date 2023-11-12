using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Score
    {
        public int Sets { get; private set; } = 0;

        public int Games { get; private set; } = 0;

        public int Points { get; private set; } = 0;


        public void WinPoint()
        {
            Points++;
        }

        public void WinGame()
        {
            Games++;
        }

        public void WinSet()
        {
            Sets++;
        }

        public void RestartPoints()
        {
            Points = 0;
        }

        public void RestartGames()
        {
            Games = 0;
        }
    }
}
