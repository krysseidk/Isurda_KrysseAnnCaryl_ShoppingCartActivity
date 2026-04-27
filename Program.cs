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
    }
}
