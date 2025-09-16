using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.DTO
{
    public class Applicant
    {
        public Guid ApplicantID { get; set; } 
        public int JobID { get; set; }
        public int UserID { get; set; }
        public string? ResumeLink { get; set; }
        public DateTime AppliedAt { get; set; }

        // Navigation properties (optional, if using EF Core)
        public Job? Job { get; set; }
        public User? User { get; set; }
    }

}
