using System.Text.Json.Serialization;

namespace market_place.Models;

public sealed class Category : BaseEntity
{
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    [JsonIgnore]
    public ICollection<Product> Products { get; set; }
}

