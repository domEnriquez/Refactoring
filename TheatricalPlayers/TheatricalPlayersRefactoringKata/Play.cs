using System;
using TheatricalPlayersRefactoringKata.PlayImplementations;

namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        private string name;

        public string Name { get => name; set => name = value; }

        protected Play(string name)
        {
            this.name = name;
        }

        public static Play Create(string name, string type)
        {
            if (type == "tragedy")
                return new TragedyPlay(name);
            else if (type == "comedy")
                return new ComedyPlay(name);
            else
                throw new Exception("unknown type: " + type);
        }

        public abstract int Cost(int audience);

        public abstract int VolumeCredits(int audience);
    }
}
