using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagicalDuelChallenge
{
    internal class Player
    {
        public int Hp;
        public int Maxhp;
        public int Energy;
        public int MaxEnergy;
        public int Armor;
        public string name;
        Stat skillStatistics = new Stat();  

        public Player(string name, int hp,int energy,int armor)
        {
            Hp = hp;
            Energy = energy;
            Armor = armor;
            this.name = name;
        }

        public bool setHealth(int hp)
        {
            if (hp < Maxhp && hp >= 0)
            {
                Hp = hp;
                return true;
            }
            return false;

        }

        public bool setEnergy(int energy)
        {
            if (energy < MaxEnergy && energy >= 0)
            {
                Energy = energy;
                return true;
            }
            return false;

        }
        public bool setArmor(int armor)
        {
            if(armor>=0)
            {
                Armor=armor;
                return true;
            }
            return false;
        }

        public void changeName(string name)
        {
            this.name = name;
        }

        public void learnSkill(Stat stats)
        { this.skillStatistics = stats; }

        public string Attack(Player target)
        {

            
            if (skillStatistics.cost < Energy)
            {
                int penetrate = skillStatistics.penetration;
                int effectiveArmor = target.Armor - penetrate;
                target.Armor = effectiveArmor;
                Energy -= skillStatistics.cost;
                double damageMultiplier = (100.0 - effectiveArmor) / 100.0;
                int damage = (int)(skillStatistics.damage * damageMultiplier);
                target.Hp -= damage;

                string attackString = $"{name} used skill {skillStatistics.name}, {skillStatistics.description}, against {target.name}, doing {damage} damage!";

                if (skillStatistics.heal != 0)
                {
                    Hp += skillStatistics.heal;
                    attackString += $" {name} healed for {skillStatistics.heal} health.";
                }

                if (target.Hp <= 0)
                {
                    attackString += $" {target.name} died.";
                }
                else
                {
                    int targetHpPercentage = (target.Hp);
                    attackString += $" {target.name} is at {targetHpPercentage}% health.";

                }

                return attackString;

            }
            else
            {
                return $"{name} attempted to use {skillStatistics.name}, but didn't have enough energy!";
            }
        }


    }
}
