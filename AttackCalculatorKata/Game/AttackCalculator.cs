using System;

namespace Game
{
    public class AttackCalculator
    {
        Random random = new Random();

        public int CalculateDamage(Character atk, Character def)
        {
            int dice = DiceRoll();

            if (atk.Force + dice > def.ArmorClass)
            {
                if (dice == 1)
                    return 0;

                if (dice == 20)
                    return atk.DamageDealt * 2;

                return atk.DamageDealt;
            }
            else
                return 0;
        }

        public virtual int DiceRoll()
        {
            return random.Next(1, 20);
        }
    }
}
