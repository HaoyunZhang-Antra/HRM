using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class SubmissionResponseModel
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public DateTime? SubmittedOn { get; set; }
        public DateTime? SelectedForInterview { get; set; }
        public DateTime? RejectedOn { get; set; }
        public string RejectedReason { get; set; }
    }
}
