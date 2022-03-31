using Bugger.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.DBContext
{
    public class BugDbContext : DbContext
    {
        public BugDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BugDTO> Bugs { get; set; }
    }
}
