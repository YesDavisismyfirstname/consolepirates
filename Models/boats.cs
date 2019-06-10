using System.Collections.Generic;
using System;
namespace consolepirates.Models
{
    abstract public class Ship
    {
        public string name;
        public string shipArt = "";
        public int hullHealth;
        public int maxHullHealth;
        public int cargoSpace;
        public int maxCargoSpace;
        public int currentSpace;
        public List<Loot> currentCargo;
        public int cannons;
        public int cannonCapacity;
        public int sailors;
        public int maxSailors;
        public int price;
        public double upgradeMult;
        public Ship(string name, double mult = 0)
        {
            this.currentCargo = new List<Loot> {
                new Loot(0,"Fern",
@"A very common plant located across the world,
who knows why they're even worth anything.",
                0,50),
                new Loot(1,"Orchid",
@"A good looking plant that enjoys the simplier things
in life, like Pina Coladas and its roots in the dirt.",
                0,50),
                new Loot(2,"Sunflower",
@"A shining plant that will help you
defend your lawn from unwanted guests.",
            0,40),
            new Loot(3,"Coconut",
@"Not actually a nut, technically it's a drupe
which is a fruit with fleshiness on the middle and 
a hard shell on the outside, but you already knew that.",
            0,40),
            new Loot(4,"Redwood",
@"Tallest Species of tree in the world. 
It Grows in California so there is some confusion as 
to how it became available in these markets",
            0,25),
            new Loot(5,"Papaya",
@"A very healthy plant that most moms would
advise you to eat, but you're still not going too.",
            0,20),
            new Loot(6,"Golf Ball Cactus",
@"A very rare and endagered plant,
its home habitat is the hot desserts of Mexico",
            0,10),
            };
            currentSpace = 0;
        }
        
        public void randomEquipment(int mincan, int minsailor, int minhp, int mincargo)
        {
            cannons = Program.rand.Next(mincan, cannonCapacity);
            sailors = Program.rand.Next(minsailor, maxSailors);
            hullHealth = Program.rand.Next(minhp, maxHullHealth);
            cargoSpace = Program.rand.Next(mincargo, maxCargoSpace);
        }
        public void randomInventory()
        {
            int temp = Program.rand.Next(0, cargoSpace);
            int qty = 0;
            // if(currentCargo.Count < temp) {
            //     qty = Program.rand.Next(0,30);
            //     if (qty>0) {
            //     currentCargo.Add(new Fern(qty));
            //     };
            // };
            // if(currentCargo.Count < temp) {
            //     qty = Program.rand.Next(0,20);
            //     if (qty>0) {
            //     currentCargo.Add(new Orchid(qty));
            //     };
            // };
            // if(currentCargo.Count < temp) {
            //     qty = Program.rand.Next(0,20);
            //     if (qty>0) {
            //     currentCargo.Add(new Sunflower(qty));
            //     };
            // };
            // if(currentCargo.Count < temp) {
            //     qty = Program.rand.Next(0,15);
            //     if (qty>0) {
            //     currentCargo.Add(new Coconut(qty));
            //     };
            // };
            // if(currentCargo.Count < temp) {
            //     qty = Program.rand.Next(0,10);
            //     if (qty>0) {
            //     currentCargo.Add(new Redwood(qty));
            //     };
            // };
            // if(currentCargo.Count < temp) {
            //     qty = Program.rand.Next(0,10);
            //     if (qty>0) {
            //     currentCargo.Add(new Papaya(qty));
            //     };
            // };
            // if(currentCargo.Count < temp) {
            //     qty = Program.rand.Next(0,10);
            //     if (qty>0) {
            //     currentCargo.Add(new Cactus(qty));
            //     };
            // };
        }
    }

