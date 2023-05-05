using DungeonLibrary;
using System.Numerics;

namespace DungeonUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void RaceBoostTest()
        {
            //Check Race boosts
            //Arrange
            Weapon weap1 = new("Spongebob's Spatula", WeaponType.Spatula, 3, 35, 12, false);
            Weapon userWeapon = weap1;
            string gamerName = "Name";
            Player player1 = new($"{gamerName}", 70, 15, 100, Race.Fry_Cook, userWeapon);
            //Act
            int expected = 75;//input value of 70 + Race.Fry_Cook boost 5
            //Assert
            Assert.Equal(expected, player1.HitChance);
        }

        [Fact]
        public void RaceWeapPairTest()
        {
            Weapon weap1 = new("Spongebob's Spatula", WeaponType.Spatula, 3, 35, 12, false);
            Weapon userWeapon = weap1;
            string gamerName = "Name";
            Player player1 = new($"{gamerName}", 70, 15, 100, Race.Fry_Cook, userWeapon);
            //below if is copied from Dungeon
            if (player1.PlayerRace == Race.Fry_Cook && userWeapon == weap1)
            { player1.HitChance += 2; }
            //Act
            int expected = 77;//input value of 70 + Race.Fry_Cook boost 5 + Pair boost 2
            //Assert
            Assert.Equal(expected, player1.HitChance);
        }
    }
}