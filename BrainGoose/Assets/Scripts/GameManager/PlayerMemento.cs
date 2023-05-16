using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager
{
    class PlayerMemento
    {
        private int GlobalScore;

        public PlayerMemento(int globalScore)
        {
            this.GlobalScore = globalScore;
        }

        public int GetScore()
        {
            return this.GlobalScore;
        }
    }
}