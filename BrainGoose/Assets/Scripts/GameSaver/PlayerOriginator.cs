using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaver
{
    class PlayerOriginator
    {
        public int points;

        public PlayerMemento Save()
        {
            return new PlayerMemento(points);
        }
        public void Restore(PlayerMemento memento)
        {
            this.points = memento.GetScore();
        }
    }
}
