using Azure.Core;
using Microsoft.Extensions.Configuration;
using Recruitment.Core.DTO;
using Recruitment.infrastructure.Data.IRepository;
using Recruitment.infrastructure.Data.Repository;
using Recuritment.Application.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Recuritment.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IuserRepo _userRepo;
        private readonly JWT_FILE _auth;
        //private readonly IMapper _mapper;

        public UserService(IuserRepo userRepo , JWT_FILE auth)
        {
            _userRepo = userRepo;
            _auth = auth;
            //_mapper = mapper;

        }


        public async Task<string?> SignUp(UserSignupDto  request)
        {
            var existingUser = await _userRepo.GetUserByEmail(request.Email);
            if (existingUser != null) return "User already exists";

            //var user = _mapper.Map<User>(request);
            var user = new User
            {
                UserID = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = HashPassword(request.Password),
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };

            // ✅ Hash password separately (AutoMapper ignores this field)
            user.PasswordHash = HashPassword(request.Password);

            await _userRepo.AddUser(user);
            return "User registered successfully";
        }


        // 🔹 Login
        public async Task<string?> Login(string email, string password)
        {
            var user = await _userRepo.GetUserByEmail(email);
            if (user == null) return null;

            if (!VerifyPassword(password, user.PasswordHash)) return null;

            return _auth.GenerateJwtToken(user);
        }


        // 🔹 Password Hashing
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }

    }
}
