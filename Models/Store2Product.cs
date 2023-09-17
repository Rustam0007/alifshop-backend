namespace market_place.Models;

public sealed class Store2Product : BaseEntity
{
    public int StoreId { get; set; }
    public Store Store { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
}