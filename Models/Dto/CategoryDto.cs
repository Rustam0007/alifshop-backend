
namespace market_place.Models.Dto;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CategoryCreateReq
{
    public string Name { get; set; }
}

public class CategoryCreateRes
{
    public int Id { get; set; }
    public string Name { get; set; }
}