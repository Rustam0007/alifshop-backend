namespace market_place.Models.Dto;

public class CategoryCreateReq
{
    public string Name { get; set; }
    public int ParentCategoryId { get; set; }
}
public class CategoryCreateRes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ParentCategoryId { get; set; }

}

public class CategoryUpdateReq
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CategoryUpdateRes
{
    public int Id { get; set; }
    public string PrevName { get; set; }
    public string NewName { get; set; }
}

public class CategoryDeleteRes
{
    public int Id { get; set; }
}