using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    
        public class Goose : Monster
        {
            //At least 1 prop
            //Parent compliant ctor
            //Override ToString()
            //Override at least oen calcBlock(), CalcHitChance(), and or CalcDamage()



            public bool IsPoultry { get; set; }
            public bool CanHonk { get; set; }
            public Goose(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isPoultry, bool canHonk)
                : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
            {
            
            IsPoultry = isPoultry;
            CanHonk = canHonk; 
            }
        public Goose() 
        {
            MaxLife = 60;
            MaxDamage = 20;
            Name = "Turkey";
            Life = 80;
            MinDamage = 1;
            HitChance = 45;
            Description = "A truly vengeful turkey";
            Block = 20;
            IsPoultry = true;
            CanHonk = true;
        } //unqualified
        public override int CalcBlock()
        {
            
            Random rand = new Random();
            int distracted = rand.Next(1, 10);
            if (distracted < 2) { return base.CalcBlock() / 2; }
            else { return base.CalcBlock(); }
        }

        public override int CalcDamage()
        {
            if (CanHonk)
            {
                return base.CalcDamage()+5;
            }
            else { return base.CalcDamage(); }
        }

        public override string ToString()
        {
            return base.ToString() + $"{(IsPoultry ? "I'm fowl" : "")}\n" +
                $"{(CanHonk ? "I'm noisy" : "")}";
        }

    }
    
}
