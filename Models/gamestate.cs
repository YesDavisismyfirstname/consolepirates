using System.Collections.Generic;
namespace consolepirates.Models
{
    public class Game
    {
        public Player newPlayer;
        
        public Game(string newname , string startingship)
        {
            newPlayer = new Player(newname,startingship);
        }

    }
    public interface IEventable
    {
        List<Action> actions {get;set;}
    }
    public class Action
    {
        public string name;
        public string description;
        
    }

}