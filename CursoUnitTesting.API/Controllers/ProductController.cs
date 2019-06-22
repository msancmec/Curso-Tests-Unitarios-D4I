using CursoUnitTesting.API.Models;
using CursoUnitTesting.API.Services.Interfaces;
using CursoUnitTesting.Business.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CursoUnitTesting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "product1", "product2" };
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <returns></returns>
        [HttpPost("update")]
        public IActionResult UpdateProduct([FromBody]ProductUpdateRequest productUpdateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                Product product = _productService.MapProductRequest(productUpdateRequest);

                _productService.UpdateProduct(productUpdateRequest.Id, product);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return Ok();
        }

        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <returns></returns>
        [HttpGet("checkFootballProduct")]
        public IActionResult CheckFootballProductAvailable(int id)
        {
            bool isFootballProduct = false;
            try
            {
                Product product = _productService.GetProductById(id);
                isFootballProduct = _productService.CheckFootballProductAvailable(product);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is ArgumentException)
                {
                    return BadRequest();
                }
                if (ex.Message.Contains("False"))
                {
                    return Ok(false);
                }

                return StatusCode(500);
            }

            return Ok(isFootballProduct);
        }

        public Product Get(int id)
        {
            Product product;
            product = _productService.GetProductById(id);
            return product;
        }

        // POST api/values
        //public void Post([FromBody]Product value)
        //{
        //    _productService.AddProduct(value);
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]Product value)
        //{
        //    _productService.UpdateProduct(id, value);
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //    _productService.RemoveProduct(id);
        //}

    }
}
