﻿using DungeonLibrary;
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
            //Potential expansion, use "money" of some sort instead of a score to let user buy potions, weapons, whatever.
            int score = 0;

            //Weapon object creation
            Weapon weap = new("Long Sword", WeaponType.Sword, 1, 8, 10, false);
            //Potential Expansion: Show user a list of weapons and let them pick one. Or assign one Randomly

            //Player object creation
            //Recommended expansion - choose player custom name and race
            Player player = new("Leeroy Jenkins", 70, 15, 40, Race.Elf, weap);

            //TODO - Main Game Loop
            bool lose = false;
            do
            {
                //Generate a room
                Console.WriteLine(GetRoom());
                //Generate a monster
                Monster monster = GetMonster();
                
                Console.WriteLine("In this room: " + monster.Name);
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
                        case ConsoleKey.A: // Combat
                            #region possible expansion - racial/weapon bonus
                            //Give certain races/characters with certain weapon an advantage. If player race is dark elf, them combat.doattack(player, monster)
                            #endregion
                            Combat.DoBattle(player, monster);
                            
                            //check if the monster is dead
                            if (monster.Life <=0)
                            {
                                Console.WriteLine($"\nYou killed {monster.Name}\n");
                                Console.ResetColor();
                                reload = true;
                                score++;
                                //Possible expansion: combat rewards

                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!");
                            //Attack of opportunity
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info:");
                            Console.WriteLine($"{player}\t You have defeated {score} monsters");
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info:");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.Escape:
                        case ConsoleKey.X:
                            Console.WriteLine("No one likes a quitter!");
                            lose = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Triest thou again.");
                            break;
                    }//end switch

                    //Check player life. If they're dead, game over.
                    if (player.Life <=0)
                    {
                        Console.WriteLine("Dude...you died!\a");
                        lose = true;
                    }
                } while (!reload && !lose);
                //while reload and lose are both false, keep looping
                #endregion


            } while (!lose);
            //while lose is false, keep looping
            //Output the final score
            Console.WriteLine($"{player}\t You have defeated {score} monster{(score ==1 ? "." : "s.")}");

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
        private static Monster GetMonster()
        {
            Monster m1 = new("Orc", 50, 40, 20, 1, 8, "A dirty orc wielding a rusty axe");
            Monster m2 = new("Troll", 40, 50, 30, 1, 8, "A troll... from the dungeon");
            Monster m3 = new("Giant Spider", 70, 30, 10, 1, 8, "A giant spider with venomous fangs");
            Monster m4 = new("Goblin", 15, 25, 60, 1, 8, "A sneaky goblin with a sharp knife");

            Monster[] monsters =
            {
                m1,m1, m2, m3, m4, m4, m4, m4
            };
            return monsters[new Random().Next(monsters.Length)];
        }

        
    }//end class
}//end namespace
