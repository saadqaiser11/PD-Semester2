using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalDuelChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player alice = new Player("Alice", 110, 50, 10);
            Player bob = new Player("Bob", 100, 60, 20);
            Stat fireball = new Stat("fireball", 23, 1, 5, 15, "a firey magical attack");
            alice.learnSkill(fireball);
            Console.WriteLine(alice.Attack(bob));
            Console.ReadLine();

            Stat superbeam = new Stat("superbeam", 200, 50, 50, 75, "an overpowered attack, pls nerf");
            bob.learnSkill(superbeam);
            Console.WriteLine(bob.Attack(alice));

            Console.ReadLine();
        }
    }
}
