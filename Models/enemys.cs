using System.Collections.Generic;
namespace consolepirates.Models
{
    Random rand = new Random();
    public class EnemySkipper : Skipper
    {
        public EnemySkipper()
        {
            cannons = rand.Next(1,3);
            currentCargo = List<ILootable>(rand.Next(0,7)); //Is this correct? How would I do multiple items in cargo?
        }
    }
    public class EnemyHauler : Hauler
    {
        public EnemyHauler()
        {
            cannons = rand.Next(2,4);
            currentCargo = List<ILootable>(rand.Next(0,7));
        }
    }
    public class EnemyFighter : Fighter
    {
        public EnemyFighter()
        {
            cannons = rand.Next(3,6);
            currentCargo = List<ILootable>(rand.Next(0,7));
        }
    }
    public class EnemyNautilous : Nautilous
    {
        public EnemyNautilous()
        {
            cannons = rand.Next(8,12);
            currentCargo = List<ILootable>(rand.Next(0,7));
        }
    }
}