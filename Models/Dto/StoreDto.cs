namespace market_place.Models.Dto;

public sealed class StoreCreateReq
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}

public sealed class StoreCreateRes
{
    public int Id { get; set; }
}

public sealed class StoreUpdateReq
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

}

public sealed class StoreUpdateRes
{
    public int Id { get; set; }
}

public sealed class StoreDeleteRes
{
    public int Id { get; set; }
}