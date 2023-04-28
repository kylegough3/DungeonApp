using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This is NOT a datatype class, so we will not have fields, properties, or constructors
        //It is a warehouse of combat methods.

        //Handle one side of an attack
        public static void DoAttack(Character attacker, Character defender)
        {
            //Adjust the hit chance
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            //Roll a random number between 1-100
            Random rand = new Random();
            int roll = rand.Next(1 , 101);
            //The attacker "hits if the roll is less than the adjusted hit chance
            if (roll <= chance)
            {
                int damage = attacker.CalcDamage();
                //Subtract the damage from the defender's life
                defender.Life -= damage;
                //output result
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
                Console.ResetColor();

                //Could add expansion for critical hit
                //if roll == 100, then increase damage by something. maybe damage *2. if fail with a 1, maybe hurt attacker instead of defender
            }
            else
            { Console.WriteLine($"The {attacker.Name} missed!"); }
            Console.WriteLine($"Roll: {roll}\n" +
                $"Chance: {chance}");

        }
        //Handle one round of battle, attacks from both sides
        public static void DoBattle(Player player, Monster monster)
        {
            //For this example, we will grant the player "initiative" by default.
            DoAttack(player, monster);
            //if the monster survives, let them attack
            if (monster.Life >0) 
            {
                DoAttack(monster, player);
            }
        }
    }
}
