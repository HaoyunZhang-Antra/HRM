using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;

        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllSubmissions()
        {
            var submissions = await _submissionService.GetAllSubmissions();

            if (!submissions.Any())
            {
                // no jobs exists, then 404
                return NotFound(new { error = "No submissions found, please try later" });
            }
            // return Json data, and also HTTP status codes
            // serialization C# objects into Json Objects using System.Text.Json
            return Ok(submissions);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {

            // check if the model is valid, on the server
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            // save the data in database
            // return to the index view 
            await _submissionService.AddSubmission(model);
            return Ok();
        }
    }
}
