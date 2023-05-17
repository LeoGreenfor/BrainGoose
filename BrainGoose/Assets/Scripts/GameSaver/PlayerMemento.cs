using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaver
{
    class PlayerMemento
    {
        private int GlobalScore = 0;

        public PlayerMemento(int globalScore)
        {
            this.GlobalScore += globalScore;
        }

        public int GetScore()
        {
            return this.GlobalScore;
        }
    }
}