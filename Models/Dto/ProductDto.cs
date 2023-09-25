namespace market_place.Models.Dto;

public readonly record struct ProductInfo(string Name, string Colors, string Description, float Price, bool IsDeleted,
    int SubCategoryId);

public readonly record struct ProductCreateReq(string Name, string Colors, string Description, float Price,
    int StoreId, int SubCategoryId);

public readonly record struct ProductCreateRes(int Id);
public readonly record struct ProductUpdateReq(int Id, string Name, string Colors, string Description, float Price,
    int StoreId, int SubCategoryId);

public readonly record struct ProductUpdateRes(int Id);
public readonly record struct ProductDeleteRes(int Id);