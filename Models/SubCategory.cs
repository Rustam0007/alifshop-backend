using System.Text.Json.Serialization;

namespace market_place.Models;

public sealed class SubCategory : BaseEntity
{
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public int CategoryId { get; set; }
    
    [JsonIgnore]
    public Category Category { get; set; }
}