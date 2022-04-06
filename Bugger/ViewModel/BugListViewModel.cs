using Bugger.Command;
using Bugger.DBContext;
using Bugger.Model;
using Bugger.Service;
using Bugger.Service.BugCreator;
using Bugger.Service.BugProvider;
using Bugger.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bugger.ViewModel
{
    public class BugListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<BugViewModel> _bugs;
        public IEnumerable<BugViewModel> Bugs => _bugs;

        public ICommand LoadBugCommand { get; }
        public ICommand CreateBugCommand { get; }

        private string hostname;
        private string database;
        private string username;
        private string password;

        private BugDbContextFactory bugDbContextFactory;
        private IBugProvider bugProvider;
        private IBugCreator bugCreator;

        public BugListViewModel(BugList bugList, NavigationService addBugViewNavigationService)
        {
            _bugs = new ObservableCollection<BugViewModel>();

            LoadBugCommand = new LoadBugCommand(this, bugList);
            CreateBugCommand = new NavigateCommand(addBugViewNavigationService);
        }

        public BugListViewModel(BugList bugList, NavigationService addBugViewNavigationService, LoginViewModel loginViewModel)
        {
            hostname = loginViewModel.HostName;
            database = loginViewModel.DatabaseName;
            username = loginViewModel.Username;
            password = loginViewModel.Password;
            bugDbContextFactory = new BugDbContextFactory("server="+hostname+
                ";database="+database+";username="+username+";password="+password); // needs connection string
            bugProvider = new DatabaseBugProvider(bugDbContextFactory);
            bugCreator = new DatabaseBugCreator(bugDbContextFactory);
            bugList = new BugList(bugProvider, bugCreator);

            _bugs = new ObservableCollection<BugViewModel>();

            LoadBugCommand = new LoadBugCommand(this, bugList);
            CreateBugCommand = new NavigateCommand(addBugViewNavigationService);
        }

        public static BugListViewModel LoadViewModel(BugList bugList, NavigationService addBugViewNavigationService, LoginViewModel loginViewModel)
        {
            BugListViewModel viewModel = new BugListViewModel(bugList, addBugViewNavigationService, loginViewModel);

            viewModel.LoadBugCommand.Execute(null);
            return viewModel;
        }

        public void UpdateBugList(IEnumerable<Bug> bugs)
        {
            _bugs.Clear();
            if (bugs != null)
            {
                foreach (Bug bug in bugs)
                {
                    BugViewModel bugViewModel = new BugViewModel(bug);
                    _bugs.Add(bugViewModel);
                }
            }
        }
    }
}
