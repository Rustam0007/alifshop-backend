namespace market_place.Models.Dto;

public readonly record struct CategoryInfo(string Name, bool IsDeleted);
public readonly record struct CategoryCreateReq(string Name);
public readonly record struct CategoryCreateRes(int Id);
public readonly record struct CategoryUpdateReq(int Id, string Name);
public readonly record struct CategoryUpdateRes(int Id, string PrevName, string NewName);
public readonly record struct CategoryDeleteRes(int Id);
