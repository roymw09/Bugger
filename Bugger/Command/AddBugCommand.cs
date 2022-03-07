using Bugger.Model;
using Bugger.Service;
using Bugger.ViewModel;
using System.ComponentModel;

namespace Bugger.Command
{
    public class AddBugCommand : CommandBase
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

        public override void Execute(object parameter)
        {
            Bug bug = new Bug(1, "Roy", _addBugViewModel.Status, _addBugViewModel.Description, "2022-03-01");
            _bugs.AddBug(bug);
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
