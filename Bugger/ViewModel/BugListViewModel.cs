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

        public ICommand LoadBugCommand { get; }
        public ICommand CreateBugCommand { get; }

        public BugListViewModel(BugList bugList, NavigationService addBugViewNavigationService)
        {
            _bugs = new ObservableCollection<BugViewModel>();

            LoadBugCommand = new LoadBugCommand(this, bugList);
            CreateBugCommand = new NavigateCommand(addBugViewNavigationService);
        }

        public static BugListViewModel LoadViewModel(BugList bugList, NavigationService addBugViewNavigationService)
        {
            BugListViewModel viewModel = new BugListViewModel(bugList, addBugViewNavigationService);

            viewModel.LoadBugCommand.Execute(null);
            return viewModel;
        }

        public void UpdateBugList(IEnumerable<Bug> bugs)
        {
            _bugs.Clear();
            foreach (Bug bug in bugs)
            {
                BugViewModel bugViewModel = new BugViewModel(bug);
                _bugs.Add(bugViewModel);
            }
        }
    }
}
