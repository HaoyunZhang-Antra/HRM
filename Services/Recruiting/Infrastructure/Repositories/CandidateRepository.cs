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
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<Candidate>> GetAllCandidates()
        {
            var candidates = await _dbContext.Candidates.ToListAsync();
            return candidates;
        }
    }
}
