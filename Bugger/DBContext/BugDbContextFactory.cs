using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.DBContext
{
    public class BugDbContextFactory
    {
        private readonly string _connectionString;

        public BugDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BugDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseMySQL(_connectionString).Options;

            return new BugDbContext(options);
        }
    }
}
