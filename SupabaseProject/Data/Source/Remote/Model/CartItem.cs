using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SupabaseProject.Data.Source.Remote.Model;

[Table("Cart")]
public class CartItem : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("user_id")]
    public string UserId { get; set; }

    [Column("product_name")]
    public string ProductName { get; set; }

    [Column("product_price")]
    public double ProductPrice { get; set; }

}