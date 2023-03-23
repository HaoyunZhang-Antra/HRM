using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface ISubmissionService
    {
        Task<List<SubmissionResponseModel>> GetAllSubmissions();
        Task<SubmissionResponseModel> GetSubmissionById(int id);
        Task<int> AddSubmission(SubmissionRequestModel model);
        Task<JobResponseModel> GetJobById(int id);
    }
}
