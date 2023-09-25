namespace market_place.Models.Dto;

public readonly record struct SubCategoryInfo(int CategoryId, string Name, bool IsDeleted);
public readonly record struct SubCategoryCreateReq(int CategoryId, string Name);
public readonly record struct SubCategoryCreateRes(int Id, int CategoryId, string Name);
public readonly record struct SubCategoryUpdateReq(int Id, int CategoryId, string Name);
public readonly record struct SubCategoryUpdateRes(int Id, string PrevName, string NewName);
public readonly record struct SubCategoryDeleteRes(int Id);
