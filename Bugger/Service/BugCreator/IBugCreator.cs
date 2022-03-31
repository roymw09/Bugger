using Bugger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.Service.BugCreator
{
    public interface IBugCreator
    {
        Task CreateBug(Bug bug);
    }
}
