using CursoUnitTesting.API.Models;
using CursoUnitTesting.API.Services.Interfaces;
using CursoUnitTesting.Business.Entities;
using CursoUnitTesting.Business.Interfaces;
using System;

namespace CursoUnitTesting.API.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name = "repository" ></ param >
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public Product GetProductById(int id)
        {
            Product product;
            return product = _productRepository.GetProductById(id);
        }
        //public void RemoveProduct(int id)
        //{
        //    _productRepository.RemoveProduct(id);
        //}
        //public void AddProduct(Product Product)
        //{
        //    _productRepository.AddProduct(Product);
        //}
        public void UpdateProduct(int id, Product product)
        {
            _productRepository.UpdateProduct(id, product);
        }

        //Validate if a given product is a football product and if its available
        public bool CheckFootballProductAvailable(Product product)
        {

            // if there is not product with the given id
            if (product == null)
            {
                throw new ArgumentException("Product does not exists");
            }

            // if product is not football product, return
            if (product.CategoryID != 2)
            {
                throw new Exception($"False. Product '{product.Id}' is too old and will not be retrieved.");
            }
            // if product is older than 3 years, dont return it
            if (product.Created.AddYears(3) < DateTime.UtcNow)
            {
                throw new Exception($"False. Product '{product.Id}' is too old and will not be retrieved.");
            }
            // if there is not stock available
            if (product.UnitsInStock.Equals(0))
            {
                throw new Exception($"False. Product '{product.Id}' has not stock available.");
            }
            // if it is a, dont return it
            if (product.ProductName.Contains("Madrid"))
            {
                throw new Exception($"False. Product '{product.Id}' is a Real Madrid product. We do not sell shit");
            }

            return true;
        }


        public Product MapProductRequest(ProductUpdateRequest productUpdateRequest)
        {
            Product product = new Product
            {
                Id = productUpdateRequest.Id,
                ProductName = productUpdateRequest.ProductName,
                UnitPrice = productUpdateRequest.UnitPrice,
                UnitsOnOrder = productUpdateRequest.UnitsOnOrder,
                QuantityPerUnit = productUpdateRequest.QuantityPerUnit,
                UnitsInStock = productUpdateRequest.UnitsInStock
            };

            return product;
        }
    }
}
