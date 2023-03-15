using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //return all the jobs so that candidates can apply to the job
            return View();
        }

        [HttpGet]
        //get the job detailed information
        public IActionResult Details(int id)
        {
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
