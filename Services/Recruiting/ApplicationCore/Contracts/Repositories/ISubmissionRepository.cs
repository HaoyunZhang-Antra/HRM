using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ISubmissionRepository : IBaseRepository<Submission>
    {
        Task<List<Submission>> GetAllSubmissions();
        Task<Submission> GetSubmissionById(int id);
        Task<Job> GetJobById(int id);
    }
}
