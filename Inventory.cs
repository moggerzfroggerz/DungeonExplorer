using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Inventory
    {
        // Initialises the name and health attribute for the player. 
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        // The string below adds the item that the user found to their inventory. 
        public void FindItems(string item)
        {
        inventory.Add(item);
        }
        // The string below returns all the items in the player's backpack (inventory). 
        public string Backpack()
        {
            return string.Join(", ", inventory);
        }
        // The boolean (true or false data type) value below will return true if the user has something in their inventory and false if they don't. 
        // This can be called in the main program to determine whether the user has searched for items or not. 
        public bool FindItems()
        {
            if (inventory.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}