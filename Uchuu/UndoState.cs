using System;
using System.Collections.Generic;

namespace Hakase.Uchuu
{
    public class UndoState
    {
        private Stack<TileChange> changes;

        public Stack<TileChange> Changes
        {
            get
            {
                return changes;
            }
        }

        public UndoState()
        {
            changes = new Stack<TileChange>();
        }
    }
}
