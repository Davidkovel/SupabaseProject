namespace SupabaseProject.Pages;

using SupabaseProject.Data.Source.Remote.Service;

public class HomeScreen
{
    public static async Task View(SupabaseService supabaseService)
    {
        var products = new Dictionary<string, double>
        {
            { "Laptop", 999.99 },
            { "Phone", 699.99 },
            { "Headphones", 149.99 }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key}: {product.Value:C}");
            }

            Console.WriteLine("\n1. Add product to cart");
            Console.WriteLine("2. View my cart");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await AddToCartFlow(supabaseService, products);
                    break;
                case "2":
                    await ViewCartFlow(supabaseService);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    private static async Task AddToCartFlow(SupabaseService service, Dictionary<string, double> products)
    {
        Console.Write("Enter product name: ");
        var productName = Console.ReadLine();

        if (products.TryGetValue(productName, out var price))
        {
            await service.AddToCart(productName, price);
            Console.WriteLine($"{productName} added to cart!");
        }
        else
        {
            Console.WriteLine("Product not found!");
        }

        Console.ReadKey();
    }

    private static async Task ViewCartFlow(SupabaseService service)
    {
        var cartItems = await service.GetUserCart();
        Console.Clear();
        Console.WriteLine("Your Cart:");

        if (cartItems.Count == 0)
        {
            Console.WriteLine("Cart is empty");
        }
        else
        {
            foreach (var item in cartItems)
            {
                Console.WriteLine($"{item.Id}. {item.ProductName} - {item.ProductPrice:C}");
            }

            Console.WriteLine("\n1. Remove item");
            Console.WriteLine("2. Back");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter item ID to remove: ");
                if (long.TryParse(Console.ReadLine(), out var itemId))
                {
                    await service.RemoveFromCart(itemId);
                    Console.WriteLine("Item removed");
                }
            }
        }

        Console.ReadKey();
    }
}