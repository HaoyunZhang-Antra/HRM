﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<List<JobResponseModel>> GetAllJobs()
        {
           var jobs = await _jobRepository.GetAllJobs();
           
           var jobsResponseModel = new List<JobResponseModel>();
           foreach (var job in jobs)
                jobsResponseModel.Add(new JobResponseModel
                {
                    Id = job.Id,
                    Description = job.Description,
                    Title = job.Title,
                    StartDate = job.StartDate.GetValueOrDefault(),
                    NumberOfPositions = job.NumberOfPositions
                });

            return jobsResponseModel;
        }

        public async Task<JobResponseModel> GetJobById(int id)
        {
            var job = await _jobRepository.GetJobById(id);
            var jobResponseModel = new JobResponseModel
            {
                Id = job.Id,
                Title = job.Title,
                StartDate = job.StartDate.GetValueOrDefault(),
                Description = job.Description
            };
            return jobResponseModel;
        }

        public async Task<int> AddJob(JobRequestModel model)
        {

            // call the repository that will use EF Core to save the data
            var jobEntity = new Job
            {
                Title = model.Title,
                StartDate = model.StartDate,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                NumberOfPositions = model.NumberOfPositions,
                JobStatusLookUpId = model.JobStatusLookUpId,

            };

            var job = await _jobRepository.AddAsync(jobEntity);
            return job.Id;
        }

        public async Task<List<JobStatusResponseModel>> GetAllJobStatus()
        {
            var jobstatus = await _jobRepository.GetAllJobStatus();

            var JobStatusResponseModel = new List<JobStatusResponseModel>();
            foreach (var jobst in jobstatus)
                JobStatusResponseModel.Add(new JobStatusResponseModel
                {
                    Id = jobst.Id,
                    JobStatusCode= jobst.JobStatusCode,
                    JobStatusDescription= jobst.JobStatusDescription,   
                    
                });

            return JobStatusResponseModel;
        }

       
    }
}
