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
        private readonly LoginViewModel _loginViewModel;
        private BugListViewModel bugListViewModel;
        public App()
        {
            _bugs = new BugList(null, null);
            _navigationStore = new NavigationStore();
            _loginViewModel = new LoginViewModel(new NavigationService(_navigationStore, CreateBugListViewModel));
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
            return new AddBugViewModel(_bugs, new NavigationService(_navigationStore, CreateBugListViewModel), _loginViewModel);
        }

        private BugListViewModel CreateBugListViewModel()
        {
            return BugListViewModel.LoadViewModel(_bugs, new NavigationService(_navigationStore, CreateAddBugViewModel), _loginViewModel);
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return _loginViewModel;
        }
    }
}
