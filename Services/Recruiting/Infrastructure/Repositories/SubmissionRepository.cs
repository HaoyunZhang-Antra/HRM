using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Submission>> GetAllSubmissions()
        {
            var submissions = await _dbContext.Submissions.ToListAsync();
            return submissions;
        }

        public async Task<Job> GetJobById(int id)
        {
            var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
            return job;
        }

        public async Task<Submission> GetSubmissionById(int id)
        {
            var submission = await _dbContext.Submissions.FirstOrDefaultAsync(s => s.Id == id);
            return submission;
        }
    }
}
