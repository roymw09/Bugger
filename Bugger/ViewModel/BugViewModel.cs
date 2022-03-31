using Bugger.Model;

namespace Bugger.ViewModel
{
    public class BugViewModel : ViewModelBase
    {
        private readonly Bug _bug;
        public string BugID => _bug.BugID;
        public string Assignee => _bug.Assignee;
        public string Status => _bug.Status;
        public string Description => _bug.Description;
        public string FixDescription => _bug.FixDescription;
        public string DateRaised => _bug.DateRaised;
        public string DateClosed => _bug.DateClosed;

        public BugViewModel(Bug bug)
        {
            _bug = bug;
        }
    }
}
