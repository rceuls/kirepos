using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kirepos.Models.Database;
using Kirepos.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Kirepos.Repositories
{
    public class ReportRepository
    {
        private readonly KireposDatabaseContext _ctx;
        private readonly IHttpContextAccessor _httpContext;

        public ReportRepository(KireposDatabaseContext ctx, IHttpContextAccessor httpContext)
        {
            _ctx = ctx;
            _httpContext = httpContext;
        }

        public async Task<Report> CreateReport(NewReportViewModel vm)
        {
            var rep = new Report()
            {
                ReportedOn = vm.ReportDate.ToUniversalTime(),
                Description = vm.Description,
                CreatedBy = _httpContext.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                CreatedOn = DateTimeOffset.UtcNow
            };
            await _ctx.Reports.AddAsync(rep);
            await _ctx.SaveChangesAsync();

            return rep;
        }

        public async Task<ReportLine> AddReportLine(Guid id, NewReportLineViewModel model)
        {
            var reportLine = new ReportLine
            {
                Deadline = model.Deadline,
                Description = model.Description,
                Responsible = model.Responsible,
                CreatedBy = _httpContext.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                CreatedOn = DateTimeOffset.UtcNow
            };

            var report = _ctx.Reports.Find(id);

            if (report == default(Report))
            {
                throw new ArgumentException($"Report with id {id} does not exist");
            }

            reportLine.Report = report;

            await _ctx.AddAsync(reportLine);
            await _ctx.SaveChangesAsync();

            return reportLine;
        }
    }
}