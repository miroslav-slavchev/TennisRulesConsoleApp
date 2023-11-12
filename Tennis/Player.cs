using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Player
    {
        public string Name {  get; set; }

        public Score Score { get; set; } = new();
      
    }
}
