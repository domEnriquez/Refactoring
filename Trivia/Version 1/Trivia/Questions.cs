using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public abstract class Questions
    {
        protected LinkedList<string> items { get; set; }

        public Questions()
        {
            items = new LinkedList<string>();
        }

        public LinkedList<string> GetItems()
        {
            return items;
        }

        public abstract string GetName();
        public void AddMultipleItems(int count)
        {
            for (int i = 0; i < count; i++)
                AddItem(i);
        }
        public abstract void AddItem(int indexLabel);

        public abstract bool CurrentCategory(int v);
    }
}
