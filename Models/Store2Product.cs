namespace market_place.Models;

public class Store2Product
{
    public int Id { get; set; }
    
    public int StoreId { get; set; }
    public Store Store { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
}