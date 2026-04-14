using System;
using System.Runtime.InteropServices;

class Product
{
    public int Id { get; set; } // stores proudt Id
    public string Name { get; set; } = ""; // stores product name 
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
            new Product{Id = 1, Name = "Lipstick", Price = 199, RemainingStock = 100},
            new Product{Id = 2, Name = "Blush", Price = 329, RemainingStock = 100},
            new Product{Id = 3, Name = "Eyebrow Pencil", Price = 129, RemainingStock = 100},
            new Product{Id = 4, Name = "Powder", Price = 499, RemainingStock = 100},
            new Product{Id = 5, Name = "Eyeliner", Price = 99, RemainingStock = 100},
            new Product{Id = 6, Name = "Foundation", Price = 749, RemainingStock = 100},
            new Product{Id = 7, Name = "Concealer", Price = 299, RemainingStock = 100},
            new Product{Id = 8, Name = "Mascara", Price = 599, RemainingStock = 100},
            new Product{Id = 9, Name = "Setting Powder", Price = 879, RemainingStock = 100},
            new Product{Id = 10, Name = "Primer", Price = 759, RemainingStock = 100},
        };

        int[] cart = new int[10]; // stores quantity of each product added to cart
        double total = 0; // stores total price of all purchases

        Console.WriteLine("===== [PAO'S SHOPPING SYSTEM] ====");
        
        string again = "yes";

        while (again.ToLower() == "yes")
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
                Console.WriteLine("Not Enough Stock.");
                continue;
            }

            // add to cart and reduce stock
            cart[pick - 1] += qty;
            selected.RemainingStock -= qty;

            // update total price
            total += selected.Total(qty);

            Console.Write("Do you want to continue? (yes/no): ");
            again = Console.ReadLine();
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

        Console.WriteLine("TOTAL: ₱" + finalTotal); 

        Console.WriteLine("\n--- UPDATED STOCK ---");

        foreach (Product p in items)
        {
             p.DisplayProduct(); 
        }     

Console.Write("=== THANK YOU AND BUY AGAIN! ===");

        
    }
}
