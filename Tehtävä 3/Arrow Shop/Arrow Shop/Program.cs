using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ArrowShop
{
    enum ArrowHead {Wood, Steel, Diamond}
    enum ArrowFeathers {Leaf, ChickenFeather, EagleFeather }
    class Arrow
    {
        private ArrowHead Head;
        public ArrowHead arrowHead { get => Head; set => Head = value; }
        private ArrowFeathers Feathers { get; set; }
        public ArrowFeathers feathers { get => Feathers; set => Feathers = value; }
        private static int Length { get; set; }
        public int length { get => Length; set => Length = value; }


        static void Main(string[] args)
        {
            Choice();
        }

        static void CustomArrow()
        {
            ArrowHead selectedHead = ArrowHeadSelect();
            ArrowFeathers selectedFeathers = ArrowFeatherSelect();
            int length = ArrowLength();

            Arrow arrowChoice = new Arrow(selectedHead, selectedFeathers, length);
            Console.WriteLine($"The price of your arrow is {arrowChoice.GetArrowPrice()} gold.");
        }

        public Arrow(ArrowHead head, ArrowFeathers feathers, int length)
        {
            Head = head;
            Feathers = feathers;
            Length = length;
        }

        private static void Choice()
        {
            while (true)
            {
                bool hasChose = false;
                Console.WriteLine("Do you want to choose a prebuilt arrow or build your own?");
                Console.WriteLine("Press 1 for prebuilt. Press 2 for your own custom arrow");
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    while (true)
                    {
                        Console.WriteLine("These are the prebuilt choices:");
                        Console.WriteLine("EliteArrow = DiamondHead, EagleFeather and 100 cm length");
                        Console.WriteLine("StarterArrow = WoodHead, ChickenFeather and 70 cm length");
                        Console.WriteLine("RegularArrow = SteelHead, ChickenFeather and 85cm length");
                        Console.WriteLine("What's your choice: ");
                        string? prebuiltChoice = Console.ReadLine();

                        switch (prebuiltChoice)
                        {
                            case "EliteArrow":
                                MakeEliteArrow();
                                hasChose = true;
                                break; 

                            case "StarterArrow":
                                MakeStarterArrow();
                                hasChose = true;
                                break;

                            case "RegularArrow":
                                MakeRegularArrow();
                                hasChose = true;
                                break;

                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }

                        if(hasChose == true)
                        {
                            break;
                        }
                    }
                }

                else if (choice == "2")
                {
                    hasChose = true;
                    CustomArrow();
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                if (hasChose == true)
                {
                    break;
                }
            }
        }
        public static Arrow MakeEliteArrow()
        {
            Length = 100;
            Console.WriteLine("You have chosen Elite Arrow.");
            Arrow eliteArrow = new Arrow(ArrowHead.Diamond, ArrowFeathers.EagleFeather, Length);
            Console.WriteLine($"The price of your arrow is {eliteArrow.GetArrowPrice()} gold."); 
            return eliteArrow;
        }

        private static Arrow MakeStarterArrow()
        {
            Length = 70;
            Console.WriteLine("You have chosen Starter Arrow.");
            Arrow starterArrow = new Arrow(ArrowHead.Wood, ArrowFeathers.ChickenFeather, Length);
            Console.WriteLine($"The price of your arrow is {starterArrow.GetArrowPrice()} gold.");
            return starterArrow;
        }

        private static Arrow MakeRegularArrow()
        {
            Length = 85;
            Console.WriteLine("You have chosen Regular Arrow.");
            Arrow regularArrow = new Arrow(ArrowHead.Steel, ArrowFeathers.ChickenFeather, Length);
            Console.WriteLine($"The price of your arrow is {regularArrow.GetArrowPrice()} gold.");
            return regularArrow;
        }

        static ArrowHead ArrowHeadSelect()
        {
            ArrowHead selected;
            while (true)
            {
                Console.Write($"What type of arrow head ({ArrowHead.Wood}, {ArrowHead.Steel}, {ArrowHead.Diamond})?: ");
                string? option1 = Console.ReadLine();
                if(Enum.TryParse(option1, out ArrowHead headType) ) 
                {
                    if (Regex.IsMatch(option1, @"^[0-9]*$"))
                    {
                        Console.WriteLine("Invalid choice");
                        continue;
                    }
                    selected = headType; break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again");
                    continue;
                }
            }
            return selected;
        }

        static ArrowFeathers ArrowFeatherSelect()
        {
            ArrowFeathers selected;
            while (true)
            {
                Console.Write($"What type of arrow feathers ({ArrowFeathers.Leaf}, {ArrowFeathers.ChickenFeather}, {ArrowFeathers.EagleFeather})?: ");
                string? option2 = Console.ReadLine();
                if (Enum.TryParse(option2, out ArrowFeathers feathersType))
                {
                    if(Regex.IsMatch(option2, @"^[0-9]*$"))
                    {
                        Console.WriteLine("Invalid choice");
                        continue;
                    }
                    selected = feathersType; break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again");
                    continue;
                }
            }
            return selected;
        }

        static int ArrowLength()
        {
            int length;
            while (true) {
                Console.Write("Arrow length (60cm - 100cm)?: ");
                string arrowLength = Console.ReadLine();
                if (!int.TryParse(arrowLength, out length))
                {
                    Console.WriteLine("Invalid choice, try again");
                    continue;
                }
                
               

                if (length < 60)
                {
                    Console.WriteLine("Invalid choice, try again");
                    continue;
                }

                else if (length > 100)
                {
                    Console.WriteLine("Invalid choice, try again");
                    continue;
                }

                else
                {
                    break;
                }
            }
            
            return length;
        }

        public double GetArrowPrice()
        {
            double price = 0.0;

            switch (Head)
            {
                case ArrowHead.Wood:
                    price += 3.0;
                    break;

                case ArrowHead.Steel:
                    price += 5.0;
                    break;

                case ArrowHead.Diamond:
                    price += 50.0;
                    break;

                default:
                    break;
            }

            switch(Feathers)
            {
                case ArrowFeathers.Leaf:
                    price += 0.0; 
                    break;

                case ArrowFeathers.ChickenFeather:
                    price += 1.0;
                    break;

                case ArrowFeathers.EagleFeather:
                    price += 5.0;
                    break;

                default:
                    break;
            }

            double lengthPrice = Length * 0.05;
            price += lengthPrice;

            return price;
        }
    }
}