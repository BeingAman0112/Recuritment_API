using Dapper;
using Recruitment.Core.DTO;
using Recruitment.infrastructure.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.infrastructure.Data.Repository
{
    public  class Jobs : IJobs
    {
        public readonly DbContext _dbContext;

        public Jobs(DbContext dbContext)
        {
              _dbContext = dbContext;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            var query = "EXEC sp_GetAllJobs";
            return await _dbContext.Connection.QueryAsync<Job>(query);
        }

        public async Task<Guid> PostJobAsync(Job job)
        {
            var query = "EXEC sp_PostJob @Title, @Company, @Location, @JobType, @SalaryRange, @JobCategory, " +
                        "@Description, @Requirements, @IsRemote, @ExperienceLevel, @Benefits, " +
                        "@CompanyLogo, @ApplicationDeadline, @ContactEmail, @CompanyWebsite, @PostedBy";

            var parameters = new DynamicParameters();
            parameters.Add("@Title", job.Title);
            parameters.Add("@Company", job.Company);
            parameters.Add("@Location", job.Location);
            parameters.Add("@JobType", job.JobType);
            parameters.Add("@SalaryRange", job.SalaryRange);
            parameters.Add("@JobCategory", job.JobCategory);
            parameters.Add("@Description", job.Description);

            // Lists → store as comma-separated string or JSON
            parameters.Add("@Requirements", job.Requirements);
            parameters.Add("@IsRemote", job.IsRemote);
            parameters.Add("@ExperienceLevel", job.ExperienceLevel);
            parameters.Add("@Benefits", job.Benefits);

            parameters.Add("@CompanyLogo", job.CompanyLogo);
            parameters.Add("@ApplicationDeadline", job.ApplicationDeadline);
            parameters.Add("@ContactEmail", job.ContactEmail);
            parameters.Add("@CompanyWebsite", job.CompanyWebsite);
            parameters.Add("@PostedBy", job.PostedBy);

            // Return the newly created JobID (GUID)
            return await _dbContext.Connection.ExecuteScalarAsync<Guid>(query, parameters);
        }


        public async Task<IEnumerable<Job>> SearchJobsAsync(string? title, string? location, string? category, string? type)
        {
            var query = "EXEC sp_GetJobsByFilter @Title, @Location, @JobCategory, @JobType";
            return await _dbContext.Connection.QueryAsync<Job>(query, new
            {
                Title = title,
                Location = location,
                JobCategory = category,
                JobType = type
            });
        }
    }
}
