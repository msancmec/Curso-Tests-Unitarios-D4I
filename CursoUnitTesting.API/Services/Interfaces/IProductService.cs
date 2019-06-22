using CursoUnitTesting.API.Models;
using CursoUnitTesting.Business.Entities;

namespace CursoUnitTesting.API.Services.Interfaces
{
    public interface IProductService
    {

        Product GetProductById(int id);
        //void RemoveProduct(int id);
        //void AddProduct(Product product);
        void UpdateProduct(int id, Product product);
        Product MapProductRequest(ProductUpdateRequest productUpdateRequest);
        bool CheckFootballProductAvailable(Product product);
    }
}
