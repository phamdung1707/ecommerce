using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Models;
using ecommerce_be.Services.Products;
using ecommerce_be.Services.Products.Requests;

namespace ecommerce_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var result = await _productService.CreateProduct(request);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Product request)
        {
            var result = await _productService.UpdateProduct(request);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _productService.GetById(id);

            return Ok(result);
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _productService.DeleteProduct(id);

            return Ok(result);
        }

        [HttpGet("find/{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _productService.FindByName(name);

            return Ok(result);
        }
    }
}
