using Bugger.DBContext;
using Bugger.DTO;
using Bugger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.Service.BugCreator
{
    // this class turns Bug models in to BugDTO models
    public class DatabaseBugCreator : IBugCreator
    {
        private readonly BugDbContextFactory _bugDbContextFactory;

        public DatabaseBugCreator(BugDbContextFactory bugDbContextFactory)
        {
            _bugDbContextFactory = bugDbContextFactory;
        }
        public async Task CreateBug(Bug bug)
        {
            using (BugDbContext context = _bugDbContextFactory.CreateDbContext())
            {
                BugDTO bugDTO = ToBugDTO(bug);

                context.Bugs.Add(bugDTO);
                await context.SaveChangesAsync();
            }
        }

        private BugDTO ToBugDTO(Bug bug)
        {
            return new BugDTO()
            {
                Assignee = bug.Assignee,
                Status = bug.Status,
                Description = bug.Description,
                FixDescription = bug.FixDescription,
                DateRaised = bug.DateRaised,
                DateClosed = bug.DateClosed
            };
        }
    }
}
