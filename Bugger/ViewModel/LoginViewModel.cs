using Bugger.Command;
using Bugger.Model;
using Bugger.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bugger.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string hostName;
        public string HostName
        {
            get
            {
                return hostName;
            }
            set
            {
                hostName = value;
                onPropertyChanged(nameof(HostName));
            }
        }

        private string databaseName;
        public string DatabaseName
        {
            get
            {
                return databaseName;
            }
            set
            {
                databaseName = value;
                onPropertyChanged(nameof(DatabaseName));
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                onPropertyChanged(nameof(Username));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                onPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public LoginViewModel(NavigationService loginViewNavigationService)
        {
            LoginCommand = new NavigateCommand(loginViewNavigationService);
        }
    }
}
