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
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;
        public SubmissionService(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        
        public async Task<List<SubmissionResponseModel>> GetAllSubmissions()
        {
            var submissions = await _submissionRepository.GetAllAsync();

            var submissionsResponseModel = new List<SubmissionResponseModel>();
            foreach (var submission in submissions)
                submissionsResponseModel.Add(new SubmissionResponseModel
                {
                    Id = submission.Id,
                    JobId = submission.JobId,
                    CandidateId = submission.CandidateId,
                    SubmittedOn = submission.SubmittedOn.GetValueOrDefault(),
                    SelectedForInterview = submission.SelectedForInterview,
                    RejectedOn = submission.RejectedOn,
                    RejectedReason = submission.RejectedReason,
                });

            return submissionsResponseModel;
        }

        public async Task<SubmissionResponseModel> GetSubmissionById(int id)
        {
            var submission = await _submissionRepository.GetSubmissionById(id);
            var submissionResponseModel = new SubmissionResponseModel
            {
                Id = submission.Id,
                JobId = submission.JobId,
                CandidateId = submission.CandidateId,
                SubmittedOn = submission.SubmittedOn.GetValueOrDefault(),
                SelectedForInterview = submission.SelectedForInterview,
                RejectedOn = submission.RejectedOn,
                RejectedReason = submission.RejectedReason,
            };
            return submissionResponseModel;
        }

        public async Task<int> AddSubmission(SubmissionRequestModel model)
        {
            // call the repository that will use EF Core to save the data
            var submissionEntity = new Submission
            {
                Id = model.Id,
                CandidateId = model.CandidateId,
                JobId = model.JobId,
                SubmittedOn = model.SubmittedOn.GetValueOrDefault(),
                SelectedForInterview = model.SelectedForInterview,
                RejectedOn = model.RejectedOn,
                RejectedReason = model.RejectedReason,

            };

            var submission = await _submissionRepository.AddAsync(submissionEntity);
            return submission.Id;
        }

        public async Task<JobResponseModel> GetJobById(int id)
        {
            var job = await _submissionRepository.GetJobById(id);
            var jobResponseModel = new JobResponseModel
            {
                Id = job.Id,
                Title = job.Title,
                StartDate = job.StartDate.GetValueOrDefault(),
                Description = job.Description
            };
            return jobResponseModel;
        }
    }
}
