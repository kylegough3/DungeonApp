using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    
        public class Egg : Monster
        {
            //At least 1 prop
            //Parent compliant ctor
            //Override ToString()
            //Override at least oen calcBlock(), CalcHitChance(), and or CalcDamage()



            public bool IsFragile { get; set; }
            public Egg(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isFragile)
                : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
            {
            MaxLife = 50;
            MaxDamage = 10;
            Name = "Egg";
            Life = 20;
            MinDamage = 1;
            HitChance = 10;
            Description = "A slimey egg with spines";
            IsFragile = true;
            Block = 10;
            }
        public Egg() { } //unqualified
        public override int CalcDamage()
        {
            
            return CalcDamage()*2;
        }
        public override string ToString()
        {
            return base.ToString() + $"{(IsFragile ? "I'm fragile" : "")}";
        }

    }
    
}
