namespace market_place.Models.Dto;

public sealed class SubCategoryCreateReq
{
    public string Name { get; set; }
    public int CategoryId { get; set; }

}
public sealed class SubCategoryCreateRes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }

}

public sealed class SubCategoryUpdateReq
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
}

public sealed class SubCategoryUpdateRes
{
    public int Id { get; set; }
    public string PrevName { get; set; }
    public string NewName { get; set; }
}

public sealed class SubCategoryDeleteRes
{
    public int Id { get; set; }
}