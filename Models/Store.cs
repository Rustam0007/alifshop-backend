using System.Text.Json.Serialization;

namespace market_place.Models;

public sealed class Store : BaseEntity
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool IsDeleted { get; set; }
    
    [JsonIgnore]
    public List<Store2Product> Store2Products { get; set; }
}