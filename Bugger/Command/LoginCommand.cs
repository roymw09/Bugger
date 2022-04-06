using Bugger.DBContext;
using Bugger.Model;
using Bugger.Service;
using Bugger.Service.BugCreator;
using Bugger.Service.BugProvider;
using Bugger.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.Command
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationService _loginNavigationService;

        public LoginCommand(LoginViewModel loginViewModel, NavigationService loginNavigationService)
        {
            _loginViewModel = loginViewModel;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _loginNavigationService = loginNavigationService;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.HostName) && base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _loginNavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.HostName))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
