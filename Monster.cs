using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Monster
    {
        private int Health { get; set; }
        private string Name { get; set; }
        public Monster(string Name, int Health)
        {
            this.Name = Name;
            this.Health = Health;
        }
        public int getHealth()
        {
            return this.Health;
        }
        public string damage()
        {
            this.Health = this.Health - 5;
            return $"You hit the monster as hard as you could... It now has {this.Health} health.";
        }
        public void Heal()
        {
            Health = Health + 10;
        }
    }
}
