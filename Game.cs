using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Media;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;

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
                        Console.WriteLine("Enter u to use the key to unlock a door or r to return it to the backpack.");
                        string secondInput = Console.ReadLine();
                        if (secondInput == ("r")) 
                        {
                            Console.WriteLine("Key has been returned to backpack");
                        }
                        else if (secondInput == ("u")) 
                        {
                            Console.WriteLine("Door one is made of rotting wood and is covered in rust and moss. Door two is made of shiny metal.");
                            Console.WriteLine("Enter 1 to try the key in door one.");
                            Console.WriteLine("Enter 2 to try the key in door two.");
                            string doorChoiceInput = Console.ReadLine();
                            if (doorChoiceInput == ("1"))
                            {
                                Console.WriteLine("The key fits! With a little force, the door opens to reveal a forest bathed in sunlight.");
                                Console.WriteLine("Congratulations, you have escaped the dungeon and won the game!");
                                playing = false;
                            }
                            if (doorChoiceInput == ("2"))
                            {
                                Console.WriteLine("Regardless of how hard you try, the key does not fit and the door will not open.");
                                Console.WriteLine("In the time it took you to try the door, the scary slug regained some of its strength");
                                monster.Heal();
                                Console.WriteLine(monster.getHealth());
                            }
                        }
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
                Console.WriteLine("Congratulations, you have won the game");

            }



        }
        private string ExplorerInput()
{
    Console.WriteLine("From here, you can choose from the following options:");
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
