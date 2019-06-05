using System.Collections.Generic;

namespace consolepirates.Models
{

    public class Quest
    {
        public string name;
        public Location location;
        public Loot loot;
        public string description;
        public bool completed;
        public Quest(string qname, Location qlocation, Loot qloot)
        {
            name = qname;
            location = qlocation;
            loot = qloot;
            description = $"You will need to plunder {location} and collect a{loot}.";
            completed = false;
        }
    }

    public class QuestList
    {
        public List<Quest> availableQuests;
        public QuestList()
        {
            availableQuests = new List<Quest>()
            {
            
            };
        }
    }

    // public class Plunder : Quest {
    //     public Plunder(string qname, Location)
    //     {
    //         name = qname;
    //         description = "Plunder";
    //         location = 
    //         completed = false;
    //     }
    // }
    // public class DogFight : Quest{
    //     public DogFight(string qname)
    //     {
    //         name = qname;
    //         description = "Take a ship";
    //         EnemyFighter = ""
    //         completed = false;
    //     }
    // }
}