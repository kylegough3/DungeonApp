using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    
        public sealed class Ostrich : Monster
        {
            

            private int _speed;

            public bool IsPoultry { get; set; }
            public bool CanHonk { get; set; }
            public int Speed { get; set; }

            public Ostrich(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, bool isPoultry, bool canHonk, int speed)
                : base(name, hitChance, block, maxLife, minDamage, maxDamage, description)
            {
            
            IsPoultry = isPoultry;
            CanHonk = canHonk;
            Speed = speed;
        }
        public Ostrich() 
        {
            MaxLife = 80;
            MaxDamage = 30;
            Name = "Ostrich";
            Life = 80;
            MinDamage = 1;
            HitChance = 55;
            Description = "The largest of birds";
            Block = 30;
            IsPoultry = true;
            CanHonk = true;
            Speed = new Random().Next(10);
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

        public override int CalcHitChance()
        {
            if (Speed > 8) { return base.CalcHitChance() * 2; }
            else { return base.CalcHitChance(); }
        }

        public override string ToString()
        {
            return base.ToString() + $"{(IsPoultry ? "I'm fowl" : "")}\n" +
                $"{(CanHonk ? "I'm noisy" : "")}";
        }

    }
    
}
