using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JobService : IJobService
    {
        public List<JobResponseModel> GetAllJobs()
        {
            //have some dummy data
            var jobs = new List<JobResponseModel>()
            {
                new JobResponseModel{ Id = 1, Title = "Job1", Description = "This is Job1 Description."},
                new JobResponseModel{ Id = 2, Title = "Job2", Description = "This is Job2 Description."},
                new JobResponseModel{ Id = 3, Title = "Job3", Description = "This is Job3 Description."},
                new JobResponseModel{ Id = 4, Title = "Job4", Description = "This is Job4 Description."},
            };

            return jobs;
        }

        public JobResponseModel GetJobById(int id)
        {
            return new JobResponseModel { Id = 5, Title = "test for getjobbyid", Description = "This is test for getjobbyid Description." };
        }
    }
}
