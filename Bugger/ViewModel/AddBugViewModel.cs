using Bugger.Command;
using Bugger.Model;
using Bugger.Service;
using Bugger.Store;
using System;
using System.Windows.Input;

namespace Bugger.ViewModel
{
    public class AddBugViewModel : ViewModelBase
    {
        private readonly Bug _bug;

        public int BugID => _bug.BugID;
        public string Assignee => _bug.Assignee;

        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                onPropertyChanged(nameof(Status));
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                onPropertyChanged(nameof(Description));
            }
        }

        public ICommand AddBugCommand { get; }
        public ICommand CancelAddBugCommand { get; }

        public AddBugViewModel(BugList bugList, NavigationService bugListViewNavigationService)
        {
            AddBugCommand = new AddBugCommand(this, bugList, bugListViewNavigationService);
            CancelAddBugCommand = new NavigateCommand(bugListViewNavigationService);
        }
    }
}
