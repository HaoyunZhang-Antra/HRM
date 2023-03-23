using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _candidateService;
        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var candidates = await _candidateService.GetAllCandidates();
            return View(candidates);
        }
    }
}
