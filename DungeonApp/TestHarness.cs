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
            Player c1 = new Player("Test Character", 50, 20, 100, Race.Princess,);
            Console.WriteLine(c1);
            Console.WriteLine("CalcBlock: " + c1.CalcBlock());
            Console.WriteLine("CalcDamage: " + c1.CalcDamage());
            Console.WriteLine("CalcHitChance: " + c1.CalcHitChance());

            Weapon w1 = new Weapon("Wooden Sword", WeaponType.sword, minDamage: 1, maxDamage: 5, bonusHitChance: 0, isTwoHanded: false);
            Console.WriteLine(w1);

            //TODO Test player creation and ToString(), calcblock, calcdamage, calchitchance
            //TODO Test monster creation and ToString(), calcblock, calcdamage, calchitchance


        }//end Main()
    }//end class
}//end namespace
