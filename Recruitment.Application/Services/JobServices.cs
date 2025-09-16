using Recruitment.Core.DTO;
using Recruitment.infrastructure.Data;
using Recruitment.infrastructure.Data.IRepository;
using Recuritment.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recuritment.Application.Services
{
    public class JobServices : IJobServices
    {
        public readonly IJobs _jobs;
        public JobServices(IJobs jobs)
        {
            _jobs = jobs;
        }
        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobs.GetAllJobsAsync();
        }

        public async Task<Guid> PostJobAsync(Job job)
        {
            return await _jobs.PostJobAsync(job);
        }

        public async Task<IEnumerable<Job>> SearchJobsAsync(string? title, string? location, string? category, string? type)
        {
            return await _jobs.SearchJobsAsync(title , location , category , type);
        }
    }
}

