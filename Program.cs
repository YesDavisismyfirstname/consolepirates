using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using consolepirates.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace consolepirates
{
    public class Program
    {
        public static Random rand;
        public static Game newGame;
        public static Location world;
        // public static List<ILootable> availableLoot; 
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
            Program.CreateGame();

        }
        public static void CreateGame()
        {
            // availableLoot = new List<ILootable>(){
            //     Fern(1),
            //     new Orchid(1),
            // };
            System.Console.Clear();
            Program.rand = new Random();
            System.Console.Write(@"
            ############################################################
            #                                                          #
            #                Welcome to Console Pirates!               #
            #                                                          #
            #     Trade, raid and quest in this seafaring adventure    #
            #                                                          #
            ############################################################


            Please provide your name:
            ");
            string name = System.Console.ReadLine();
            System.Console.Clear();
            Console.Write($@"
            ############################################################
            #                                                          #
            #                   Welcome Captain!                       #
            #                                                          #
            #        You are the proud owner of a small Skipper!       #
            #                             /|                           #
            #                            / |                           #
            #                           /__|__                         #
            #                          \--------/                      #
            #                  ~~~~~~~~~`~~~~~~'~~~~~~                 #
            #            Please provide a name for your ship:          #
            #                                                          #
            ############################################################
            ");
            string shipname = Console.ReadLine();

            
            Program.newGame = new Game(name, shipname);
            
            foreach (Location city in Program.world.availableLocations)
            {
                foreach (Location shop in city.availableLocations)
                {
                    shop.availableLocations.Add(city);
                }
                city.availableLocations.Add(Program.world);
                city.actions.Add(new Travel(world.name));
            }
            Console.Clear();
            Console.Write(world.locationArt);
                        Console.Write($@"
            #################################################################
            #                                                               #
            #            Welcome to AussieLand! The World awaits!           #
            #                                                               #
            #################################################################
            ");
            System.Console.WriteLine("Press any key to continue!");
            Console.ReadLine();
            world.actions[0].Act();
            newGame.newPlayer.currentLocation.displayInfo();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
