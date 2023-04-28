using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //Props
        //MinDamage int - Field - Business rule: >0 AND <MaxDamage
        //MaxDamage int
        //Description string
        #region Potential Exansion
        //Add a WeaponType for a weakness. Or a resistance.
        //You could then add functionality to tomorrow's combat class to deal additional damage
        #endregion
        private int _minDamage;
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value < 0)
                { value = 1; }
                else if (value > MaxDamage)
                { value = MaxDamage; }
                else { _minDamage = value; }
            }
        }
        public string Description;

        public Monster(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description)
            : base(name, hitChance, block, maxLife)
        {
            //TODO - create the props/fields, add parameters, and assign the props
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
            if (maxDamage <= minDamage || minDamage <= 0)
            {
                throw new ArgumentException("Min Damage must be between zero and Max Damage");
            }
        }
        public Monster() { } //empty CTOR for default monsters

        // Override the ToString() to include your new custom props
        public override string ToString()
        {
            return base.ToString() + $"\nDamage: {MinDamage} - {MaxDamage}\n" +
                $"Description: {Description}";
        }
        // Override CalcDamage()
        public override int CalcDamage()
        {
            //return a random number between your min and max damage
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

    }//end class Monster

    
}
