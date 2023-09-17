using System.Text.Json.Serialization;

namespace market_place.Models;

public sealed class Product : BaseEntity
{
    public string Name { get; set; }
    public string Colors { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public bool IsDeleted { get; set; }
    public int SubCategoryId { get; set; }
    [JsonIgnore]
    public SubCategory SubCategory { get; set; }
    [JsonIgnore]
    public List<Store2Product> Store2Products { get; set; }

}