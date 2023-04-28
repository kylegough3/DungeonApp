using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonApp
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            Weapon w1 = new Weapon("Frying Pan", WeaponType.Frying_Pan, minDamage: 1, maxDamage: 5, bonusHitChance: 5, isTwoHanded: true);
            Player player = new Player("Test Character", 80, 20, 100, Race.Princess, w1);
            Egg m1 = new Egg();


            while (player.Life >0 && m1.Life >0)
            {
                Combat.DoBattle(player, m1);
                Console.WriteLine("Current Player Life: " + player.Life);
                Console.WriteLine("Current Monster Life: " + m1.Life);
                Console.ReadKey();
                Console.Clear();
            }
            if (player.Life <=0)
            {
                Console.WriteLine("Dude, you lost");
            }

            
        }//end Main()
    }//end class
}//end namespace
