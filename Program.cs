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

       int choice = 0;

       int receiptCounter = 1; // for receipt number 

       string[]orderHistory = new string [50]; // store receipts
       int orderCount = 0;

       while (true)
        {
            Console.WriteLine("\n===== SHOPPING MENU =====");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Search Product");
            Console.WriteLine("3. Filter by Category");
            Console.WriteLine("4. View Cart");
            Console.WriteLine("5. Add to Cart");
            Console.WriteLine("6. Remove Item");
            Console.WriteLine("7. Clear Cart");
            Console.WriteLine("8. Checkout");
            Console.WriteLine("9. View Order History");
            Console.WriteLine("10. Exit");
            Console.Write("Choose: ");

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1: 
                    foreach (var p in items)
                        p.DisplayProduct();
                    break;

                case 2:
                    Console.Write("Enter product name to search: ");
                    string search = (Console.ReadLine() ?? "").ToLower();

                    bool hasResult = false; 

                    foreach (var p in items)
                    {
                        if (p.Name.ToLower().Contains(search))
                        {
                            p.DisplayProduct();
                            hasResult = true;
                        }
                    }

                    if (!hasResult)
                    {
                        Console.WriteLine("No product found.");
                    }
                    break;

                case 3:
                    Console.WriteLine("1. Food");
                    Console.WriteLine("2. Electronics");
                    Console.WriteLine("3. Clothing");
                    Console.WriteLine("4. Cosmetics");
                    Console.WriteLine("5. Personal Care");
                    Console.Write("Choose category: ");

                    int.TryParse(Console.ReadLine(), out int cat);

                    string category = "";

                    if (cat == 1) category = "Food";
                    else if (cat == 2) category = "Electronics";
                    else if (cat == 3) category = "Clothing";
                    else if (cat == 4) category = "Cosmetics";
                    else if (cat == 5) category = "Personal Care";

                    foreach (var p in items)
                    {
                        if (p.Category == category)
                        {
                            p.DisplayProduct();
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("\n*** YOUR CART ****");

                    bool empty = true;

                    for (int i = 0; i < items.Length; i++)
                    {
                        if(cart[i] > 0)
                        {
                            Console.WriteLine($"{items [i].Name} x{cart[i]} = ₱{items[i].Price * cart[i]}");
                            empty = false;
                        }
                    }

                    if (empty)
                    {
                        Console.WriteLine("Cart is empty.");
                    }

                    break;

                case 5:
                    Console.WriteLine("\n*** ADD TO CART ***");

                    Console.Write("Enter product ID: ");
                    int.TryParse(Console.ReadLine(), out int id);

                    if (id < 1 || id > items.Length)
                    {
                        Console.WriteLine("Invalid product ID.");
                        break;
                    }

                    Console.Write("Enter quantity: ");
                    int.TryParse(Console.ReadLine(), out int qty);

                    Product? selected = null;

                     // find product
                     foreach (var p in items)
                    {
                        if (p.Id == id)
                        {
                            selected = p;
                            break;
                        }
                    }

                    if (selected == null)
                    {
                        Console.WriteLine("Product not found.");
                        break;
                    }

                    // stock check
                    if (selected.RemainingStock < qty)
                    {
                        Console.WriteLine("Not enough stock.");
                        break;
                    }
                
                    // add to cart
                    cart[id - 1] += qty;
                    selected.RemainingStock -= qty;

                    total += selected.Price * qty;

                    Console.WriteLine("Item added to cart!");
                    break;
                

                case 6:
                    Console.WriteLine("\n*** REMOVE ITEM ***");

                    Console.Write("Enter product ID to remove: ");
                    int.TryParse(Console.ReadLine(), out int removeId);

                    if (removeId < 1 || removeId > items.Length)
                    {
                        Console.WriteLine("Invalid product ID.");
                        break;
                    }

                    if (cart[removeId - 1] == 0)
                    {
                        Console.WriteLine("Item is not in cart.");
                        break;
                    }

                    // get product
                    Product toRemove = items[removeId - 1];

                    // return stock
                    toRemove.RemainingStock += cart[removeId - 1];

                    // adjust total
                    total -= toRemove.Price * cart[removeId - 1];

                    // remove from cart
                    cart[removeId - 1] = 0;

                    Console.WriteLine("Item removed from cart!");
                    break;

                case 7:
                    Console.WriteLine("\n*** CLEAR CART ***");

                    for (int i = 0; i < cart.Length; i++)
                    {
                        if (cart[i] > 0) 
                        {
                            items[i].RemainingStock += cart[i]; // return stock
                            cart[i] = 0;
                        }
                    }

                     total = 0;

                    Console.WriteLine("Cart cleared successfully!");
                    break;

                case 8:
                    Console.WriteLine("\n*** CHECKOUT ***");

                    if (total == 0)
                    {
                        Console.WriteLine("Cart is empty.");
                        break;
                    }

                    double finalTotal = total;
                    double discount = 0;

                    if (total >= 5000)
                    {
                        discount = total * 0.10;
                        finalTotal = total - discount;
                    }

                    // PAYMENT VALIDATION
                    double payment = 0;

                    while (true)
                    {
                        Console.Write("Enter payment: ");
                        if (!double.TryParse(Console.ReadLine(), out payment))
                        {
                            Console.WriteLine("Invalid input. Enter a number.");
                            continue;
                        }

                        if (payment < finalTotal)
                        {
                            Console.WriteLine("Insufficient payment.");
                        }
                        else break;
                    }

                    double change = payment - finalTotal;

                    // RECEIPT NUMBER + DATE
                    string receiptNo = receiptCounter.ToString("D4");
                    string dateNow = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt");

                    Console.WriteLine("\n--- RECEIPT ---");
                    Console.WriteLine($"Receipt No: {receiptNo}");
                    Console.WriteLine($"Date: {dateNow}\n");
                    
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (cart[i] > 0)
                        {
                            Console.WriteLine($"{items[i].Name} x{cart[i]} = ₱{items[i].Price * cart[i]}");
                        }
                    }

                    Console.WriteLine($"\nSubtotal: ₱{total}");

                    if (discount > 0)
                    {
                        Console.WriteLine($"Discount: ₱{discount}");
                    }

                    Console.WriteLine($"Final Total: ₱{finalTotal}");
                    Console.WriteLine($"Payment: ₱{payment}");
                    Console.WriteLine($"Change: ₱{change}");

                    // SAVE TO ORDER HISTORY
                    orderHistory[orderCount] = $"Receipt #{receiptNo} - ₱{finalTotal}";
                    orderCount++;
                    receiptCounter++;

                    // LOW STOCK ALERT
                    Console.WriteLine("\n--- LOW STOCK ALERT ---");

                    bool hasLowStock = false;

                    foreach (var p in items)
                    {
                        if (p.RemainingStock == 0)
                        {
                            Console.WriteLine($"{p.Name} is OUT OF STOCK!");
                            hasLowStock = true;
                        }
                        else if (p.RemainingStock <= 5)
                        {
                            Console.WriteLine($"{p.Name} has only {p.RemainingStock} left.");
                            hasLowStock = true;
                        }
                    }

                    if (!hasLowStock)
                    {
                        Console.WriteLine("All products are well stocked.");
                    }

                    Console.WriteLine("\nThank you for shopping!");

                    // CLEAR CART AFTER CHECKOUT
                    for (int i = 0; i < cart.Length; i++)
                    {
                        cart[i] = 0;
                    }
                    total = 0;
                    
                    break;

                case 9:
                    Console.WriteLine("\n*** ORDER HISTORY ***");

                    if (orderCount == 0)
                    {
                        Console.WriteLine("No orders yet.");
                    }
                    else
                    {
                        for (int i = 0; i < orderCount; i++)
                        {
                            Console.WriteLine(orderHistory[i]);
                        }
                    }
                    break; 
                
                case 10:
                    Console.WriteLine("Exiting program...");
                    return;
                    
                default:
                    Console.WriteLine("Invalid choice.");
                    break;

            }
        }
    }
}

