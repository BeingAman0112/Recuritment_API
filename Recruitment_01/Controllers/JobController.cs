using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.infrastructure.Data.IRepository;
using Recuritment.Application.IServices;

namespace Recruitment.Controllers
{
    [Route("api/")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public readonly IJobServices  _jobRepo;
        public JobController(IJobServices jobrepo)
        {
            _jobRepo = jobrepo;
        }

        [HttpGet("GetAllJobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobRepo.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpPost("PostJob")]
        public async Task<IActionResult> PostJob([FromBody] Core.DTO.Job job)
        {
            var jobId = await _jobRepo.PostJobAsync(job);
            return Ok(jobId);
        }

        [HttpGet("SearchJobs")]
        public async Task<IActionResult> SearchJobs([FromQuery] string? title, [FromQuery] string? location, [FromQuery] string? category, [FromQuery] string? type)
        {
            var jobs = await _jobRepo.SearchJobsAsync(title, location, category, type);
            return Ok(jobs);
        }
    }
}
