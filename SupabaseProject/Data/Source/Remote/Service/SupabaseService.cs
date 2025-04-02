using Supabase.Gotrue;
using Client = Supabase.Client;
using SupabaseProject.Data.Source.Remote.Model;

namespace SupabaseProject.Data.Source.Remote.Service;

public class SupabaseService
{
    private readonly Supabase.Client? _client;
    public User? SupabaseUser { get; set; } = null;
    public bool IsLoggedIn { get; set; } = false;

    public SupabaseService(string SupabaseUrl, string SupabaseKey)
    {
        try
        {
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true,
            };
            _client = new Client(SupabaseUrl, SupabaseKey, options);
        }
        catch (Exception ex)
        {
            throw new Exception($"SupabaseService() raise Exception: {ex.Message}");
        }
    }

    public async Task InitService()
    {
        try
        {
            await _client.InitializeAsync()!;
        }
        catch (Exception ex)
        {
            throw new Exception($"InitService() raise Exception: {ex.Message}");
        }
    }

    public async Task<Session?> Login(string email, string password)
    {
        try
        {
            var session = await _client.Auth.SignIn(email, password);
            SetAuthUser();
            return session;
        }
        catch (Exception ex)
        {
            throw new Exception($"Login(string email, string password) raise Exception: {ex.Message}");
        }
    }

    public async Task<Session?> Register(string email, string password)
    {
        try
        {
            var session = await _client.Auth.SignUp(email, password);
            return session;
        }
        catch (Exception ex)
        {
            throw new Exception($"Register(string email, string password) raise Exception: {ex.Message}");
        }
    }

    public void SetAuthUser()
    {
        if (_client.Auth.CurrentUser != null)
        {
            SupabaseUser = _client.Auth.CurrentUser;
            IsLoggedIn = true;
        }
    }

    public bool IsAuthenticated()
    {
        return IsLoggedIn;
    }


    public async Task<List<CartItem>> GetUserCart()
    {
        if (SupabaseUser?.Id == null)
            return new List<CartItem>();

        var result = await _client.From<CartItem>()
            .Where(x => x.UserId == SupabaseUser.Id)
            .Get();

        return result.Models;
    }

    public async Task AddToCart(string productName, double price)
    {
        if (SupabaseUser.Id == null)
            throw new Exception("User not authenticated");

        var item = new CartItem
        {
            UserId = SupabaseUser.Id,
            ProductName = productName,
            ProductPrice = price
        };

        await _client.From<CartItem>().Insert(item);
    }

    public async Task RemoveFromCart(long itemId)
    {
        if (SupabaseUser?.Id == null) return;

        await _client.From<CartItem>()
            .Where(x => x.Id == itemId && x.UserId == SupabaseUser.Id)
            .Delete();
    }
}