    public class Skipper : Ship
    {
        public Skipper(string name, double mult = 0) : base(name, mult)
        {
            System.Console.WriteLine("Building Ship");
            shipArt = @"
            ############################################################
            #                                                          #
            #                      v                                   #
            #               v                           v              #
            #                   v        /|        v                   #
            #                           / |                            #
            #     ~~~~~~~~~~~~~        /__|__      ~~~~~~~~            #
            #        ~~              \--------/                        #
            #                ~~~~~~~~~`~~~~~~'~~~~~~        ~~~        #
            #      ~~~~~                          ~~~~~                #
            ############################################################
            ";
            this.name = name;
            // currentCargo = new List<Loot>();
            cargoSpace = 10;
            maxCargoSpace = 15;
            cannons = 2;
            cannonCapacity = 4;
            sailors = 5;
            maxSailors = 10;
            hullHealth = 10;
            maxHullHealth = 15;
            price = 0;
            upgradeMult = 1;
        }
    }
    public class Hauler : Ship
    {
        public Hauler(string name, double mult = 1) : base(name, mult)
        {
            shipArt = @"
            ############################################################
            #                                                          #
            #                  __|__ |___| |\                          #
            #                  |o__| |___| | \                         #
            #                  |___| |___| |o \                        #
            #                 _|___| |___| |__o\                       #
            #                /...\_____|___|____\_/  ~~~~~~     ~~~~~~~#
            #   ~~~~~~~      \   o * o * * o o  /                      #
            #                ~~~~~~~~~`~~~~~~'~~~~~~        ~~~        #
            #      ~~~~~                          ~~~~~                #
            ############################################################
";
            this.name = name;
            // currentCargo = new List<Loot>();
            cargoSpace = 20;
            maxCargoSpace = 30;
            cannons = 3;
            cannonCapacity = 5;
            sailors = 15;
            maxSailors = 25;
            hullHealth = 25;
            maxHullHealth = 35;
            price = 10000;
            upgradeMult = 1.6;
        }
    }
    public class Fighter : Ship
    {
        public Fighter(string name, double mult = 1) : base(name, mult)
        {
            shipArt = @"
            ############################################################
            #                                                          #
            #                            /|~~~                         #
            #                          /  | \                          #
            #                        /    |  \                         #
            #                      /      |   \                        #
            #                    /________|____\                       #
            #   ~~~~~~~~~      \===o==o==o|=o==o==o=/ ~~~       ~~~~~~~#
            #                ~~~~~~~~~`~~~~~~'~~~~~~        ~~~        #
            #      ~~~~~                          ~~~~~                #
            ############################################################
            ";
            this.name = name;
            // currentCargo = new List<Loot>();
            cargoSpace = 12;
            maxCargoSpace = 15;
            cannons = 5;
            cannonCapacity = 8;
            sailors = 10;
            maxSailors = 20;
            hullHealth = 20;
            maxHullHealth = 25;
            price = 8000;
            upgradeMult = 1.5;
        }
    }
    public class Battleship : Ship
    {
        public Battleship(string name, double mult = 1) : base(name, mult)
        {
            shipArt = @"
            ############################################################
            #                                                          #
            #                  |\    |\       |\            v          #
            #        v        /|o\   |_\     /| \                      #
            #    v           / |__\  |__\   / |o \    v                #
            #               /__|___\ |___\ /__|__o\                    #
            #                /...\___|________|_______  ~~~     ~~~~~~~#
            #   ~~~~~~~      \   o * o * * o o  *o /                   #
            #                ~~~~~~~~~`~~~~~~'~~~~~~        ~~~        #
            #      ~~~~~                          ~~~~~                #
            ############################################################
";
            this.name = name;
            // currentCargo = new List<Loot>();
            cargoSpace = 30;
            maxCargoSpace = 40;
            cannons = 6;
            cannonCapacity = 12;
            sailors = 30;
            maxSailors = 50;
            hullHealth = 60;
            maxHullHealth = 100;
            price = 40000;
            upgradeMult = 2;
        }
    }
}