using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlayMagicDuel
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

        public Player(string name, int hp,int maxHealth,  int energy, int maxEnergy, int armor)
        {
           this.name = name;
            this.Hp = hp;
            this.Maxhp = maxHealth;
            this.Energy = energy;
            this.MaxEnergy = maxEnergy;
            this.Armor = armor;

        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {Hp}/{Maxhp}");
            Console.WriteLine($"Energy: {Energy}/{MaxEnergy}");
            Console.WriteLine($"Armor: {Armor}");
        }
        public void DisplayPlayerInfoTabular()
        {
            Console.WriteLine($"| {name,-6} | {Hp,3}/{Maxhp,-3}          | {Energy,3}/{MaxEnergy,-3}          | {Armor,3}   |");
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
            if (armor >= 0)
            {
                Armor = armor;
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
