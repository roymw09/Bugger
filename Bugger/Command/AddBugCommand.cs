using Bugger.Model;
using Bugger.Service;
using Bugger.ViewModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Bugger.Command
{
    public class AddBugCommand : AsyncCommandBase
    {
        private readonly AddBugViewModel _addBugViewModel;
        private readonly BugList _bugs;
        private readonly NavigationService _addBugViewNavigationService;

        public AddBugCommand(AddBugViewModel addBugViewModel, BugList bugs, NavigationService addBugViewNavigationService)
        {
            _addBugViewModel = addBugViewModel;
            _bugs = bugs;
            _addBugViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _addBugViewNavigationService = addBugViewNavigationService;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_addBugViewModel.Description) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Bug bug = new Bug("1", _addBugViewModel.Assignee, _addBugViewModel.Status, _addBugViewModel.Description, _addBugViewModel.FixDescription, _addBugViewModel.DateClosed, _addBugViewModel.DateClosed);
            await _bugs.AddBug(bug);
            _addBugViewNavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddBugViewModel.Description))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
