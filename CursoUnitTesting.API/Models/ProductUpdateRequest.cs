using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CursoUnitTesting.API.Models
{
    public class ProductUpdateRequest
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a customer status")]
        [RegularExpression(@"^(0|[1-9][0-9]*)$", ErrorMessage = "Please provide a valid account number")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a customer status")]
        public string ProductName { get; set; }

        [RegularExpression(@"^(0|[1-9][0-9]*)$", ErrorMessage = "Please provide a valid QuantityPerUnit")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a customer status")]
        public int UnitPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a customer status")]
        public int UnitsInStock { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a customer status")]
        public int UnitsOnOrder { get; set; }
    }
}

