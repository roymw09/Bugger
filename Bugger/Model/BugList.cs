using Bugger.Service.BugCreator;
using Bugger.Service.BugProvider;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bugger.Model
{
    public class BugList
    {
        private readonly IBugProvider _bugProvider;
        private readonly IBugCreator _bugCreator;
        private readonly ObservableCollection<Bug> _bugsObservable;
        public ObservableCollection<Bug> BugsObservable => _bugsObservable;

        public BugList(IBugProvider bugProvider, IBugCreator bugCreator)
        {
            _bugProvider = bugProvider;
            _bugCreator = bugCreator;
        }

        public async Task<IEnumerable<Bug>> GetBugList()
        {
            return await _bugProvider.getAllBugs();
        }

        public async Task AddBug(Bug bug)
        {
            await _bugCreator.CreateBug(bug);
        }
    }
}
