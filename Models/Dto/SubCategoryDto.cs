namespace market_place.Models.Dto;

public class SubCategoryCreateReq
{
    public string Name { get; set; }
}
public class SubCategoryCreateRes
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SubCategoryUpdateReq
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SubCategoryUpdateRes
{
    public int Id { get; set; }
    public string PrevName { get; set; }
    public string NewName { get; set; }
}

public class SubCategoryDeleteRes
{
    public int Id { get; set; }
}