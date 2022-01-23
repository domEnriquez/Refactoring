namespace Game
{
    public class Character
    {
        public int ArmorClass { get; internal set; }
        public int DamageDealt { get; internal set; }
        public string Race { get; internal set; }
        public int Force { get; internal set; }

        public Character(int armorClass, int damageDealt, string race, int force)
        {
            ArmorClass = armorClass;
            DamageDealt = damageDealt;
            Race = race;
            Force = force;
        }
    }
}