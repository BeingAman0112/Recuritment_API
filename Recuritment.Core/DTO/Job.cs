using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.DTO
{
    public class Job
    {

        public Guid JobID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? SalaryRange { get; set; }
        public string? JobCategory { get; set; }  // Example: IT, Marketing
        public string? JobType { get; set; }      // Example: Full-time, Part-
                                                 
        public string Company { get; set; } = string.Empty;
        // Arrays in Angular → Lists in .NET

        // Store raw from DB
        public string? Requirements { get; set; }
        public string? Benefits { get; set; }

        public bool? IsRemote { get; set; }
        public string ExperienceLevel { get; set; } = string.Empty;

        public string CompanyLogo { get; set; } = string.Empty;

        // Better as nullable DateTime
        public DateTime? ApplicationDeadline { get; set; }

        public string ContactEmail { get; set; } = string.Empty;
        public string CompanyWebsite { get; set; } = string.Empty;

        public Guid? PostedBy { get; set; }
        public DateTime PostedAt { get; set; }

        // Navigation property (optional, if using EF Core)
        public User? PostedByUser { get; set; }
    }
}
