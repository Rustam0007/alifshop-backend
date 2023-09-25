namespace market_place.Models.Dto;

public readonly record struct StoreInfo(
    double Latitude, double Longitude, string Name, string PhoneNumber, string Image, 
    string Description, bool IsDeleted);

public readonly record struct StoreCreateReq(double Latitude, double Longitude, string Name, string PhoneNumber,
    string Image, string Description);

public readonly record struct StoreCreateRes(int Id);

public readonly record struct StoreUpdateReq(int Id, double Latitude, double Longitude, string Name, string PhoneNumber,
    string Image, string Description);

public readonly record struct StoreUpdateRes(int Id, string PrevName, string NewName);
public readonly record struct StoreDeleteRes(int Id);