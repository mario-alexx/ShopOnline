﻿using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _shopContext;

        public ProductRepository(ShopOnlineDbContext context)
        {
            _shopContext = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await _shopContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            //var category = await _shopContext.ProductCategories.FindAsync(id);
            var category = await _shopContext.ProductCategories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            //var item = await _shopContext.Products.FindAsync(id);
            var item = await _shopContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _shopContext.Products.ToListAsync();
            return products;
        }
    }
}