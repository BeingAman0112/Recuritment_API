using Dapper;
using Microsoft.Extensions.Configuration;
using Recruitment.Core.DTO;
using Recruitment.infrastructure.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.infrastructure.Data.Repository
{
    public class UserRepo : IuserRepo
    {
        public readonly DbContext _dbContext;

        public UserRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Connection.QueryFirstOrDefaultAsync<User>(
            "SELECT * FROM Users WHERE Email = @Email", new { Email = email });
        }

        public async Task<int> AddUser(User user)
        {
            string sql = @"INSERT INTO Users (UserID, Name, Email, PasswordHash, Role, CreatedAt)
                       VALUES (@UserID, @Name, @Email, @PasswordHash, @Role, @CreatedAt)";
            return await _dbContext.Connection.ExecuteAsync(sql, user);
        }
    }
}
