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
        public async Task<IActionResult> Index()
        {
            // return all the jobs so that candidates can apply to the job
            // we need to get list of jobs
            // call the Job Service

            // 3 ways to send data from controller/action method to view
            // 1. ViewBag
            // 2. ViewData

            // most prefered way 3. Strongly Typed Model data
            var jobs = await _jobService.GetAllJobs();
            return View(jobs);
        }

        [HttpGet]
        //get the job detailed information
        public async Task<IActionResult> Details(int id)
        {
            // get job by Id
            var job = await _jobService.GetJobById(id);
            return View(job);
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
