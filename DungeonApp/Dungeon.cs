using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp
{
    internal class Dungeon
    {
        static void Main(string[] args)
        {
            #region Introduction
            //Start to play background music? (.wav) <100MB
            //System.Windows.Extensions (NuGet package)
            Console.Title = "DUNGEON OF DOOM";
            Console.WriteLine("Welcome, Adventurer! Your journey begins!");

            #endregion

            //TODO - Variable to keep score

            //TODO - Weapon object creation

            //TODO - Player object creation

            //TODO - Main Game Loop
            bool lose = false;
            do
            {
                //Generate a room
                Console.WriteLine(GetRoom());
                //TODO - Generate a monster
                #region Main Menu Loop

                //Encounter/Menu Loop
                bool reload = false;
                do
                {
                    //print the menu
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit");
                    //capture their selection
                    ConsoleKey choice = Console.ReadKey(true).Key;
                    //clear the console
                    Console.Clear();
                    //switch
                    switch (choice)
                    {
                        case ConsoleKey.A: //TODO Combat
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!");
                            reload = true;
                            break;
                        case ConsoleKey.P: //TODO Player
                        case ConsoleKey.M: //TODO Monster
                        case ConsoleKey.Escape:
                        case ConsoleKey.X:
                            Console.WriteLine("No one likes a quitter!");
                            lose = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Triest thou again.");
                            break;
                    }//end switch

                    //TODO Check player life. If they're dead, game over.
                } while (!reload && !lose);
                //while reload and lose are both false, keep looping
                #endregion


            } while (!lose);
            //while lose is false, keep looping
            //TODO Output the final score

        }//end Main()

        private static string GetRoom()
        {
            //create a string[]
            string[] rooms =
            {
                "The room is covered in dust, dirt, and stones. Even boulders.",
                "There is a giant pool in the center of the room, with small platforms scattered throughout.",
                "The room is filled with succulents.",
                "The room is dark, lit only by small candles.",
                "There is a large boxing ring in the middle of the room.",
                "There are icicles on the ceiling and the floor is a sheet of ice.",
            };
            //rng
            Random rand = new Random();
            int index = rand.Next(rooms.Length);
            //return a room using the rng
            return rooms[index];
        }

        
    }//end class
}//end namespace
