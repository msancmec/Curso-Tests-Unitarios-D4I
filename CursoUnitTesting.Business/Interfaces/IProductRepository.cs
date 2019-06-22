using CursoUnitTesting.Business.Entities;
using System.Collections.Generic;

namespace CursoUnitTesting.Business.Interfaces
{
    public interface IProductRepository
    {
         //IList<Product> GetProducts();
         Product GetProductById(int id);
         //void RemoveProduct(int id);
         //void AddProduct(Product product);
         void UpdateProduct(int id, Product product);
        
    }
}
