using ecommerce_be.Common.Response;
using ecommerce_be.Models;
using ecommerce_be.Services.Users.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ecommerce_be.Services.Users.Response;
using ecommerce_be.Security;

namespace ecommerce_be.Services.Users
{
    public class UserService : IUserService
    {
        public readonly EcommerceDbContext _context;

        public UserService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<User>> Register(RegisterRequest request)
        {
            var users = await _context.Users.Where(us => us.phone == request.phone).ToListAsync();

            if (users.Count > 0)
            {
                return new ApiErrorResult<User>("Tài khoản đã tồn tại");
            }

            User user = new User()
            {
                username = request.username,
                password = request.password,
                gmail = request.gmail,
                phone = request.phone,
                address = request.address,
                age = request.age,
                isSeller = request.isSeller,
                description = request.description,
                images = request.images
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            var userRes = await _context.Users.Where(us => us.phone == request.phone).FirstOrDefaultAsync();

            return new ApiSuccessResult<User>("Đăng ký thành công", userRes);
        }

        public async Task<ApiResult<UserResponse>> GetById(long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.id == id);

            if (user == null)
            {
                return new ApiErrorResult<UserResponse>("Tài khoản không tồn tại");
            }

            UserResponse userResponse = new UserResponse()
            {
                id = user.id,
                username = user.username,
                password = "",
                gmail = user.gmail,
                phone = user.phone,
                address = user.address,
                age = user.age,
                isSeller = user.isSeller,
                description = user.description,
                images = user.images
            };

            return new ApiSuccessResult<UserResponse>("Lấy thông tin tài khoản thành công", userResponse);
        }

        public async Task<UserResponse> GetUserById(long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.id == id);

            if (user == null)
            {
                return null;
            }

            UserResponse userResponse = new UserResponse()
            {
                id = user.id,
                username = user.username,
                password = "",
                gmail = user.gmail,
                phone = user.phone,
                address = user.address,
                age = user.age,
                isSeller = user.isSeller,
                description = user.description,
                images = user.images
            };

            return userResponse;
        }

        public async Task<ApiResult<User>> Update(User request)
        {
            var user = await _context.Users.Where(us => us.id == request.id).FirstOrDefaultAsync();

            if (user == null)
            {
                return new ApiErrorResult<User>("Tài khoản không tồn tại");
            }

            user.username = request.username;
            user.password = request.password;
            user.gmail = request.gmail;
            user.phone = request.phone;
            user.address = request.address;
            user.age = request.age;
            user.isSeller = request.isSeller;
            user.description = request.description;
            user.images = request.images;

            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return new ApiSuccessResult<User>("Thay đổi thông tin thành công", user);
        }

        public async Task<ApiResult<LoginResponse>> Login(LoginRequest request)
        {          
            var user = await _context.Users.FirstOrDefaultAsync(u => (u.phone == request.phone) && (u.password == request.password));

            if (user == null)
            {
                return new ApiErrorResult<LoginResponse>("Thông tin tài khoản hoặc mật khẩu không chính xác");
            }

            //string tokenLogin = JwtAuth.Authentication(user.id, user.phone);

            var response = new LoginResponse()
            {
                accessToken = user.id.ToString()
            };

            return new ApiSuccessResult<LoginResponse>("Đăng nhập thành công", response);
        }
    }
}
