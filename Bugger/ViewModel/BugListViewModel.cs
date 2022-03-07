using Bugger.Command;
using Bugger.Model;
using Bugger.Service;
using Bugger.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bugger.ViewModel
{
    public class BugListViewModel : ViewModelBase
    {
        private BugList bugList;
        private readonly ObservableCollection<BugViewModel> _bugs;
        public IEnumerable<BugViewModel> Bugs => _bugs;

        public ICommand CreateBugCommand { get; }

        public BugListViewModel(BugList bugList, NavigationService addBugViewNavigationService)
        {
            this.bugList = bugList;
            _bugs = new ObservableCollection<BugViewModel>();

            CreateBugCommand = new NavigateCommand(addBugViewNavigationService);

            UpdateBugList();
        }

        private void UpdateBugList()
        {
            _bugs.Clear();
            foreach (var bug in bugList.GetBugList())
            {
                BugViewModel bugViewModel = new BugViewModel(bug);
                _bugs.Add(bugViewModel);
            }
        }
    }
}
