using Bugger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.Service.BugProvider
{
    public interface IBugProvider
    {
        Task<IEnumerable<Bug>> getAllBugs();
    }
}
