using Bugger.Model;
using Bugger.Service;
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
            _bugs = new BugList();
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateBugListViewModel();

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
            return new BugListViewModel(_bugs, new NavigationService(_navigationStore, CreateAddBugViewModel));
        }
    }
}
