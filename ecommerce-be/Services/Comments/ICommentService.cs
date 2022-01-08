using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Comments.Request;
using ecommerce_be.Services.Comments.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Comments
{
    public interface ICommentService
    {
        Task<ApiResult<CommentResponse>> Create(CreateCommentRequest request);
        Task<ApiResult<List<CommentResponse>>> GetByProductId(long productId);
    }
}
