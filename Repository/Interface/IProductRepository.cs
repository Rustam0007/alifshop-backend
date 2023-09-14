﻿using market_place.Models;
using market_place.Models.Dto;

namespace market_place.Repository.Interface;

public interface IProductRepository : IBaseRepository
{
    Task<List<Product>> GetProductByCategoryId(int categoryId);
    Task<List<Product>> GetProductByStoreId(int storeId);
    Task<List<Product>> GetProductByName(string name);
}