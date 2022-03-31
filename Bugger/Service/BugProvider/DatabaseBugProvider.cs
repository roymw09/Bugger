using Bugger.DBContext;
using Bugger.DTO;
using Bugger.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.Service.BugProvider
{
    // this class turns BugDTO models in to Bug models
    public class DatabaseBugProvider : IBugProvider
    {
        private readonly BugDbContextFactory _bugDbContextFactory;

        public DatabaseBugProvider(BugDbContextFactory bugDbContextFactory)
        {
            _bugDbContextFactory = bugDbContextFactory;
        }

        public async Task<IEnumerable<Bug>> getAllBugs()
        {
            using (BugDbContext context = _bugDbContextFactory.CreateDbContext())
            {
                IEnumerable<BugDTO> bugDTOs = await context.Bugs.ToListAsync();

                return bugDTOs.Select(bugDTO => ToBug(bugDTO));
            }
        }

        public static Bug ToBug(BugDTO dto)
        {
            return new Bug(dto.Id.ToString(), dto.Assignee, dto.Status, dto.Description, dto.FixDescription, dto.DateRaised, dto.DateClosed);
        }
    }
}
