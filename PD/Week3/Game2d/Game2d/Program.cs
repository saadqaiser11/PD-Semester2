using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;

namespace Game2d
{
    internal class Program
    {
        
        public static string[] boardRows =
            {
            "################################################################################################",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                          #########                                           #",
            "#                                          ##     ##                                           #",
            "#                                          ##     ##                                           #",
            "#                                         ###     ###                                          #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#                                                                                              #",
            "#######################              ###########################################################",
            "#                     #                                    #                                   #",
            "#                     #                                    #                                   #",
            "#                     #                                    #                                   #",
            "#                     #                                    #                                   #",
            "#                     #                                    #                                   #",
            "#                     #                                    #                                   #",
            "#              ########                                    #                                   #",
            "#                                                          #                                   #",
            "#                                                         ###                                  #",
            "#                                   ###                                                        #",
            "#                                    #                                                ##########",
            "#                                    #                                                         #",
            "#                                    #                                                         #",
            "#                                    #                                                         #",
            "#                                    #                                                         #",
            "#                                    #                                                         #",
            "#                                    #                                                         #",
            "#                                    #                                                         #",
            "################################################################################################",
            "#                                   |  Health  =  100       |                                  #",
            "#                                                                                              #",
            "################################################################################################"
            };

        static void Main(string[] args)
        {
            char enemy1Dir = 'U';
            char enemy2Dir = 'D';
            bool fired = false;
            
            char[,] Maze = new char[34, 99];
            player Player = new player('M', 17, 17);
            List<enemy> enemies = new List<enemy>();
            enemy enemy1 = new enemy('X', 7, 90,'x');
            enemies.Add(enemy1);
            enemy enemy2 = new enemy('W', 25, 90, 'w');
            enemies.Add(enemy2); 


            for (int i = 0; i < boardRows.Length; i++)
            {
                for (int j = 0; j < boardRows[i].Length; j++)
                {
                    Maze[i, j] = boardRows[i][j];
                }
            }

            Maze[Player.playerx, Player.playery] = Player.symbol;
            Maze[enemies[0].enemyx, enemies[0].enemyy] = enemies[0].symbol;
            Maze[enemies[1].enemyx, enemies[1].enemyy] = enemies[1].symbol;


            while (true)
            {
                printmaze(Maze);
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    Player.moveHeroLeft(Maze);
                    Console.WriteLine("Left");
                }

                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    Player.moveHeroRight(Maze);
                    Console.WriteLine("Right");
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    Player.moveHeroUp(Maze);
                    Console.WriteLine("Up");
                }

                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                   Player.moveHeroDown(Maze);
                    Console.WriteLine("Down");
                }

                else if (Keyboard.IsKeyPressed(Key.Space) && !fired)
                {
                    Player.createFire(Maze);
                    fired = true;
                }

                if (fired)
                {
                    moveFire(Maze, ref fired);
                }

                if (!enemies[0].enemyfire)
                {
                    enemies[0].printenemyfire(Maze);
                }
                else
                {
                    enemies[0].moveEnemyFire(Maze);
                }

                if (!enemies[1].enemyfire)
                {
                    enemies[1].printenemyfire(Maze);
                }
                else
                {
                    enemies[1].moveEnemyFire(Maze);
                }


                enemies[0].moveEnemy(Maze, ref enemy1Dir);
                enemies[1].moveEnemy(Maze, ref enemy2Dir);
                Thread.Sleep(75);
            }
        }

        static void printmaze(char[,] Maze)
        {
            string print = "";
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    print += Maze[i,j];
                }
                print += "\n";
            }
            Console.Clear();
            Console.Write(print);
        }

       

        


    /*
        static void moveEnemy2(char[,] Maze, ref char enemy2Dir)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i,j] == 'W')
                    {
                        // Clear current position

                        if (enemy2Dir == 'D')
                        {
                            if (Maze[i + 1,j] != '#') // Check if moving down is valid
                            {
                                Maze[i,j] = ' ';
                                Maze[i + 1,j] = 'W';
                                // Update position
                                break;
                            }
                            else
                            {
                                enemy2Dir = 'U'; // Change direction to 'U'
                            }
                        }
                        else if (enemy2Dir == 'U')
                        {
                            if (Maze[i - 1,j] != '#') // Check if moving up is valid
                            {
                                Maze[i,j] = ' ';
                                Maze[i - 1,j] = 'W'; // Update position
                                break;
                            }
                            else
                            {
                                enemy2Dir = 'D'; // Change direction to 'D'
                            }
                        }
                    }
                }
            }
        }



        */


        static void moveFire(char[,] Maze, ref bool fired)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 98; j++)
                {
                    if (Maze[i,j] == 'o')
                    {

                        if (Maze[i,j + 1] != '#' )
                        {
                            Maze[i,j + 1] = 'o';
                            Maze[i,j] = ' ';
                            break;
                        }
                        else
                        {
                            Maze[i,j] = ' ';
                            fired = false;
                            break;
                        }
                    }
                }
            }
        }

        
        /*
        static void printenemy2fire(char[,] Maze, ref bool enemy2fire, enemy enemy2)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i,j] == enemy2.symbol)
                    {
                        Maze[i,j - 1] = 'w';
                        enemy2fire = true;
                    }
                }
            }
        }
        */
        

        /*
        static void moveEnemy2Fire(char[,] Maze, ref bool enemy2fire)
        {
            for (int i = 0; i < 34; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    if (Maze[i,j] == 'w')
                    {

                        if (Maze[i,j - 1] != '#')
                        {
                            Maze[i,j - 1] = 'w';
                            Maze[i,j] = ' ';
                            break;
                        }
                        else
                        {
                            Maze[i,j] = ' ';
                            enemy2fire = false;
                            break;
                        }
                    }
                }
            }
        }

        */
    }
}
