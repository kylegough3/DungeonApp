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

            Weapon w1 = new Weapon("Wooden Sword", 1, 5, 0, false);
            Console.WriteLine(w1);


        }//end Main()
    }//end class
}//end namespace
