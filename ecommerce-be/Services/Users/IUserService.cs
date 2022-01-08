using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Users.Request;
using ecommerce_be.Services.Users.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce_be.Services.Users
{
    public interface IUserService
    {
        Task<ApiResult<User>> Register(RegisterRequest request);
        Task<ApiResult<LoginResponse>> Login(LoginRequest request);
        Task<ApiResult<UserResponse>> GetById(long id);
        Task<ApiResult<User>> Update(User request);
        Task<UserResponse> GetUserById(long id);
    }
}
