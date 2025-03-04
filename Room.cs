using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> inventory = new List<string>();

        public Room(string description)
        {
            this.description = description;
            this.inventory.Add("a key.");
        }

        public string RoomDescription()
        {
            return description;
        }
        public string RoomItems()
        {
            return ("a key");
        }
    }
}