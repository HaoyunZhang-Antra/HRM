using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<List<CandidateResponseModel>> GetAllCandidates()
        {
            var candidates = await _candidateRepository.GetAllAsync();

            var candidatesResponseModel = new List<CandidateResponseModel>();
            foreach (var candidate in candidates)
                candidatesResponseModel.Add(new CandidateResponseModel
                {
                    Id = candidate.Id,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                });

            return candidatesResponseModel;
        }
    }
}
