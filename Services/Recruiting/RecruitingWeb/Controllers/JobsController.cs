using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        //show the empty page 
        [HttpGet]
        // Authenticated and User should have role for creating new job
        //HR / Manager
        public async Task<IActionResult> Create() 
        {
            ViewBag.JobStatus = new SelectList(await _jobService.GetAllJobStatus(), "Id", "JobStatusCode");
            //take the information from the View and save to DB
            return View();
        }

        //Saving the job information 
        [HttpPost]
        public async Task<IActionResult> Create(JobRequestModel model)
        {

            // check if the model is valid, on the server
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save the data in database
            // return to the index view 
            await _jobService.AddJob(model);
            return RedirectToAction("Index");
        }

    }
}
