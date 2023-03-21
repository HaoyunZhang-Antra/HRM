using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class JobRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Title of Job")]
        [StringLength(56)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Job Description")]
        [StringLength(5000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Job StartDate")]
        //start date cannot be in the cast
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter Job NumberOfPositions")]
        public int NumberOfPositions { get; set; }
    }
}
