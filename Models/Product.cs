namespace market_place.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Colors { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public bool IsDeleted { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public List<Store2Product> Store2Products { get; set; }

}