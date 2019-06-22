using System;

namespace CursoUnitTesting.Business.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public string CustomerStatus { get; set; }

        public int CategoryID { get; set; }

        public DateTime Created { get; set; }

        public double UnitPrice {get;set;}

        public int UnitsOnOrder { get; set; }

        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }

        public int UnitsInStock { get; set; }
    }
}

