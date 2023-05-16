using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaver
{
    class PlayerOriginator
    {
        private int points = 0;

        public PlayerOriginator(int addPoints)
        {
            this.points += addPoints;
        }

        public PlayerMemento Save()
        {
            return new PlayerMemento(points);
        }
        public void Restore(PlayerMemento memento)
        {
            this.points = memento.GetScore();
        }
        public int GetPoints()
        {
            return points;
        }
    }
}
