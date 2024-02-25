using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool checkFirst = false;
            bool checkAgain = false;
            gameClass gameClass = new gameClass();
            Console.WriteLine("--------Welcome to the Shiratori Game------");
            Console.WriteLine();
            while (true)
            {
                string word = takeWord();
                
                if (gameClass.checkLast(word, checkFirst))
                {
                    gameClass.play(word, checkFirst);
                    gameClass.displayWords();
                }
                else
                {
                    gameClass.gameOver = true;
                }
                
                if(gameClass.gameOver)
                {
                    Console.WriteLine("The Game is Over.....");
                    string choice = ContinueOrStop();
                    if(choice == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("--------Welcome Back to Shiratori Game------");
                        Console.WriteLine();
                        gameClass.reset();
                        checkFirst = false;
                        checkAgain = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (!checkAgain)
                {
                    checkFirst = true;
                }
                else
                {
                    checkAgain = false;
                }

            }

        }

        static string takeWord()
        {
            Console.Write("Enter your word: ");
            string word = Console.ReadLine();
            return word;
        }

        static string ContinueOrStop()
        {
            Console.Write("Enter any key to Exit the game or 1 to Restart the Game: ");
            return Console.ReadLine();
        }

        
    }
}
