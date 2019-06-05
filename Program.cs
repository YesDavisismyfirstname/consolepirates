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
        public static Game newGame;
        public static Location world;
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
            Program.CreateGame();
            
        }
        public static void CreateGame()
        {   
            System.Console.Write( @"
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

            Console.Write($@"
            ############################################################
            #                                                          #
            #                   Welcome Captain!                       #
            #                                                          #
            #        You are the proud owner of a small Skipper!       #
            #            Please provide a name for your ship:          #
            #                                                          #
            ############################################################
            ");
            string shipname = Console.ReadLine();
            Console.Write($@"
            ############################################################
            #                                                          #
            #                   Your Adventure Begins!                 #
            #                                                          #
            ############################################################
            ");
            newGame = new Game(name,shipname);
            newGame.Action("travel","Tortuga");
        }
    
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
