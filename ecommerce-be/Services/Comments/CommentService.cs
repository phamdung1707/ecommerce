using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Comments.Request;
using ecommerce_be.Services.Comments.Response;
using ecommerce_be.Services.Users;
using ecommerce_be.Services.Users.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Comments
{
    public class CommentService : ICommentService
    {
        public readonly EcommerceDbContext _context;

        private readonly IUserService _userService;

        public CommentService(EcommerceDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<ApiResult<CommentResponse>> Create(CreateCommentRequest request)
        {
            var product = await _context.Products.FindAsync(request.product_id);

            if (product == null)
            {
                return new ApiErrorResult<CommentResponse>("Sản phẩm không tồn tại");
            }

            Comment comment = new Comment()
            {
                product_id = request.product_id,
                content = request.content,
                user_id = request.user_id,
                create_date = DateTime.Now
            };

            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();

            var response = await _context.Comments.FirstOrDefaultAsync(cmt => cmt.product_id == comment.product_id && cmt.create_date == comment.create_date);

            CommentResponse commentResponse = new CommentResponse()
            {
                id = response.id,
                product_id = response.product_id,
                content = response.content,
                create_date = response.create_date,
                user_comment = (await _userService.GetById(response.user_id)).data
            };

            return new ApiSuccessResult<CommentResponse>("Tạo comment thành công", commentResponse);
        }

        public async Task<ApiResult<List<CommentResponse>>> GetByProductId(long productId)
        {
            var comments = await _context.Comments.Where(cmt => cmt.product_id == productId).ToListAsync();

            List<CommentResponse> commentResponses = new List<CommentResponse>();

            foreach (var comment in comments)
            {
                CommentResponse commentResponse = new CommentResponse()
                {
                    id = comment.id,
                    product_id = comment.product_id,
                    content = comment.content,
                    create_date = comment.create_date,
                    user_comment =  (await _userService.GetById(comment.user_id)).data
                };

                commentResponses.Add(commentResponse);
            }

            return new ApiSuccessResult<List<CommentResponse>>("Lấy danh sách comment theo sản phẩm thành công", commentResponses);
        }
    }
}
