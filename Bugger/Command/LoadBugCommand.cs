using Bugger.Model;
using Bugger.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bugger.Command
{
    public class LoadBugCommand : AsyncCommandBase
    {
        private readonly BugListViewModel _bugListViewModel;
        private readonly BugList _bugList;

        public LoadBugCommand(BugListViewModel bugListViewModel, BugList bugList)
        {
            _bugListViewModel = bugListViewModel;
            _bugList = bugList;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Bug> bugs = await _bugList.GetBugList();
                _bugListViewModel.UpdateBugList(bugs);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load bugs.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
