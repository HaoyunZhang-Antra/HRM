using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class SubmissionRequestModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose the job id")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "Please choose the candidate id")]
        public int CandidateId { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime? SubmittedOn { get; set; }

        [Required(ErrorMessage = "Please choose the interview day")]
        [DataType(DataType.Date)]
        public DateTime? SelectedForInterview { get; set; }
        public DateTime? RejectedOn { get; set; }
        [Required(ErrorMessage = "The reason is not null, must give one")]
        public string RejectedReason { get; set; }
    }
}
