using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    
        public sealed class Egg : Monster
        {
            //At least 1 prop
            //Parent compliant ctor
            //Override ToString()
            //Override at least oen calcBlock(), CalcHitChance(), and or CalcDamage()



            public bool IsAcidic { get; set; }
            public Egg(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isAcidic)
                : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
            {
            
            IsAcidic = isAcidic;
            }
        public Egg() 
        {
            MaxLife = 50;
            MaxDamage = 10;
            Name = "Egg";
            Life = 20;
            MinDamage = 1;
            HitChance = 35;
            Description = "A slimey egg with spines";
            Block = 10;
            IsAcidic = true;
        } //unqualified
        public override int CalcDamage()
        {
            
            return base.CalcDamage()*2;
        }
        public override string ToString()
        {
            return base.ToString() + $"{(IsAcidic ? "I'm fragile" : "")}";
        }

    }
    
}
