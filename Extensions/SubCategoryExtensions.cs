using market_place.Models;
using market_place.Models.Dto;

namespace market_place.Extensions;

public static class SubCategoryExtension
{
    public static SubCategoryInfo ToSubCategoryInfo(this SubCategory subCategory) 
        => new(subCategory.CategoryId, subCategory.Name, subCategory.IsDeleted);
    
    public static SubCategory ToSubCategory(this SubCategoryCreateReq subcategory) 
        => new ()
        {
            Name = subcategory.Name,
            CategoryId = subcategory.CategoryId,
        };
}