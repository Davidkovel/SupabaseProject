namespace SupabaseProject.Pages;

public class HomeScreen
{
    public static void View(SupabaseService supabaseService)
    {
        Console.Clear();
        // var goods = supabaseService.GetGoodsListByUser();
        // if (goods.Count == 0)
        // {
        //     Console.WriteLine("No goods found.");
        // }
        // else
        // {
        //     Console.WriteLine("Goods List:");
        //     foreach (var good in goods)
        //     {
        //         Console.WriteLine(good.ToString());
        //     }
        // }

        //Console.WriteLine($"Welcome {supabaseService.SupabaseUser?.Email ?? ""}!");
        Console.WriteLine("1. View Profile");
        Console.WriteLine("2. View Settings");
        Console.WriteLine("3. Logout");
        Console.Write("Select an option: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                // Call method to view profile
                break;
            case "2":
                // Call method to view settings
                break;
            case "3":
                // Call method to logout
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
}