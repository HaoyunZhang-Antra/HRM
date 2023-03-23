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
    public class JobRepository: BaseRepository<Job>, IJobRepository
    {
        public JobRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Job>> GetAllJobs()
        {
            //go to the database and get the data
            //EF Core with LINQ
            var jobs = await _dbContext.Jobs.ToListAsync();
            return jobs; 
        }

        public async Task<List<JobStatusLookUp>> GetAllJobStatus()
        {
            var jobstatus = await _dbContext.JobStatusLookUps.ToListAsync();
            return jobstatus;
        }

        public async Task<Job> GetJobById(int id)
        {
            var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == id);
            return job;
        }
    }
}
