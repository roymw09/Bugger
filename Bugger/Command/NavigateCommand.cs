using Bugger.Service;
using Bugger.Store;
using Bugger.ViewModel;
using System;

namespace Bugger.Command
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
