using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Player(string name, int hitChance, int block, int maxLife, //Character params
            Race playerRace, Weapon equippedWeapon) //player params
            : base(name, hitChance, block, maxLife) //send ONLY character params back to parent
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
            //In program.cs, you will have to show the user a list of races and let them pick one. The reference for this is in CSF2 Enums.cs for ClassicMonsters
            #region Racial Bonuses
            switch (PlayerRace)
            {
                case Race.Warrior:
                    HitChance += 5;
                    break;
                case Race.Elf:
                    HitChance += 3;
                    Block += 3;
                    break;
                case Race.Dwarf:
                    MaxLife += 5;
                    break;
                case Race.Bard:
                    HitChance += 1;
                    MaxLife -= 2;
                    break;
                case Race.Princess:
                    HitChance -= 2;
                    Block += 5;
                    break;
            }

            #endregion

        }
        public override string ToString()
        {
            string raceDescription = "";
            switch (PlayerRace)
            {
                case Race.Warrior:
                    raceDescription = "A burly, weathered, ranger who is covered in hair. Mostly his.";
                    break;
                case Race.Elf:
                    raceDescription = "A skilled fighter with great vision. From the elf eyes.";
                    break;
                case Race.Dwarf:
                    raceDescription = "Small and mighty with a hankering for TREASURE.";
                    break;
                case Race.Bard:
                    raceDescription = "Only here for some sick tunes. Toss them a coin.";
                    break;
                case Race.Princess:
                    raceDescription = "You want the princess? As part of the fighting game? If you say so.";
                    break;
            }
            return base.ToString() + $"\nWeapon: {EquippedWeapon.Name}\n" +
                $"Description: \n{raceDescription}";

        }//end ToString() override

        public override int CalcDamage()
        {
            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage+1);
        }//end CalcDamage() override

        public override int CalcHitChance()
        {
            //          HitChance + EquippedWeapon.BonusHitChance;
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
            //HitChance - Block = chance that you hit
            //Roll a random number between 1-100. If it's less than hit chance, we hit.
        }//end CalcHitChance() override
    }
}
