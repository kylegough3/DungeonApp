using DungeonLibrary;
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
            Console.WriteLine("What is your name?");
            string gamerName = Console.ReadLine();
            Console.WriteLine($"Welcome, Adventurer {gamerName}! Your journey begins!");

            #endregion

            // Variable to keep score
            //Potential expansion, use "money" of some sort instead of a score to let user buy potions, weapons, whatever.
            int score = 0;

            //Weapon object creation
            //bool confirm = false;
            //do
            //{
            #region Weapon creation and choice
                Weapon weap1 = new("Spongebob's Spatula", WeaponType.Spatula, 3, 35, 12, false);
                Weapon weap2 = new("Harley's Mallet", WeaponType.Mallet, 5, 20, 10, true);
                Weapon weap3 = new("Ash's Chainsaw", WeaponType.Chainsaw, 1, 50, 5, true);
                Weapon weap4 = new("Sweedish Chef's Cleaver", WeaponType.Cleaver, 5, 25, 25, false);
                Weapon weap5 = new("Rapunzel's Frying Pan", WeaponType.Frying_Pan, 7, 30, 20, false);

                bool weapchosen = false;
                Weapon userWeapon = new();
                do
                {
                    Console.WriteLine($"Choose your weapon: (1-5)\n" +
                        $"1 - {weap1.WeaponType}\t{weap1.Name}\n" +
                        $"2 - {weap2.WeaponType}\t{weap2.Name}\n" +
                        $"3 - {weap3.WeaponType}\t{weap3.Name}\n" +
                        $"4 - {weap4.WeaponType}\t{weap4.Name}\n" +
                        $"5 - {weap5.WeaponType.ToString().Replace('_', ' ')}\t{weap5.Name}\n" +
                        $"r = Random\n");

                    char userChoice = (Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    switch (userChoice)
                    {
                        case '1': userWeapon = weap1; weapchosen = true; break;
                        case '2': userWeapon = weap2; weapchosen = true; break;
                        case '3': userWeapon = weap3; weapchosen = true; break;
                        case '4': userWeapon = weap4; weapchosen = true; break;
                        case '5': userWeapon = weap5; weapchosen = true; break;
                        case 'r':
                            {
                                Random random = new Random();
                                int randWeapInt = random.Next(1, 6);
                                string randChoiceStr = Convert.ToString(randWeapInt);
                                char randChoice = Convert.ToChar(randChoiceStr);
                                switch (randChoice)
                                {
                                    case '1': userWeapon = weap1; weapchosen = true; break;
                                    case '2': userWeapon = weap2; weapchosen = true; break;
                                    case '3': userWeapon = weap3; weapchosen = true; break;
                                    case '4': userWeapon = weap4; weapchosen = true; break;
                                    case '5': userWeapon = weap5; weapchosen = true; break;
                                    default: break;
                                }
                                Console.WriteLine($"You randomly chose: {userWeapon.Name}!");
                                break;
                            }
                        default: Console.WriteLine("Invalid Entry"); break;
                    }
                } while (!weapchosen);
                Console.WriteLine();
#endregion


                //Player object creation

                #region Player Character Choice


                Player player1 = new($"{gamerName}", 70, 15, 100, Race.Fry_Cook, userWeapon);
                Player player2 = new($"{gamerName}", 70, 15, 100, Race.Delicatessen_Clerk, userWeapon);
                Player player3 = new($"{gamerName}", 70, 15, 100, Race.Sous_Chef, userWeapon);
                Player player4 = new($"{gamerName}", 70, 15, 100, Race.Cook, userWeapon);
                Player player5 = new($"{gamerName}", 70, 15, 100, Race.Princess, userWeapon);
                Player player = new();

                bool classChosen = false;
                do
                {
                    Console.WriteLine($"Choose your class: (1-5)\n" +
                        $"1 - {gamerName} the {player1.PlayerRace.ToString().Replace('_', ' ')}\n" +
                        $"2 - {gamerName} the {player2.PlayerRace.ToString().Replace('_', ' ')}\n" +
                        $"3 - {gamerName} the {player3.PlayerRace.ToString().Replace('_', ' ')}\n" +
                        $"4 - {gamerName} the {player4.PlayerRace.ToString().Replace('_', ' ')}\n" +
                        $"5 - {gamerName} the {player5.PlayerRace.ToString().Replace('_', ' ')}\n" +
                        $"r = Random\n");
                    char userChoice = (Console.ReadKey().KeyChar);
                    switch (userChoice)
                    {
                        case '1': player = player1; classChosen = true; break;
                        case '2': player = player2; classChosen = true; break;
                        case '3': player = player3; classChosen = true; break;
                        case '4': player = player4; classChosen = true; break;
                        case '5': player = player5; classChosen = true; break;
                        case 'r':
                            {
                                Random random = new Random();
                                int randPlayInt = random.Next(1, 6);
                                string randChoiceStr = Convert.ToString(randPlayInt);
                                char randChoice = Convert.ToChar(randChoiceStr);
                                switch (randChoice)
                                {
                                    case '1': player = player1; classChosen = true; break;
                                    case '2': player = player2; classChosen = true; break;
                                    case '3': player = player3; classChosen = true; break;
                                    case '4': player = player4; classChosen = true; break;
                                    case '5': player = player5; classChosen = true; break;
                                    default: break;
                                }
                                Console.WriteLine($"You randomly chose: {player.PlayerRace.ToString().Replace('_', ' ')}!");
                                break;
                            }
                        default: Console.WriteLine("Invalid Entry"); break;
                    }
                } while (!classChosen);
                #endregion

                #region Weapon and Race Pair Boosts
                //Weapon + Race boosters
                if (player.PlayerRace == Race.Fry_Cook && userWeapon == weap1)
                { player.HitChance += 2; }
                if (player.PlayerRace == Race.Delicatessen_Clerk && userWeapon == weap4)
                { player.HitChance += 2; }
                if (player.PlayerRace == Race.Sous_Chef && userWeapon == weap2)
                { player.HitChance += 2; }
                if (player.PlayerRace == Race.Cook && userWeapon == weap3)
                { player.HitChance += 2; }
                if (player.PlayerRace == Race.Princess && userWeapon == weap5)
                { player.HitChance += 2; }
                #endregion

            //    Console.WriteLine($"You are {gamerName}, the {player.PlayerRace.ToString().Replace('_', ' ')}, wielding a {userWeapon.Name}.\n" +
            //        $"Is this correct? (Y/N)");
            //    string confirmation = Console.ReadLine().ToUpper();
            //    switch (confirmation)
            //    {
            //        case "Y": confirm = true; break;
            //        case "N": { weapchosen = false; classChosen = false; confirm = true; } break;
            //        default: Console.WriteLine("Invalid Entry"); break;
            //    }
            //} while (!confirm);

            Console.Clear();
            Console.WriteLine("Let's Begin!");
            //Main Game Loop
            bool lose = false;
            do
            {
                //Generate a room
                Console.WriteLine(GetRoom());
                //Generate a monster
                Monster monster = GetMonster();

                Console.WriteLine($"In this room: { monster.Name} - {monster.Description}");
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
                            Console.WriteLine($"{gamerName} Life: {player.Life} / {player.MaxLife}\n" +
                                $"{monster.Name} Life: {monster.Life} / {monster.MaxLife}");
                            
                            //check if the monster is dead
                            if (monster.Life <=0)
                            {
                                Console.WriteLine($"\nYou killed {monster.Name}\n");
                                Console.ResetColor();
                                reload = true;
                                score++;
                                Console.WriteLine("Choose your reward bonus! (1-3):\n" +
                                    "1 - Increase Accuracy\n" +
                                    "2 - Increase Defense\n" +
                                    "3 - Increase Strength\n" +
                                    "4 - Increase Health\n" +
                                    "5 - Increase Stealth");
                                char boostChoice = (Console.ReadKey().KeyChar);
                                switch (boostChoice)
                                {
                                    case '1': player.HitChance += 2; break;
                                    case '2': player.Block += 2; break;
                                    case '3': userWeapon.MaxDamage += 2; break;
                                    case '4': player.Life += 5; break;
                                    case '5': monster.HitChance -= 2; break;
                                    default: Console.WriteLine("Invalid Entry"); break;
                                }
                                Console.Clear();
                                

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
                            Console.WriteLine($"{gamerName} - {player}\n You have defeated {score} monsters");
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
                        Console.ReadKey();
                        Console.Clear();
                        lose = true;
                    }
                } while (!reload && !lose);
                //while reload and lose are both false, keep looping
                #endregion


            } while (!lose);
            //while lose is false, keep looping
            //Output the final score
            Console.WriteLine($"GAME OVER\n\n{player}\n You have defeated {score} monster{(score ==1 ? "." : "s.")}");

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
            
            //return a room using the rng
            return rooms[rand.Next(rooms.Length)];
        }
        private static Monster GetMonster()
        {
            Monster m1 = new Egg();
            Monster m2 = new Turkey();
            Monster m3 = new Goose();
            Monster m4 = new Ostrich();

            Monster[] monsters =
            {
                m1,m1, m1, m2, m2, m3, m3, m4,
            };
            return monsters[new Random().Next(monsters.Length)];
        }

        
    }//end class
}//end namespace
