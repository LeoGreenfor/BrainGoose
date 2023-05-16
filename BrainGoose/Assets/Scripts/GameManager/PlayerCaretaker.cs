using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager
{
    public class PlayerCaretaker
    {
        private PlayerOriginator originator;
        private Stack<PlayerMemento> history;

        public void UpdateHistory()
        {
            PlayerMemento memento = originator.Save();
            history.Push(memento);
        }

        public void UndoSave()
        {
            PlayerMemento m = history.Pop();
            originator.Restore(m);
        }
    }

}