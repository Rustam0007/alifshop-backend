using market_place.Models;
using market_place.Models.Dto;

namespace market_place.Extensions;

public static class StoreExtension
{
    public static StoreInfo ToStoreInfo(this Store store) 
        => new(store.Latitude, store.Longitude, store.Name, store.PhoneNumber, store.Image, store.Description, store.IsDeleted);
    
    public static Store ToStore(this StoreCreateReq store) 
        => new ()
        {
            Name = store.Name,
            Description = store.Description,
            PhoneNumber = store.PhoneNumber,
            Longitude = store.Longitude,
            Latitude = store.Latitude,
            Image = store.Image,
        };
}