using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Products.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Products
{
    public interface IProductService
    {
        Task<ApiResult<Product>> GetById(long id);
        Task<ApiResult<List<Product>>> GetAll();
        Task<ApiResult<Product>> CreateProduct(CreateProductRequest request);
        Task<ApiResult<Product>> UpdateProduct(Product request);
        Task<ApiResult<Product>> DeleteProduct(long id);
        Task<ApiResult<List<Product>>> FindByName(string name);
        Task<List<Product>> GetAllTest();
        Task<ApiResult<List<Product>>> GetByUserId(long id);
    }
}
