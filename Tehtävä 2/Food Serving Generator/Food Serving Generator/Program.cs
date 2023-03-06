using System.Text.RegularExpressions;

namespace FoodServingGenerator
{
    enum MainDish { Beef, Chicken, Vegetables }
    enum SideDish { Potatoes, Rice, Pasta }
    enum Sauce { Curry, SweetAndSour, Pepper, Chili }


    class Program
    {
        static void Main(string[] args) {
            {
                (MainDish mainDish, SideDish sideDish, Sauce sauce) order = (MainDishSelect(), SideDishSelect(), SauceSelect());

                Console.WriteLine($"{order.mainDish} and {order.sideDish} with {order.sauce}-sauce");
            }
        }

        static MainDish MainDishSelect()
        {
            MainDish selected;
            while (true)
            {
                Console.Write($"Main Dish ({MainDish.Beef}, {MainDish.Chicken}, {MainDish.Vegetables}):");
                string? option1 = Console.ReadLine();
                if (Enum.TryParse(option1, out MainDish mainType))
                {
                    if(Regex.IsMatch(option1, @"^[0-9]*$")){
                        Console.WriteLine("Invalid choice");
                        continue;
                    }
                    
                    selected = mainType; break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
            }

            return selected;
        }

        static SideDish SideDishSelect()
        {
            SideDish selected;
            while (true)
            {
                Console.Write($"Side Dish ({SideDish.Potatoes}, {SideDish.Rice}, {SideDish.Pasta}):");
                string? option2 = Console.ReadLine();
                if (Enum.TryParse(option2, out SideDish sideType))
                {
                    if (Regex.IsMatch(option2, @"^[0-9]*$"))
                    {
                        Console.WriteLine("Invalid choice");
                        continue;
                    }
                    selected = sideType; break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
            }

            return selected;
        }

        static Sauce SauceSelect()
        {
            Sauce selected;
            while (true)
            {
                Console.Write($"Sauce ({Sauce.Curry}, {Sauce.SweetAndSour}, {Sauce.Pepper}, {Sauce.Chili}):");
                string? option3 = Console.ReadLine();
                if (Enum.TryParse(option3, out Sauce sideType))
                {
                    if (Regex.IsMatch(option3, @"^[0-9]*$"))
                    {
                        Console.WriteLine("Invalid choice");
                        continue;
                    }
                    selected = sideType; break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
            }

            return selected;
        }


    }

    
    

}