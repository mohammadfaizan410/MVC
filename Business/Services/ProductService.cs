using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
 
    public interface IProductService
    {
        IQueryable<ProductModel> GetAllProducts();
        bool AddProduct(ProductModel model);
        bool UpdateProduct(ProductModel model);
        bool DeleteProduct(int id);

        ProductModel GetProduct(int id);
    }

    public class ProductService : IProductService
    {
        private readonly Db _db;
        private readonly ILogger<ProductService> _logger;


        public ProductService(Db db, ILogger<ProductService> logger)
        {
            _logger = logger;
            _db = db;
        }

        public IQueryable<ProductModel> GetAllProducts()
        {
            return _db.Products.Select(p => new ProductModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                IsFeaturedOutput = p.IsFeatured,
                IsTopRatedOutput = p.IsTopRated,
                IsNearbyOutput = p.IsNearby
            }); ;
        }

        public bool AddProduct(ProductModel model)
        {
            Product productEntity = new Product
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                IsFeatured = model.IsFeaturedOutput,
                IsTopRated = model.IsTopRatedOutput,
                IsNearby = model.IsNearbyOutput,
            };


            _db.Products.Add(productEntity);
            _db.SaveChanges();

            return true;
        }

        public ProductModel GetProduct(int id)
        {
            //var productEntity = _db.Products.FirstOrDefault(p => p.Id == id);
            //if (productEntity == null)
            //{
            //    return null;
            //}
            //var productModel = new ProductModel
            //{
            //    Id = productEntity.Id,
            //    Title = productEntity.Title,
            //    Description = productEntity.Description,
            //    Price = productEntity.Price,
            //    IsFeaturedOutput = productEntity.IsFeatured,
            //    IsTopRatedOutput = productEntity.IsTopRated,
            //    IsNearbyOutput = productEntity.IsNearby,
            //};
            ProductModel productModel = GetAllProducts().SingleOrDefault(p => p.Id == id);

            return productModel;
        }
        public bool UpdateProduct(ProductModel model)
        {
            try
            {
                var productEntity = _db.Products.FirstOrDefault(p => p.Id == model.Id);
                if (productEntity == null)
                {
                    Console.WriteLine("Product with ID {ProductId} not found.", model.Id);
                    return false;
                }

                productEntity.Title = model.Title;
                productEntity.Description = model.Description;
                productEntity.Price = model.Price;
                productEntity.IsFeatured = model.IsFeaturedOutput;
                productEntity.IsTopRated = model.IsTopRatedOutput;
                productEntity.IsNearby = model.IsNearbyOutput;

                _db.SaveChanges();

                _logger.LogInformation("Product with ID {ProductId} updated successfully.", model.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product with ID {ProductId}.", model.Id);
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            var productEntity = _db.Products.FirstOrDefault(p => p.Id == id);
            if (productEntity == null)
                return false;

            _db.Products.Remove(productEntity);
            _db.SaveChanges();

            return true;
        }
    }
}
