namespace AdventurersBackpack
{
    class BackPack
    {
        public int maxCapacity {get;  }
        public int maxWeight {get;  }
        public int maxItems { get; }
        public int itemAmount { get; set; }
        public double itemWeight { get; set; }
        public double itemCapacity { get; set; }

        public bool canAddItems = true;

        private Item[] items;

        public void PrintStats()
        {
            Console.WriteLine($"The backpack contains of {itemAmount}/{maxItems} items, {itemWeight}/{maxWeight} weight, and {itemCapacity}/{maxCapacity} capacity.");
            Console.WriteLine($"The remaining capacity: {maxItems - itemAmount} items / {maxWeight - itemWeight} weight / {maxCapacity - itemCapacity} capacity");
        }

        public BackPack(int maxCapacity, int maxWeight, int maxItems)
        {
            this.maxCapacity = maxCapacity;
            this.maxWeight = maxWeight;
            this.maxItems = maxItems;
            items = new Item[maxItems];
        }

        public bool AddItems(Item item)
        {
           if (itemAmount >= maxItems)
            {
                Console.WriteLine("You have max amount of items!");
                canAddItems = false;
                return false;
            }

           else if (itemWeight + item.weight > maxWeight)
            {
                Console.WriteLine("The weight of your backpack is full!");
                canAddItems = false;
                return false;
            }

           else if(itemCapacity + item.capacity > maxCapacity)
            {
                Console.WriteLine("The capacity of your backpack is full!");
                canAddItems = false;
                return false;
            }

            items[itemAmount] = item;
            itemAmount++;
            itemWeight += item.weight;
            itemCapacity += item.capacity;
            return true;
        }

        public override string ToString()
        {
            string content = "The backpack contains the following items:";
            for (int i = 0; i < itemAmount; i++)
            {
                content += $" {items[i].name},";
            }
            content = content.TrimEnd(',');
            return content;
        }
    }

    public class MainProgram
    {
        static void Main(string[] items)
        {
            BackPack backpack = new BackPack(20, 30, 10);
            Console.WriteLine(backpack.ToString());
            while (backpack.canAddItems)
            {
                Console.WriteLine("What do you want to add?");
                Console.WriteLine("1 - Arrow\n2 - Bow \n3 - Rope\n4 - Water\n5 - Food \n6 - Sword");
                string? input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        backpack.AddItems(new Arrow());
                        break;

                    case "2":
                        backpack.AddItems(new Bow());
                        break;

                    case "3":
                        backpack.AddItems(new Rope());
                        break;

                    case "4":
                        backpack.AddItems(new Water());
                        break;

                    case "5":
                        backpack.AddItems(new Food());
                        break;

                    case "6":
                        backpack.AddItems(new Sword());
                        break;

                    default:
                        Console.WriteLine("Wrong input. Please try again.");
                        break;
                }

                if (backpack.canAddItems == false)
                {
                    Console.WriteLine("Sorry, you can't add anymore items in the backpack.");
                    break;
                }

                else
                {
                    backpack.PrintStats();
                    Console.WriteLine(backpack.ToString());
                }
            }
        }
    }

    class Item
    {
        public double weight { get; }
        public double capacity { get; }
        public string name { get; }
        public Item(double weight, double capacity, string name)
        {
            this.weight = weight;   
            this.capacity = capacity;   
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }

    class Arrow : Item 
    {
        public Arrow() : base (0.1 , 0.05, "Arrow")
        {

        }
    }

    class Bow : Item
    {
        public Bow() : base(1, 4, "Bow")
        {

        }
    }

    class Rope : Item
    {
        public Rope() : base(1, 1.5, "Rope")
        {

        }
    }

    class Water : Item
    {
        public Water() : base(2, 2, "Water")
        {

        }
    }

    class Food : Item
    {
        public Food() : base(1, 0.5, "Food")
        {

        }
    }

    class Sword : Item
    {
        public Sword() : base(5, 3, "Sword")
        {

        }
    }
}