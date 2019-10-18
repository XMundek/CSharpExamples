using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormGame
{
    partial class GameResults
    {
        public override string ToString()
        {
            return $"{Player}:{Score}";
        }
    }
}
