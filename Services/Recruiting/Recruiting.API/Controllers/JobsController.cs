using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Recruiting.API.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // add references for ApplicationCore and Infra Projects
        // copy all the DI registrations including DbContext into API project program.cs
        // copy the connection string from MVC appSettings to API appSettings

        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // http:localhost/api/jobs
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();

            if (!jobs.Any())
            {
                // no jobs exists, then 404
                return NotFound(new { error = "No open Jobs found, please try later" });
            }
            // return Json data, and also HTTP status codes
            // serialization C# objects into Json Objects using System.Text.Json
            return Ok(jobs);
        }

        // http:localhost/api/jobs/4
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new { errorMessage = "No Job found for this id " });
            }

            return Ok(job);
        }

        //[HttpGet]
        //[Route("Create")]
        //public async Task<IActionResult> Create()
        //{
        //    //ViewBag.JobStatus = new SelectList(await _jobService.GetAllJobStatus(), "Id", "JobStatusCode");
        //    //take the information from the View and save to DB
        //    return Created();
        //}

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            
            // save the data in database
            // return to the index view 
            await _jobService.AddJob(model);
            return Ok();
        }
    }
}
