using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        /*
         * Weapon: Make fields and props for each of these with the appropriate naming conventions.
            Business rule on MinDamage, can't be more than MaxDamage, or less than 1. If it is, default it to 1.
            minDamage – int
            maxDamage – int
            name – string
            bonusHitChance – int
            isTwoHanded - bool
         */

        //frugal people collect money
        //FIELDS
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //PROPERTIES
        public int MinDamage
        {
            get { return _minDamage; }
            set {
                if (value < 0)
                { _minDamage = 1; }
                else if (value > MaxDamage)
                { _minDamage = MaxDamage - 1; }
                else
                { _minDamage = value; }
            }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { 
                 if (value < MinDamage)
                { _maxDamage = MinDamage; }
                else
                { _maxDamage = value; }
                }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        //CONSTRUCTORS
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded)
        { //Fully Qualified
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }//end Fully Qualified
        public Weapon()
        { }//Unqualified
        //METHODS
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Min Damage: {MinDamage}" +
                $"Max Damage: {MaxDamage}" +
                $"Bonus Hit Chance: {BonusHitChance}" +
                $"Two Handed: {IsTwoHanded}";
        }
    }
}
