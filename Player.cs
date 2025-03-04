using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void FindItems(string item)
        {
        inventory.Add(item);
        }
        public string Backpack()
        {
            return string.Join(", ", inventory);
        }
        public int showHealth()
        {
            return this.Health;
        }
        public string Eat()
        {
            Console.WriteLine("You ate some bread and have healed 40 health.");
            this.Health = this.Health + 40;
            return $"Your health is: {this.Health}";
        }
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