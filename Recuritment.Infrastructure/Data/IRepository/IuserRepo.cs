using Recruitment.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.infrastructure.Data.IRepository
{
    public interface IuserRepo
    {
        public Task<User?> GetUserByEmail(string email);

        public Task<int> AddUser(User user);
    }
}
