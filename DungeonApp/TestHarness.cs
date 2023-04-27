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
            Character c1 = new Character("Test Character", 50, 20, 100, 100);
            Console.WriteLine(c1);
            Console.WriteLine("CalcBlock: " + c1.CalcBlock());
            Console.WriteLine("CalcDamage: " + c1.CalcDamage());
            Console.WriteLine("CalcHitChance: " + c1.CalcHitChance());

            Weapon w1 = new Weapon("Wooden Sword", WeaponType.sword, minDamage: 1, maxDamage: 5, bonusHitChance: 0, isTwoHanded: false);
            Console.WriteLine(w1);


        }//end Main()
    }//end class
}//end namespace
