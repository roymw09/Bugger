using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bugger.Model
{
    public class BugList
    {
        private readonly ObservableCollection<Bug> _bugsObservable;
        public ObservableCollection<Bug> BugsObservable => _bugsObservable;

        public BugList()
        {
            _bugsObservable = new ObservableCollection<Bug>();
        }

        public void AddBug(Bug bug)
        {
            _bugsObservable.Add(bug);
        }

        public ObservableCollection<Bug> GetBugList()
        {
            return _bugsObservable;
        }
    }
}
