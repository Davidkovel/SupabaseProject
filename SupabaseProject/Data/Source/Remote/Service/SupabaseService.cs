using Supabase.Gotrue;
using Client = Supabase.Client;

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
}