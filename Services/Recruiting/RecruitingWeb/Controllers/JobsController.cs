using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            // return all the jobs so that candidates can apply to the job
            // we need to get list of jobs
            // call the Job Service
            var jobs = _jobService.GetAllJobs();
            return View();
        }

        [HttpGet]
        //get the job detailed information
        public IActionResult Details(int id)
        {
            // get job by Id
            var job = _jobService.GetJobById(3);
            return View();
        }

        [HttpPost]
        // Authenticated and User should have role for creating new job
        //HR / Manager
        public IActionResult Create() 
        {
            //take the information from the View and save to DB
            return View();
        }
    }
}
