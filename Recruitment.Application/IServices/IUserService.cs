using Recruitment.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuritment.Application.IServices
{
    public interface IUserService
    {
        public Task<string?> SignUp(UserSignupDto request);

        public Task<string?> Login(string email, string password);
    }
}
