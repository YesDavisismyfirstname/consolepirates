using System.Collections.Generic;
using System;
namespace consolepirates.Models
{
    
    public class EnemySkipper : Skipper
    {
        public EnemySkipper(string name) : base (name)
        {
            randomEquipment(1,3,8,6);
            randomInventory();
            
        }
    }
    public class EnemyHauler : Hauler
    {
        public EnemyHauler(string name) : base (name)
        {
            randomEquipment(1,10,20,15);
            randomInventory();
        }
    }
    public class EnemyFighter : Fighter
    {
        public EnemyFighter(string name) : base (name)
        {
            randomEquipment(3,6,15,8);
            randomInventory();
        }
    }
    
}