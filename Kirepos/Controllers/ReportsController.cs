using System;
using System.Threading.Tasks;
using Kirepos.Models.ViewModels;
using Kirepos.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kirepos.Controllers
{
    [Route("/reports")]
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly ReportRepository _reportRepository;

        public ReportsController(ReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View(new NewReportViewModel { ReportDate = DateTime.UtcNow });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            return View();
        }
        
        [HttpPost]
        [Route("/reports/{id}")]
        public async Task<IActionResult> CreateNew([FromForm]NewReportViewModel model)
        {
            var report = await _reportRepository.CreateReport(model);
            return Redirect($"/reports/{report.Id}");
        }
    }
}