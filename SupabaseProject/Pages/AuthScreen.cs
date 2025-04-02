namespace SupabaseProject;


public class AuthScreen
{
    private readonly SupabaseService _supabaseService;

    public AuthScreen(SupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ShowSignIn();
                    break;
                case "2":
                    await ShowSignUp();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private async Task ShowSignIn()
    {
        Console.Clear();
        Console.WriteLine("Sign In");
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();

        try
        {
            var success = await _supabaseService.Login(email, password);
            if (success != null)
            {
                Console.WriteLine("Sign in successful! Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Sign in failed. Press any key to try again.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey();
        }
    }

    private async Task ShowSignUp()
    {
        Console.Clear();
        Console.WriteLine("Sign Up");
        Console.Write("Email: ");
        var email = Console.ReadLine();
        Console.Write("Password: ");
        var password = Console.ReadLine();
        Console.Write("First Name: ");
        var firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine();

        try
        {
            var success = await _supabaseService.Register(email, password);
            if (success != null)
            {
                Console.WriteLine("Sign up successful! Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Sign up failed. Press any key to try again.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey();
        }
    }
}