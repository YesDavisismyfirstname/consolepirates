using System.Collections.Generic;
using System;
namespace consolepirates.Models
{
    abstract public class Ship
    {
        public int cargoSpace;
        public int maxCargoSpace;
        public string name;
        public int cannons;
        public int cannonCapacity;
        public int sailors;
        public int maxSailors;
        public int hullHealth;
        public int maxHullHealth;
        public List<ILootable> currentCargo;
        public string shipArt = "";
        
        public void displayShip(string ship){
            System.Console.Write(shipArt);
        }
        public void randomEquipment(int mincan, int minsailor,int minhp, int mincargo){
            cannons = Program.rand.Next(mincan,cannonCapacity);
            sailors = Program.rand.Next(minsailor, maxSailors);
            hullHealth = Program.rand.Next(minhp, maxHullHealth);
            cargoSpace = Program.rand.Next(mincargo, maxCargoSpace);
        }
        public void randomInventory(){
            int temp = Program.rand.Next(0,cargoSpace);
            int qty = 0;
            if(currentCargo.Count < temp) {
                qty = Program.rand.Next(0,30);
                if (qty>0) {
                currentCargo.Add(new Fern(qty));
                }
            }
            if(currentCargo.Count < temp) {
                qty = Program.rand.Next(0,20);
                if (qty>0) {
                currentCargo.Add(new Orchid(qty));
                }
            }
            if(currentCargo.Count < temp) {
                qty = Program.rand.Next(0,20);
                if (qty>0) {
                currentCargo.Add(new Sunflower(qty));
                }
            }
            if(currentCargo.Count < temp) {
                qty = Program.rand.Next(0,15);
                if (qty>0) {
                currentCargo.Add(new Coconut(qty));
                }
            }
            if(currentCargo.Count < temp) {
                qty = Program.rand.Next(0,10);
                if (qty>0) {
                currentCargo.Add(new Redwood(qty));
                }
            }
            if(currentCargo.Count < temp) {
                qty = Program.rand.Next(0,10);
                if (qty>0) {
                currentCargo.Add(new Papaya(qty));
                }
            }
            if(currentCargo.Count < temp) {
                qty = Program.rand.Next(0,10);
                if (qty>0) {
                currentCargo.Add(new Cactus(qty));
                }
            }
        }
    }

    public class Skipper : Ship
    {
        public Skipper(string name) {
            shipArt = @"

            /|
           / |    
          /__|__
        \--------/
~~~~~~~~~`~~~~~~'~~~~~~
            ";
        this.name = name;   
        currentCargo = new List<ILootable>();
        cargoSpace = 10;
        maxCargoSpace = 15;
        cannons = 2;
        cannonCapacity = 4;
        sailors = 5;
        maxSailors = 10;
        hullHealth = 10;
        maxHullHealth = 15;
        }
    }
    public class Hauler : Ship
    {
        public Hauler(string name) {
            shipArt = @"

    __|__ |___| |\
    |o__| |___| | \
    |___| |___| |o \
   _|___| |___| |__o\
  /...\_____|___|____\_/
  \   o * o * * o o  /
~~~~~~~~~~~~~~~~~~~~~~~~~~
            ";
        this.name = name;   
        currentCargo = new List<ILootable>();
        cargoSpace = 20;
        maxCargoSpace = 30;
        cannons = 3;
        cannonCapacity = 5;
        sailors = 15;
        maxSailors = 25;
        hullHealth = 25;
        maxHullHealth = 35;
        }
    }
    public class Fighter : Ship
    {
        public Fighter(string name) {
            shipArt = @"
             /|~~~   
           /  | \     
         /    |  \    
       /      |   \   
     /________|____\  
   \===o==o==o|=o==o==o=/  
~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ";
        this.name = name;   
        currentCargo = new List<ILootable>();
        cargoSpace = 12;
        maxCargoSpace = 15;
        cannons = 5;
        cannonCapacity = 8;
        sailors = 10;
        maxSailors = 20;
        hullHealth = 20;
        maxHullHealth = 25;
        }
    }
    public class Nautilous : Ship
    {
        public Nautilous(string name) {
            shipArt = @"
                     | \
                     '.|
     _-   _-    _-  _-||    _-    _-  _-   _-    _-    _-
       _-    _-   - __||___    _-       _-    _-    _-
    _-   _-    _-  |   _   |       _-   _-    _-
      _-    _-    /_) (_) (_\        _-    _-       _-
              _.-'           `-._      ________       _-
        _..--`                   `-..'       .'
    _.-'  o/o                     o/o`-..__.'        ~  ~
 .-'      o|o                     o|o      `.._.  // ~  ~
 `-._     o|o                     o|o        |||<|||~  ~
     `-.__o\o                     o|o       .'-'  \\ ~  ~
         `-.______________________\_...-``'.       ~  ~
                                    `._______`.
            ";
        this.name = name;   
        currentCargo = new List<ILootable>();
        cargoSpace = 30;
        maxCargoSpace = 35;
        cannons = 10;
        cannonCapacity = 15;
        sailors = 30;
        maxSailors = 35;
        hullHealth = 100;
        maxHullHealth = 100;
        }
    }
}