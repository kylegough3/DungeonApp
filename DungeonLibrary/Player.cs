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
                case Race.Fry_Cook:
                    //HitChance += 5;
                    break;
                case Race.Delicatessen_Clerk:
                    //HitChance += 3;
                    //Block += 3;
                    break;
                case Race.Sous_Chef:
                   // MaxLife += 5;
                    break;
                case Race.Cook:
                    //HitChance += 1;
                    //MaxLife -= 2;
                    break;
                case Race.Princess:
                    //HitChance -= 2;
                    //Block += 5;
                    break;
            }

            #endregion

        }
        public override string ToString()
        {
            string raceDescription = "";
            switch (PlayerRace)
            {
                case Race.Fry_Cook:
                    raceDescription = "A non-copyrighted sea creature fully of holes";
                    break;
                case Race.Delicatessen_Clerk:
                    raceDescription = "A moustached afficionado of meats";
                    break;
                case Race.Sous_Chef:
                    raceDescription = "A purveyor of only the finest dishes";
                    break;
                case Race.Cook:
                    raceDescription = "They make food";
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
