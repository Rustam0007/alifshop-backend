namespace market_place.Models.Dto;
public sealed class ProductCreateReq
{
    public string Name { get; set; }
    public string Colors { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int StoreId { get; set; }
    public int SubCategoryId { get; set; }
}

public sealed class ProductCreateRes
{
    public int Id { get; set; }
}

public sealed class ProductUpdateReq
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Colors { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int StoreId { get; set; }
    public int CategoryId { get; set; }

}

public sealed class ProductUpdateRes
{
    public int Id { get; set; }
}

public sealed class ProductDeleteRes
{
    public int Id { get; set; }
}