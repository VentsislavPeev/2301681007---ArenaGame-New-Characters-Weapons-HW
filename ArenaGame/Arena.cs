﻿using ArenaGame.Heroes;

namespace ArenaGame
{
    public class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;

            #region DecideWhoGoesFirst
            //Lighter weapon goes first.
            if (HeroA.HeroWeapon.Weight < HeroB.HeroWeapon.Weight)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else if(HeroB.HeroWeapon.Weight < HeroA.HeroWeapon.Weight)
            {
                attacker= HeroB;
                defender = HeroA;
            }
            else if(Random.Shared.Next(2) == 0)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }
            #endregion

            while (true)
            {
                int damage = attacker.Attack();
                defender.TakeDamage(damage);
                if (defender.IsDead) return attacker;
                //Swap the heroes
                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }
    }
}
