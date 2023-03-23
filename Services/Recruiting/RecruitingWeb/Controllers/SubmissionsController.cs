using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecruitingWeb.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var submissions = await _submissionService.GetAllSubmissions();
            return View(submissions);
        }

        //show the empty page 
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            Console.WriteLine(id);
            var job = await _submissionService.GetJobById(id);
            //take the information from the View and save to DB
            ViewBag.Job = job;
            //ViewData["Job"] = job;
            //ViewData["Title"] = job.;
            return View();
        }

        //Saving the job information 
        [HttpPost]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            
            // check if the model is valid, on the server
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save the data in database
            // return to the index view 
            await _submissionService.AddSubmission(model);
            return RedirectToAction("Index");
        }
    }
}
