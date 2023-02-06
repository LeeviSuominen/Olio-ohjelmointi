using System;

namespace Ovi
{

    class Program
    {
        enum DoorState
        {
            Locked,
            Closed,
            Open,
            Unlocked
        }

        static DoorState doorNow = DoorState.Locked;
        
        static void Main(string[] args)
        {
            AskPlayer();
        }

        static void AskPlayer()
        {
            while (true)
            {
                Console.WriteLine($"Door is {doorNow}. What do you want to do? (Unlock, Close, Open, Lock)");
                string? input = Console.ReadLine();

                switch (doorNow)
                {
                    case DoorState.Locked:
                        if(input == "Unlock")
                        {
                            doorNow= DoorState.Unlocked;
                        }

                        else
                        {
                            Console.WriteLine("The door stays locked. Enter the right command.");
                        }
                        break;

                        case DoorState.Unlocked:
                        if (input == "Lock")
                        {
                            doorNow= DoorState.Locked;
                        }

                        else if (input == "Open")
                        {
                            doorNow= DoorState.Open;
                        }

                        else
                        {
                            Console.WriteLine("The door is unlocked. Enter 'Open' or 'Lock'. ");
                        }
                        break;

                        case DoorState.Open:
                        if (input == "Close")
                        {
                            doorNow= DoorState.Closed;
                        }

                        else
                        {
                            Console.WriteLine("The door is open. Enter 'Close' to close it");
                        }
                        break;

                        case DoorState.Closed:
                        if (input == "Lock")
                        {
                            doorNow = DoorState.Locked;
                        }

                        else if (input == "Open")
                        {
                            doorNow = DoorState.Open;
                        }

                        else
                        {
                            Console.WriteLine("The door is closed. Enter 'Open', or 'Lock'");
                        }
                        break;
                }
            }
        }
    }
}

