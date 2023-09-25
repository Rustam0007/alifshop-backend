using market_place.Models;
using market_place.Models.Dto;

namespace market_place.Extensions;

public static class CategoryExtension
{
    public static CategoryInfo ToCategoryInfo(this Category category) 
        => new(category.Name, category.IsDeleted);
    
    public static Category ToCategory(this CategoryCreateReq category) 
        => new ()
        {
            Name = category.Name
        };
}