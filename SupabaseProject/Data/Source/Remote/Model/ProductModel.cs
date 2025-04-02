namespace SupabaseProject.Data.Source.Remote.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public override string ToString()
    {
        return $"{Name} - {Price:C}";
    }
}