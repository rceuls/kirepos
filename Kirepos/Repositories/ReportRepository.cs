using System;
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
                CreatedBy = _httpContext.HttpContext?.User?.Identity?.Name,
                CreatedOn =  DateTimeOffset.UtcNow
            };
            await _ctx.Reports.AddAsync(rep);
            await _ctx.SaveChangesAsync();

            return rep;
        }
    }
}