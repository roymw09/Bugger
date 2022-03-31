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

        public string BugID => _bug.BugID;

        private string assignee;
        public string Assignee
        {
            get
            {
                return assignee;
            }
            set
            {
                assignee = value;
                onPropertyChanged(nameof(Assignee));
            }
        }

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

        private string fixDescription;
        public string FixDescription
        {
            get
            {
                return fixDescription;
            }
            set
            {
                fixDescription = value;
                onPropertyChanged(nameof(FixDescription));
            }
        }

        private string dateRaised;
        public string DateRaised
        {
            get
            {
                return dateRaised;
            }
            set
            {
                dateRaised = value;
                onPropertyChanged(nameof(DateRaised));
            }
        }

        private string dateClosed;
        public string DateClosed
        {
            get
            {
                return dateClosed;
            }
            set
            {
                dateClosed = value;
                onPropertyChanged(nameof(DateClosed));
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
