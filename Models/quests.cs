using System.Collections.Generic;
using System;
namespace consolepirates.Models
{

    public class Quest
    {
        public string type;
        public Location pickuplocation;
        public Location targetlocation;
        public Loot QuestItem;
        public int reward;
        public string Instructions;
        public bool completed;
        public Quest(string qname, string Instructions, Location pulocation, Location delloc, Loot qloot,int reward)
        {
            type = qname;
            targetlocation = delloc;
            pickuplocation = pulocation;
            QuestItem = qloot;
            this.reward = reward;
            this.Instructions = Instructions;
            completed = false;
        }
    }
    public class QuestList
    {
        public List<Quest> allQuests;
        public Quest currentQuest;
        public QuestList()
        {
            allQuests = new List<Quest>();
            currentQuest = null;
        }
        public static Quest questRandomizer()
        {
            string[] questsOpts = { "Fetch", "Deliver" };
            Random num = new Random();
            Quest availQuest = null;
            int reward = 0;
            string type = questsOpts[num.Next(0, 2)];
            Location randLoc = Program.world.availableLocations[num.Next(0, 5)];
            Location randCity = Program.world.availableLocations[num.Next(0, 5)];
            Location pickup = randLoc.availableLocations[num.Next(0, randLoc.availableLocations.Count - 1)];
            Location dest = randLoc.availableLocations[num.Next(0, randLoc.availableLocations.Count - 1)];
            if (type == "Fetch")
            {
                reward = num.Next(300, 600);
                string inst = $@"
            # You will need to pick up a package at {pickup.name} in
            #  the city of {randLoc.name}. You will need to deliver
            #  that package to {dest.name} in 
            #   {randCity.name}. You will be paid ${reward} upon
            #       successful delivery of the package.   ";
                availQuest = new Quest("Fetch", inst, pickup, dest, null, reward);
            }
            else if (type == "Deliver")
            {
                reward = num.Next(100, 300);
                string inst = $@"
            #  I have a package here to be delivered to a client. 
            #    You will need to deliver that package to the 
            #    {dest.name} in {randLoc.name} and I'm 
            #          offering to pay you ${reward} for the 
            #           successful delivery of the package.   ";
                availQuest = new Quest("Deliver", inst
                , Program.newGame.newPlayer.currentLocation, dest, new QI("Package"),reward);
            }
            return availQuest;
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