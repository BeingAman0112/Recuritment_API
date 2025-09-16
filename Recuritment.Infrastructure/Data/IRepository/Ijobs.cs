using Recruitment.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.infrastructure.Data.IRepository
{
    public interface IJobs
    {
        public Task<IEnumerable<Job>> GetAllJobsAsync();
        public Task<Guid> PostJobAsync(Job job);
        public Task<IEnumerable<Job>> SearchJobsAsync(string? title, string? location, string? category, string? type);

    }
}
