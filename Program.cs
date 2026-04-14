using System;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int RemainingStock { get; set; }

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})");
    }

    public double Total(int qty)
    {
        return Price * qty; 
    }
}
class Program
{
    static void Main()
    {
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

        int[] cart = new int[10];
        double total = 0;
    }
}
    
