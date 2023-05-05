using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    
        public sealed class Turkey : Monster
        {
            //At least 1 prop
            //Parent compliant ctor
            //Override ToString()
            //Override at least oen calcBlock(), CalcHitChance(), and or CalcDamage()



            public bool IsPoultry { get; set; }
            public Turkey(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isPoultry)
                : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
            {
            
            IsPoultry = isPoultry;
            }
        public Turkey() 
        {
            MaxLife = 80;
            MaxDamage = 30;
            Name = "Turkey";
            Life = 80;
            MinDamage = 1;
            HitChance = 45;
            Description = "A truly vengeful turkey";
            Block = 30;
            IsPoultry = true;
        } //unqualified
        public override int CalcBlock()
        {
            
            Random rand = new Random();
            int distracted = rand.Next(1, 10);
            if (distracted < 2) { return base.CalcBlock() / 2; }
            else { return base.CalcBlock(); }
        }
        public override string ToString()
        {
            return base.ToString() + $"{(IsPoultry ? "I'm fowl" : "")}";
        }

    }
    
}
