using System;

class Product
{
    public int Id { get; set; } // stores product Id
    public string Name { get; set; } = ""; // stores product name 
    public string Category { get; set; } = ""; //stores product category 
    public double Price { get; set; } // stores product price
    public int RemainingStock { get; set; } // stores available stock

    public void DisplayProduct()
    {
        // shows the product details in the console 
        Console.WriteLine($"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})");
    }

    public double Total(int qty)
    {
        // calculates total price based on quantity
        return Price * qty; 
    }
}
class Program
{
    static void Main()
    {
        // list of available products in the store
        Product[] items =
        {
            new Product
            {
                Id = 1,
                Name = "Lipstick",
                Category = "Cosmetics",
                Price = 199, 
                RemainingStock = 100
            },

            new Product
            {
                Id = 2,
                Name = "Blush",
                Category = "Cosmetics",
                Price = 329, 
                RemainingStock = 100
            },

            new Product
            {
                Id = 3,
                Name = "IPhone 17 Pro Max",
                Category = "Electronics",
                Price = 88990,
                RemainingStock = 10
            },

            new Product
            {
                Id = 4, 
                Name = "Ipad A16", 
                Category = "Electronics", 
                Price = 20000, 
                RemainingStock = 10
            },

            new Product
            {
                Id = 5, 
                Name = "Mermaid Pants", 
                Category = "Clothing",
                Price = 700, 
                RemainingStock = 20
            },

            new Product
            {
                Id = 6, 
                Name = "Plain White T-Shirt", 
                Category = "Clothing",
                Price = 749, 
                RemainingStock = 20
            },

            new Product
            {
                Id = 7, 
                Name = "Pancit Canton", 
                Category = "Food", 
                Price = 20, 
                RemainingStock = 50
            
            },
            new Product
            {
                Id = 8, 
                Name = "Purefoods Cornbeef", 
                Category = "Food",
                Price = 85, 
                RemainingStock = 50
            },

            new Product
            {
                Id = 9, 
                Name = "Nivea Lotion", 
                Category = "Personal Care", 
                Price = 879, 
                RemainingStock = 10
            },

            new Product
            {
                Id = 10, 
                Name = "Belo Sunscreen",
                Category = "Personal Care", 
                Price = 499, 
                RemainingStock = 30
            },
        };

        int[] cart = new int[10]; // stores quantity of each product added to cart
        double total = 0; // stores total price of all purchases

        Console.WriteLine("===== [PAO'S SHOPPING SYSTEM] ====");
        Console.WriteLine("\n===== SEARCH OPTIONS =====");
        Console.WriteLine("1. Search Product by Name");
        Console.WriteLine("2. Filter by Category");
        Console.WriteLine("3. Skip");
        Console.Write("Choose option: ");

        int searchOption;
        int.TryParse(Console.ReadLine(), out searchOption);

        if (searchOption == 1)
        {
            Console.Write("\nEnter product name to search: ");
            string search = Console.ReadLine().ToLower();

            bool found = false;

            foreach (Product p in items)
            {
                if (p.Name.ToLower().Contains(search))
                {
                    p.DisplayProduct();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No product found.");
            }
}
        else if (searchOption == 2)
        {
            Console.WriteLine("\nCategory filter not yet implemented (Step 2.3 next).");
        }
        else
        {
            Console.WriteLine("\nSkipping search...\n");
        }

        Console.WriteLine("Buy ₱5000 and above to get 10% discount!\n");
        
        string again = "yes";

        while ((again ?? "").ToLower() == "yes")
        {
            Console.WriteLine("\nAvailable Items:");

            // display all products
            for (int i = 0; i < items.Length; i++)
            {
                items[i].DisplayProduct();
            }

            Console.Write("\nEnter item number: ");

            // validate product selection input
            if (!int.TryParse(Console.ReadLine(), out int pick) || pick < 1 || pick > items.Length)
            {
                Console.WriteLine("Invalid input."); 
                continue;
            }

            Console.Write("Enter quantity: ");

            // validate quantity input
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            Product selected = items[pick - 1];

            // check if stock is enough 
            if (selected.RemainingStock < qty)
            {
                Console.WriteLine("Not enough stock available.");
                continue;
            }

            // count how many product slots are already used
            int usedSlots = 0;
            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i] > 0) usedSlots++;
            }
            
            if (usedSlots >= cart.Length && cart [pick - 1] == 0)
            {
                Console.WriteLine("Cart is full.");
                continue;
            }

            // if new item and cart is full
            if (cart[pick - 1] > 0)
            {
                Console.WriteLine("Item already in cart. Updating quantity...");
            }
           
            // proceed to add/update cart
            cart[pick - 1] += qty;
            selected.RemainingStock -= qty;

            Console.WriteLine("Item successfully added to cart!");

            // update total price
            total += selected.Total(qty);

            Console.Write("Do you want to continue? (yes/no): ");
            again = Console.ReadLine() ?? "no";
        }

        // apply discount if the total reaches 5000 or more
        double finalTotal = total;
        double discount = 0;

        if (total >= 5000)
        {
            discount = total * 0.10;
            finalTotal = total - discount;
        }


        Console.WriteLine("\n--- RECEIPT ---");

        for (int i = 0; i < items.Length; i++)
        {
            if (cart[i] > 0)
            {
                double subtotal = items[i].Price * cart[i];
                Console.WriteLine($"{items[i].Name} x{cart[i]} = ₱{subtotal}");
            }
}


        Console.WriteLine("\nSubtotal: ₱" + total);

        if (discount > 0)
        {
            Console.WriteLine("Discount: ₱" + discount);
            Console.WriteLine("You saved: ₱" + discount);
        }

        Console.WriteLine("GRAND TOTAL: ₱" + finalTotal); 

        Console.WriteLine("\n--- UPDATED STOCK ---");

        foreach (Product p in items)
        {
             p.DisplayProduct(); 
        }     

        Console.WriteLine("=== THANK YOU AND BUY AGAIN! ===");
    
    }
}
