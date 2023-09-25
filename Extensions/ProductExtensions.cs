using market_place.Models;
using market_place.Models.Dto;

namespace market_place.Extensions;

public static class ProductExtension
{
    public static ProductInfo ToProductInfo(this Product product) 
        => new(product.Name, product.Colors, product.Description, product.Price, product.IsDeleted, product.SubCategoryId);
    
    public static Product ToProduct(this ProductCreateReq productCreateReq) 
        => new ()
        {
            Name = productCreateReq.Name,
            Colors = productCreateReq.Colors,
            Description = productCreateReq.Description,
            Price = productCreateReq.Price,
            SubCategoryId = productCreateReq.SubCategoryId,
        };
}