namespace market_place.Models.Dto;

public sealed class CategoryCreateReq
{
    public string Name { get; set; }
}
public sealed class CategoryCreateRes
{
    public int Id { get; set; }
    public string Name { get; set; }

}

public sealed class CategoryUpdateReq
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public sealed class CategoryUpdateRes
{
    public int Id { get; set; }
    public string PrevName { get; set; }
    public string NewName { get; set; }
}

public sealed class CategoryDeleteRes
{
    public int Id { get; set; }
}