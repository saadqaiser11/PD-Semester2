using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlayMagicDuel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Player> players = new List <Player> ();
            List <Stat> stats = new List <Stat> ();

            while (true)
            {
                Console.Clear ();
                string choice = menu();
                if (choice == "1")
                {
                    Player p = takeInput();
                    players.Add(p);
                    returnMenu();
                }
                else if (choice == "2")
                {
                    Stat skill = takeInfo();
                    stats.Add(skill);
                    returnMenu();
                }
                else if (choice == "3")
                {
                    foreach (Player stored in players)
                    {
                        Console.WriteLine();
                        stored.DisplayPlayerInfo();
                        Console.WriteLine();
                    }
                    returnMenu();
                }
                else if (choice == "4")
                {
                    string nameP = takeName();
                    string nameS = takeNameS();
                    Player FoundPlayer = FindPlayer(nameP, players);
                    Stat FoundSkill = FindSkill(nameS, stats);
                    if (FoundPlayer != null && FoundSkill != null)
                    {
                        FoundPlayer.learnSkill(FoundSkill);
                    }
                    else
                    {
                        Console.WriteLine("Either the Player or the Skill doent not exist.");

                    }

                    returnMenu();

                }
                else if (choice == "5")
                {
                    Console.Clear();
                    Console.WriteLine($"| Name   | Health         | Energy         | Armor |");
                    Console.WriteLine($"|--------|----------------|----------------|-------|");
                    foreach (Player stored in players)
                    {
                        stored.DisplayPlayerInfoTabular();
                    }

                    string name = takeName();
                    Player FoundPlayer = FindPlayer(name, players);
                    Console.WriteLine("Now the target:");
                    string name1 = takeName();
                    Player FoundTarget = FindPlayer(name1, players);

                    Console.WriteLine(FoundPlayer.Attack(FoundTarget));

                    returnMenu();

                }

                else if (choice == "6")
                {
                    break;
                }
            }
        }

        static string menu()
        {
            Console.WriteLine("------PLAY MAGIC DUEL------");
            Console.WriteLine("1. ADD PLAYER");
            Console.WriteLine("2. ADD SKILL STATISTICS");
            Console.WriteLine("3. DISPLAY PLAYER INFO");
            Console.WriteLine("4. LEARN A SKILL");
            Console.WriteLine("5. ATTTACK");
            Console.WriteLine("6. EXIT");
            Console.Write("ENTER YOUR CHOICE: ");
            return Console.ReadLine();
        }

        static Player takeInput()
        {
            Console.Write("Enter the player name: ");
            string name = Console.ReadLine();
            Console.Write("Enter health: ");
            int health = int.Parse(Console.ReadLine());
            Console.Write("Enter maxHealth: ");
            int maxHealth = int.Parse(Console.ReadLine());
            Console.Write("Enter energy: ");
            int energy =    int.Parse(Console.ReadLine());
            Console.Write("Enter maxEnergy: ");
            int maxEnergy = int.Parse(Console.ReadLine());
            Console.Write("Enter armor: ");
            int armor =  int.Parse(Console.ReadLine()); 

            return new Player (name, health, maxHealth,energy, maxEnergy, armor);
        }

        static Stat takeInfo()
        {
            Console.Write("Enter the skill name: ");
            string name = Console.ReadLine();
            Console.Write("Enter damage: ");
            int damage = int.Parse(Console.ReadLine());
            Console.Write("Enter penetration: ");
            int penetration = int.Parse(Console.ReadLine());
            Console.Write("Enter heal: ");
            int heal = int.Parse(Console.ReadLine());
            Console.Write("Enter cost: ");
            int cost = int.Parse(Console.ReadLine());
            Console.Write("Enter description: ");
            string descrypt = Console.ReadLine();

            return new Stat(name, damage, penetration, heal, cost, descrypt);
        }

        static void returnMenu()
        {
            Console.WriteLine();
            Console.Write("Press any key to return.");
            Console.Read();
        }

        static string takeName()
        {
            Console.WriteLine("Enter the name Of The Player: ");
            return Console.ReadLine();
        }
        static string takeNameS()
        {
            Console.WriteLine("Enter the name Of The Skill: ");
            return Console.ReadLine();
        }

        static Player FindPlayer(string name, List <Player> players)
        {
            Player found = players.Find(player => player.name == name);
            return found;
        }

        static Stat FindSkill(string name, List<Stat> stats)
        {
            Stat found = stats.Find(stat => stat.name == name);
            return found;
        }
    }
}
