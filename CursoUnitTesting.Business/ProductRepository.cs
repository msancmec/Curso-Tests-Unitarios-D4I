using CursoUnitTesting.Business.Entities;
using CursoUnitTesting.Business.Interfaces;
using CursoUnitTesting.Business.SQLDataContext;
using System;
using System.Collections.Generic;

namespace CursoUnitTesting.Business
{
    public class ProductRepository : IProductRepository
    {
        private ISQLDataContext sqlDataContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sqlDataContext"></param>
        public ProductRepository(ISQLDataContext sqlDataContext)
        {
            this.sqlDataContext = sqlDataContext;
        }
        public virtual IList<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            var command = "SELECT * FROM [CursoUnitTesting].[dbo].[Product]";
            sqlDataContext.OpenConnection();
            var reader = sqlDataContext.ExecuteReader(command, null);
            while (reader.Read())
            {
                var product = new Product();
                product.ProductName = reader["ProductName"].ToString();
                product.CategoryID = int.Parse(reader["CategoryID"].ToString());
                product.Created = Convert.ToDateTime(reader["Created"].ToString());
                product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                product.UnitPrice = int.Parse(reader["UnitPrice"].ToString());
                product.UnitsInStock = int.Parse(reader["UnitsInStock"].ToString());
                product.Id = int.Parse(reader["ProductId"].ToString());
                products.Add(product);
            }
            sqlDataContext.CloseConnection();
            return products;
        }
        public Product GetProductById(int id)
        {
            Product product = new Product();
            var command = "SELECT * FROM [CursoUnitTesting].[dbo].[Products] Where ProductId =" + id.ToString();
            sqlDataContext.OpenConnection();
            var reader = sqlDataContext.ExecuteReader(command, null);
            while (reader.Read())
            {
                product.ProductName = reader["ProductName"].ToString();
                product.CategoryID = int.Parse(reader["CategoryID"].ToString());
                product.Created = Convert.ToDateTime(reader["Created"].ToString());
                product.QuantityPerUnit =reader["QuantityPerUnit"].ToString();
                //product.UnitPrice = int.Parse(reader["UnitPrice"].ToString());
                //product.UnitsInStock = int.Parse(reader["UnitsInStock"].ToString());
                product.Id = int.Parse(reader["ProductId"].ToString());
            }
            sqlDataContext.CloseConnection();
            return product;
        }
        //public void RemoveCategory(int id)
        //{
        //    var command = " DELETE FROM [CursoUnitTesting].[dbo].[Products] Where Id =" + id.ToString();
        //    sqlDataContext.OpenConnection();
        //    var reader = sqlDataContext.ExecuteReader(command, null);
        //    sqlDataContext.CloseConnection();
        //}
        //public void AddCategory(Category product)
        //{
        //    var command = "INSERT INTO [CursoUnitTesting].[dbo].[Products] VALUES('" + product.ProductName.ToString() + "','" + product.Description.ToString() + "')";
        //    sqlDataContext.OpenConnection();
        //    var reader = sqlDataContext.ExecuteReader(command, null);
        //    sqlDataContext.CloseConnection();
        //}
        public void UpdateProduct(int id, Product product)
        {
            var command = "UPDATE [CursoUnitTesting].[dbo].[Products] SET ProductName = '" + product.ProductName.ToString() + "',QuantityPerUnit = '" + product.QuantityPerUnit.ToString() + "'WHERE ProductId =" + id.ToString();
            sqlDataContext.OpenConnection();
            var reader = sqlDataContext.ExecuteReader(command, null);
            sqlDataContext.CloseConnection();
        }

    }
}
