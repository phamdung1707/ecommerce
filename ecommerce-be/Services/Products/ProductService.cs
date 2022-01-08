using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Products.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Products
{
    public class ProductService : IProductService
    {
        public readonly EcommerceDbContext _context;

        public ProductService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<Product>> CreateProduct(CreateProductRequest request)
        {
            var products = await _context.Products.Where(product => product.title_name == request.title_name && product.user_id == request.user_id).ToListAsync();

            if (products.Count > 0)
            {
                return new ApiErrorResult<Product>("Sản phẩm đã tồn tại");
            }

            Product product = new Product()
            {
                title_name = request.title_name,
                images = request.images,
                colors = request.colors,
                price = request.price,
                type = request.type,
                isFavourite = request.isFavorite,
                isPopular = request.isPopular,
                description = request.description,
                user_id = request.user_id
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            var response = await _context.Products.FirstOrDefaultAsync(product => product.title_name == request.title_name && product.user_id == request.user_id);

            return new ApiSuccessResult<Product>("Tạo sản phẩm thành công", response);
        }

        public async Task<ApiResult<Product>> UpdateProduct(Product request)
        {
            var product = await _context.Products.FindAsync(request.id);

            if (product == null)
            {
                return new ApiErrorResult<Product>("Sản phẩm không tồn tại");
            }

            product.title_name = request.title_name;
            product.images = request.images;
            product.colors = request.colors;
            product.price = request.price;
            product.type = request.type;
            product.isFavourite = request.isFavourite;
            product.isPopular = request.isPopular;
            product.description = request.description;
            product.user_id = request.user_id;

            _context.Products.Update(product);

            await _context.SaveChangesAsync();


            return new ApiSuccessResult<Product>("Cập nhật sản phẩm thành công", product);
        }

        public async Task<ApiResult<List<Product>>> GetAll()
        {
            var products = await _context.Products.ToListAsync();

            return new ApiSuccessResult<List<Product>>("Lấy danh sách sản phẩm thành công", products);
        }

        public async Task<ApiResult<Product>> GetById(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.id == id);

            if (product == null)
            {
                return new ApiErrorResult<Product>("Sản phẩm không tồn tại");
            }

            return new ApiSuccessResult<Product>("Lấy thông tin sản phẩm thành công", product);
        }

        public async Task<ApiResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.id == id);

            if (product == null)
            {
                return new ApiErrorResult<Product>("Sản phẩm không tồn tại");
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<Product>("Xóa sản phẩm thành công", null);
        }

        public async Task<ApiResult<List<Product>>> FindByName(string name)
        {
            var products = await _context.Products.Where(product => product.title_name.ToLower().Contains(name.ToLower().Trim())).ToListAsync();

            return new ApiSuccessResult<List<Product>>("Lấy danh sách sản phẩm thành công", products);
        }

        public async Task<List<Product>> GetAllTest()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
