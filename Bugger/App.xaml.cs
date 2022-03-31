using Bugger.DBContext;
using Bugger.Model;
using Bugger.Service;
using Bugger.Service.BugCreator;
using Bugger.Service.BugProvider;
using Bugger.Store;
using Bugger.ViewModel;
using System;
using System.Windows;

namespace Bugger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly BugList _bugs;
        private readonly NavigationStore _navigationStore;        
        public App()
        {
            BugDbContextFactory bugDbContextFactory = new BugDbContextFactory("server=localhost;database=issue_track;username=root;password=password"); // needs connection string
            IBugProvider bugProvider = new DatabaseBugProvider(bugDbContextFactory);
            IBugCreator bugCreator = new DatabaseBugCreator(bugDbContextFactory);
            _bugs = new BugList(bugProvider, bugCreator);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateLoginViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private AddBugViewModel CreateAddBugViewModel()
        {
            return new AddBugViewModel(_bugs, new NavigationService(_navigationStore, CreateBugListViewModel));
        }

        private BugListViewModel CreateBugListViewModel()
        {
            return BugListViewModel.LoadViewModel(_bugs, new NavigationService(_navigationStore, CreateAddBugViewModel));
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return new LoginViewModel(new NavigationService(_navigationStore, CreateBugListViewModel));
        }
    }
}
