namespace market_place.Models.Dto;

public class ProductGetAllRes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Colors { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public bool IsDeleted { get; set; }
    public int StoreId { get; set; }
    public int CategoryId { get; set; }
}
public class ProductCreateReq
{
    public string Name { get; set; }
    public string Colors { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int StoreId { get; set; }
    public int CategoryId { get; set; }
}

public class ProductCreateRes
{
    public int Id { get; set; }
}

public class ProductUpdateReq
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Colors { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int StoreId { get; set; }
    public int CategoryId { get; set; }

}

public class ProductUpdateRes
{
    public int Id { get; set; }
}

public class ProductDeleteRes
{
    public int Id { get; set; }
}