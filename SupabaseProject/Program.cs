using SupabaseProject.Pages;

namespace SupabaseProject;

public class MainClass
{
    public static async Task Main(string[] args)
    {
        var apiKey =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImljYXV5amFlYmpndW5vcmtrdG5pIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDM1Mjg5NTgsImV4cCI6MjA1OTEwNDk1OH0.D1U7bjB-SHwBMy0BT1Zk9GJy6ZI6NUySEPZQMQVQPQw";
        var supabaseDBEndpoint = "https://icauyjaebjgunorkktni.supabase.co";
        
        Console.WriteLine($"API Key: {apiKey}");
        var supabaseService = new SupabaseService(supabaseDBEndpoint, apiKey);
        var authScreen = new AuthScreen(supabaseService);

        await authScreen.Show();

        if (supabaseService.IsLoggedIn)
        {
            HomeScreen.View(supabaseService);
        }

        Console.WriteLine("Goodbye!");
    }
}