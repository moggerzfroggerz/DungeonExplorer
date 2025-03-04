using System;
using System.ComponentModel;
using System.Media;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Monster monster;

        public Game()
        {
            // Initialize the game with one room and one player
            currentRoom = new Room("You enter a dim room and are faced with a huge slug-like monster! You notice a shimmering item on the floor...");
            player = new Player("Player", 100);
            monster = new Monster("ScarySlug", 50);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            Console.WriteLine(currentRoom.RoomDescription());
            while (playing == true)
            {
                while (monster.getHealth() > 0)
                {

                    Console.WriteLine($"Your current health is: {player.showHealth()}");
                    Console.WriteLine($"Scary slug current health is: {monster.getHealth()}");
                    string input = this.ExplorerInput();
                    if (input == ("d"))
                    {
                        Console.WriteLine(monster.damage());
                    }
                    else if (input == ("s") && player.FindItems() == false)
                    {
                        string PlayerInv = currentRoom.RoomItems();
                        player.FindItems(PlayerInv);
                            Console.WriteLine($"On the floor, there was {PlayerInv} and you picked it up.");
                    }
                    else if (input == ("b") && player.FindItems() == true)
                    {
                        Console.WriteLine($"Your backpack contains: {player.Backpack()}");
                    }
                    else if (input == ("e"))
                    {
                        Console.WriteLine(player.Eat());
                    }
              
                    else
                    {
                        Console.WriteLine("Please input a letter displayed above.");
                    }
                    playing = false;
                }
                Console.WriteLine("The monster was killed.");

            }



        }
        private string ExplorerInput()
        {
            Console.WriteLine("Make your choice...");
            Console.WriteLine("Enter d to deal damage");
            Console.WriteLine("Enter e to eat food and regain health");
            if (player.FindItems() == false)
            {
                Console.WriteLine("Enter s to search for items");
            }
            if (player.FindItems() == true)
            {
                Console.WriteLine("Enter b to view the backpack contents");
            }
            string input = Console.ReadLine();
            return input;
        }
    }
}