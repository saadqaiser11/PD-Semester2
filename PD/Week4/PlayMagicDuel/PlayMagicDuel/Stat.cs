using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMagicDuel
{
    internal class Stat
    {
        public string name;
        public int damage;
        public string description;
        public int penetration;
        public int cost;
        public int heal;

        public Stat(string name, int damage, int penetration, int heal, int cost, string description)
        {
            this.name = name;
            this.damage = damage;
            this.description = description;
            this.penetration = penetration;
            this.cost = cost;
            this.heal = heal;
        }

        public Stat()
        {

        }
    }
}
