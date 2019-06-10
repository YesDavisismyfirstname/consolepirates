using System.Collections.Generic;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using consolepirates.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace consolepirates.Models
{
    abstract public class Location
    {
        public string name;
        public List<Action> actions { get; set; }
        public string locationArt;
        public string description;
        public int lastVisited;
        public DateTime dateVisited;
        public List<Location> availableLocations;
        public void displayInfo(string errorMessage = "")
        {
            Player currentPlayer = Program.newGame.newPlayer;
            long ticks = new DateTime(2021, 04, 28,
            new CultureInfo("en-US", false).Calendar).Ticks;
            this.dateVisited = new DateTime(ticks);
            string displayDate = this.dateVisited.AddDays(lastVisited).ToString("MMMM dd, yyyy");
            string currentDate = this.dateVisited.AddDays(currentPlayer.travelDays).ToString("MMMM dd, yyyy");
            System.Console.Clear();
            // System.Console.WriteLine("Trying to display Options");
            System.Console.Write($@"
            #################################################################
            #                                                               #
            {locationArt}                  
            {description}
            #                                                               #
            #             Pick from the following options                   #
            #      by typing the option number or the full name             #
            #################################################################
             Ship: {currentPlayer.currentShip.name} Gold: {currentPlayer.gold}, 
             Cargo Space: {currentPlayer.currentShip.currentSpace}/{currentPlayer.currentShip.cargoSpace}
             Current Date: {currentDate}, Days Traveled: {currentPlayer.travelDays}
             Last Visited: {displayDate}, Days Elapsed: {currentPlayer.travelDays - lastVisited}
             
             
                    {errorMessage.PadRight(52)}
            ");
            for (int j = 0; j < actions.Count; j++)
            {
                if (j == 2)
                {
                    System.Console.Write(@"           
            ");
                }
                System.Console.Write(
$@" {j} - {actions[j].name} |"
            );
            }
            System.Console.Write(@"
            What will you do?");
            string answer = System.Console.ReadLine();
            Action choice = null;
            for (int i = 0; i < actions.Count; i++)
            {
                if (answer == actions[i].name || answer == i.ToString())
                {
                    choice = actions[i];
                }
            }
            // System.Console.WriteLine(choice.name);
            if (choice == null)
            {
                currentPlayer.currentLocation.displayInfo("That is not a valid selection");
            }
            else
            {
                choice.Act();
            }
            currentPlayer.currentLocation.displayInfo();
        }
    }
    public class WorldMap : Location, IEventable
    {

        // public List<Location> locations;
        public WorldMap()
        {
            City Tortuga = new City("Tortuga",
          @"#                                                               #
            #  How you managed to sail to this city you are not sure.       #
            # Your ship glides past a herd of Kangaroo before docking       #
            # at the busy port. You prepare to depart your ship and         #
            #               begin your business                             #",
          @"#                   _      *Bar            _   *Store           #     
            #    ____________ .' '.    _____/----/-\ .' './========\        #
            #   //// ////// /V_.-._\  |.-.-.|===| _ |-----| u    u |        #
            #  // /// // ///==\ u |.  || | ||===||||| |T| |   ||   | .      #
            # ///////-\////====\==|:::::::::::::::::::::::::::::::::::      #
            # |----/\u |--|++++|..|'''''''''''::::::::::::::''''''''''      #
            # |u u|u | |u ||||||..|              '::::::::'                 #
            # |===|  |u|==|++++|==|              .::::::::.                 #
            # |u u|u | |u ||HH||         \|/    .::::::::::.                #
            # |===|_.|u|_.|+HH+|_              .::::::::::::.               #
            #                        |       .:::::;;;:::;;:::.             #
            #       *ShipYard                .::::::;;:::::;;:::.           #
            #  __|__ |___| |\              .:::::;;;::::::;;;:::.           #     
            #  |o__| |___| | \            .:::::;;;:::::::;;;::::.          #
            #  |___| |___| |o \          .:::::;;:::::::::;;;:::::.         #
            # _|___| |___| |__o\        .:::::;;;::::::::::;;;:::::.        #
            #/...\_____|___|____\_/~~~~  .:::::;;;::::::::::::;;;::::       #
            #\   o * o * * o o  /  ~~  .::::::;;  World Map  ;;;::::::      #
            #~~~~~~~~~~    ~~~~~~~~~~~~ ;;:::::::.    |    ::;;;::::::      #
            #~~~~~   ~~~~~~~~~~   ~~~~~~::::;;;:::::::V:::::::;;;:::::      #
            #################################################################"
            , new string[3] { "Tortuga Emporium", "The Tortuga Docks", "Obama's Grill and bar" });
            City Darwin = new City("Darwin",
          @"#                                                               #
            #  As you pull into port, the City of Darwin rises above        #
            #   you in a series of ramparts and terraces. You hope          #
            #        the populace is as impressive as their city.           #
            #                                                               #",
          @"#                                                               #
            #                      X_x                                      #
            #                      / \\\                                    #
            #                      |n| |                                    #
            #                    )(|_|-'X                                   #
            #                   /  \\Y// \                                  #
            #                   |A | | |A|                                  #
            #                   |  | | |_|                                  #
            #            )(__X,,|__|/++;;;-,)(,                             #
            #           /  \\\;;;;;;;;;;;;/    \                            #
            #           |A | |            | U  |                            #
            #         )_|  | |____)-----( |    |                            #                 
            #        ///|__|-'////       \|___)=(__X                        #
            #       /////////////         \///   \/ \                       #
            #       |           |  U    U |//     \u|                       #
            #       |   )_,-,___|_)=(     | |  U  |_|_X                     #    
            #       |  ///   \\|//   \    | |  __ |/// \    *ShipYard       #
            #     )_')(//     \Y/     >---)=( /  \|  | |        /|          #
            #    //// ,\ u   u |   u /*Store \|  ||__|A|       / |          #
            #   |  | .. |*Bar  |    ///// ,-, \__||------  ~  /__|__        #
            #---'--'_::_|__[]__'----| u | | | |--------- ~~ \--------/      #
            #       ------------    |___|_|_|_|-       ~~  ~~~~~~~~~~~~     #
            #################################################################",
            new string[3] { "Darwin Feed and Seed", "Darwin's Warf", "Origin of the Species Bar" });
            City Brisbane = new City("Brisbane",
          @"#                                                               #
            #  Brisbane is a quaint little town which hosts a variety       #
            #   of stores. It's home to the famous Brismart, where          #
            #        you expect to score a good deal on some cargo          #
            #           But maybe the Bar is more up you alley...           #",
          @"#                        _,__      .:                           #            
            #                \  |  /         ___________                    #
            # ____________  \ \_# /         |  ___      |     _________     #
            #|            |  \  #/          | |   |     |    | = = = =      #
            #| |   |   |  |   \\#           | |`v'|     |    |  *Bar        #
            #|            |    \#  //       |  --- ___  |    | |  || |      #
            #| |   |   |  |     #_*ShipYard |     |   | |    |              #
            #|            |  \\ #_/_______  |     |   | |    | |  || |      #
            #| |   |   |  |   \\# /_____/ \ |      ---  |    |              #
            #|            |    \# |+ ++|  | |  |~~~~~~| |    | |  || |      #
            #|  *Store    | ~~ \# |+ ++|  | |  |~~~~~~| |    | |  || |      #
            #|    (~~~~~) |~~~~~#~| H  |_ |~|  | |||| | |~~~~|              #
            #|    ( ||| ) |     # ~~~~~~    |  | |||| | |    | |||||||      #
            #~~~~~~~~~~~~~________/  /_____ |  | |||| | |    | |||||||      #
            #                                                               #
            #################################################################",
            new string[3] { "Brismart", "Port of Brisbane", "Breezeblocks Pub" });
            City Melbourne = new City("Melbourne",
          @"#                                                               #
            #  Melbourn was modeled on the city of Brisbane but does        #
            #   not appear to share its charm. You are pretty certain       #
            #        that everyone is giving you a sinister look            #
            #    You better offload your cargo and leave quickly...         #",
          @"#                                                               #            
            #                                ___________                    #
            #                               |  ___      |     _________     #
            #                               | |   |     |    | = = = = |    #
            # ____________                  | |`v'|     |    |  *Bar   |    #
            #|            |                 |  --- ___  |    | |  || | |    #
            #| |   |   |  |  *ShipYard      |     |   | |    |         |    #
            #|            |   _______       |     |   | |    | |  || | |    #
            #| |   |   |  |  /_____/ \      |      ---  |    |         |    #
            #|            |  |+ ++|  |      |  |~~~~~~| |    | |  || | |    #
            #|  *Store    | ~|+ ++|  | ~~~~ |  |~~~~~~| |    | |  || | |    #
            #|    (~~~~~) |~~| H  |_ |~~~~  |  | |||| | |~~~~|         |    #
            #|    ( ||| ) |   /  /          |  | |||| | |    | ||||||| |    #
            #~~~~~~~~~~~~~___/  /__________ |  | |||| | |    | ||||||| |    #
            #                                                               #
            #################################################################",
            new string[3] { "Melbourn Wholesale", "Port of Brisbane", "The Bourne Thirst" });
            City Perth = new City("Perth",
          @"#                                                               #
            #  Perth. The newly designated captital of Aussieland.          #
            #   You stare up in wonder at the freshly constructed           #
            #        palace and the multitudes which swarm the              #
            #   grounds. With this many officials you are bound to          #
            #                   pick up some work!                          #",
          @"#                                                               #
            #          )\         O_._._._A_._._._O         /(              #
            #           \`--.___,'=================`.___,--'/               #
            #            \`--._.__                 __._,--'/                #
            #              \  ,. l`~~~~~~~~~~~~~~~'l ,.  /                  #
            #  __            \||(_)!_!_!_.-._!_!_!(_)||/            __      #
            #  \\`-.__        ||_|____!!_|;|_!!____|_||        __,-'//      #
            #   \\    `==---='-----------'='-----------`=---=='    //       #
            #   | `--.                                         ,--' |       #
            #    \  ,.`~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~',.  /        #
            #      \||  ____,-------._,-------._,-------.____  ||/          #
            #       ||\|___!`======='!`======='!`======='!___|/||           #
            #           ---||--------||-| | |-!!--------||---| ||           #
            # ____O_ll_lO_____O_____O|| |'|'| ||O_____O_____Ol_ll_O___      #
            #o o H o o H o o H o o |-----------| o o H o o H o o H o        #
            #____H_____H_____H____O =========== O____H_____H_____H____      #
            #                    /|=============|\                          #
            #################################################################
",

            new string[3] { "Perth and Sons", "Perth Marina", "Applebees" });
            availableLocations = new List<Location>();
            actions = new List<Action>();
            // System.Console.WriteLine("Building World");
            name = "World Map";

            locationArt =
@"            #################################################################  
            #                          _,__      .:                         #
            #                  Darwin <*  /      | \                        #
            #                    .-./     |.    .:  :,                      #
            #                  /           '-._/     \_                     #
            #                  /                '       \                   #
            #                ..'                         *: Brisbane        #
            #             .-'           *Tortuga          ;                 #
            #              |                               |                #
            #              \                              /                 #
            #               |                             /                 #
            #          Perth  \*        __.--._          /                  #
            #                  \     _.'       \:.       |                  #
            #                  >__,-'             \_/*_.-'                  #
            #                                      Melbourne                #
            #                                      :--,                     #
            #                                                               #
            #################################################################";
            availableLocations.Add(Tortuga);
            availableLocations.Add(Brisbane);
            availableLocations.Add(Melbourne);
            availableLocations.Add(Darwin);
            availableLocations.Add(Perth);
            description =
          @"#                  The world is open to you!                    #";
            // actions = new List<Action>();
            foreach (Location loc in availableLocations)
            {
                actions.Add(new Travel(loc.name));
                System.Console.WriteLine("adding action");
            }
            // actions.Add(new Travel(availableLocations))
            // cityList = new List<City>();
        }
    }
    public class City : Location, IEventable
    {
        public City(string name, string description, string art, string[] locations)
        {
            lastVisited = 0;
            System.Console.WriteLine($"Building City {name}");
            this.name = name;
            this.description = description;
            this.locationArt = art;
            this.actions = new List<Action>();
            this.availableLocations = new List<Location>()
            {
            };
            availableLocations.Add(new Shop(locations[0], name));
            availableLocations.Add(new Shipyard(locations[1], name));
            availableLocations.Add(new Bar(locations[2], name));
            foreach (Location places in availableLocations)
            {
                this.actions.Add(new Travel(places.name));
            }
        }
    }
    public class Shop : Location, IEventable
    {
        public List<Loot> Inventory;
        public string returnCity;
        public Shop(string name, string cityname)
        {
            // System.Console.WriteLine($"Building shop {name}");
            this.returnCity = cityname;
            this.locationArt =
         $@"#                 ||                       ||               //|  #
            # ________________||    {name.PadRight(19)}||______________//||  #
            #|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_||/|/||/  #  
            #|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|||/||/|  #
            #|_|_|_|_|_|_|_|_|     _      _     |_|_|_|_|_|_|_|_|_|_|/||/|/  #
            #|Flowers! Cacti!|    (_)    (_)    |Trees and Plants |_|/|/|/|  #
            #|.    Ferns!    |__________________|   Sold Here     |_||/|/|/  #
            #|*`.            |_|      ||      |_|     _/\_        |_|/|/|/|  #
            #| S `.          |_| llup || push |_|    / || \       |_||/|/|/  #
            #|`. A `.        |_| tuo  ||  in  |_|   | /||\ |      |_|/|/|/|  #
            #|  `. L `.      |_|     [||]     |_|   /__||__\      |_||/|/|/  #
            #|    `. E `.    |_|      ||      |_|     /  \        |_|/|/|/   #
            #|______`__*_`___|_|      ||      |_|_____\  /________|_||/|/    #
            #|_|_|_|_|_|_|_|_|_|______||______|_|_|_|_|_|_|_|_|_|_|_|/|/     #
            #|_|_|_|_|_|_|_|_|_|______||______|_|_|_|_|_|_|_|_|_|_|_||/      #
            #   /     /     /     /     /     /     /     /     /     /      #
            #__/_____/_____/_____/_____/_____/_____/_____/_____/_____/_      #
            ##################################################################";
            this.availableLocations = new List<Location>();
            this.Inventory = new List<Loot> {
                new Loot(0,"Fern",
@"A very common plant located across the world,
who knows why they're even worth anything.",
                10,1,50,300),
                new Loot(1,"Orchid",
@"A good looking plant that enjoys the simplier things
in life, like Pina Coladas and its roots in the dirt.",
                20,1,50,200),
                new Loot(2,"Sunflower",
@"A shining plant that will help you
defend your lawn from unwanted guests.",
            30,1,50,150),
            new Loot(3,"Coconut",
@"Not actually a nut, technically it's a drupe
which is a fruit with fleshiness on the middle and 
a hard shell on the outside, but you already knew that.",
            100,2,20,75),
            new Loot(4,"Redwood",
@"Tallest Species of tree in the world. 
It Grows in California so there is some confusion as 
to how it became available in these markets",
            250,3,10,25),
            new Loot(5,"Papaya",
@"A very healthy plant that most moms would
advise you to eat, but you're still not going too.",
            500,3,10,20),
            new Loot(6,"Golf Ball Cactus",
@"A very rare and endagered plant,
its home habitat is the hot desserts of Mexico",
            1500,4,5,10),
            };
            this.name = name;
            // System.Console.WriteLine("Building Shop");
            description =
            @"#              Buy and Sell your Cargo Here.                    #";
            actions = new List<Action>(){
                new Purchase(Inventory),
                new Sell(Inventory),
                new Travel(returnCity)
            };

        }
    }
    public class Shipyard : Location, IEventable
    {
        public string returnCity;
        public string ShipAvailable;

        public Shipyard(string name, string returnCity)
        {
            this.name = name;
            this.returnCity = returnCity;
            this.availableLocations = new List<Location>();
            
            actions = new List<Action>();
            resetActions();
            
            description =
         $@"#################################################################
            #      The Shipyard {ShipAvailable.PadRight(44)}#
            #       there are some helpful mechanics to help                #
            #      repair your ship if needed. You can also buy             #
            #              upgrades for your ship here.                     #";
            this.locationArt =
          @"#        .n.                     |                              #
            #       /___\          _.---.  \ _ /                            #
            #       [|||]         (_._ ) )--;_) =-                          #
            #       [___]           '---'.__,' \                            #
            #       }-=-{                    |                              #
            #       |-' |                                                   #   
            #       |.-'|               p                                   #   
            #~^=~^~-|_.-|~^-~^~ ~^~ -^~^|\ ~^-~^~-~^-~^~-~^-~^~-~^-~^~~-~^~~#
            #^  .=. | _.|__  ^       ~ /| \                          ~~~    #
            #~ /:. \|' _|_/\    ~     /_|__\  ^      ~      ~~~             #
            #-/::.  |   |''|-._     ^  ~~~~                    ~~~~~~       #
            #`===-'-----'''`  '-.              ~         ~~~                #
            #                __.-'      ^                         ~~~       # 
            #################################################################
";          
        }
        public void resetActions()
        {
            Ship newShip;
            if(actions.Count > 0){
            actions.RemoveRange(0,actions.Count);
            }
            int checkB = Program.rand.Next(1, 10);
            int check = Program.rand.Next(1, 4);
            // System.Console.WriteLine(checkB);
            // System.Console.WriteLine(check);
            // System.Console.ReadLine();
            if (checkB == 9)
            {
                newShip = new Battleship("Battleship", 1);
            }
            else if (check == 1)
            {
                newShip = new Hauler("Hauler", 1);
            }
            else if (check == 2)
            {
                newShip = new Fighter("Fighter", 1);
            } else {
                newShip = null;
            }
            if(newShip != null){
                actions.Add(new PurchaseShip(newShip));
                ShipAvailable = $"has a new {newShip.name} for sale and";
            } else {
                ShipAvailable = "doesn't have any ships for sale but";
            }
            actions.Add(new UpgradeShip());
            actions.Add(new Travel(returnCity));
        }
    }
    public class Bar : Location, IEventable
    {
        public string returnCity;
        public string ShipAvailable;

        public Bar(string name, string returnCity)
        {
            this.name = name;
            this.returnCity = returnCity;
            this.availableLocations = new List<Location>();
            actions = new List<Action>();
            actions.Add(new Travel(returnCity));
            actions.Add(new Recruit());
            actions.Add(new Barkeep());
            description =
         $@"#################################################################
            #      The Bar teams with various patrons. The Barkeep          #
            #   can usually provide good tips on where trading is hot       #
            #          or provide a quick transport job. You can            #
            #              also hire additional crew here.                  #";
            this.locationArt =
         $@"#.======================================.                       #
            #| ___ ___ ___               _   _   _  |                       #
            #| \_/ \_/ \_/ C|||C|||C||| |-| |-| |-| |                       #
            #| _|_ _|_ _|_  ||| ||| ||| |_| |_| |_| |                       #
            # '===================================== ,sSSSs                 #
            #         {name.PadRight(23)}       SSS vv(                 #
            #       .:.                              SSq/ =/  \~/           #
            #      C|||'                              SS _(_  _Y_           #
            #    ___|||______________________________SS/ _)_) /.-           #
            #   [____________________________________] \   /\//             #
            #    |   ____    ____    ____    ____   | \|==(\_/              #
            #    |  (____)  (____)  (____)  (____)  | (/   ;                #
            #    |  |    |  |    |  |    |  |    |  | |____|                #
            #    |  |    |  |    |  |    |  |    |  |  \  |\                #
            #    |  |    |  |    |  |    |  |    |  |   ) ) )               #
            #    |  |____|  |____|  |____|  |____|  |  (  |/                #
            #    |  I====I  I====I  I====I  I====I  |  /\ |                 #
            #       |    |  |    |  |    |  |    |  | /.(=\                 #
            #                                           Y\_\                #
            #################################################################
";          
        
        
            
        }
    }
}