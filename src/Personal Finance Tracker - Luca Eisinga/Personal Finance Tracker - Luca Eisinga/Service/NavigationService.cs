using Personal_Finance_Tracker___Luca_Eisinga.Viewmodel;
using Personal_Finance_Tracker___Luca_Eisinga.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Personal_Finance_Tracker___Luca_Eisinga.Service
{
    internal class NavigationService : INavigationService, INotifyPropertyChanged
    {
        private UserControl? _currentView;

        public UserControl? CurrentView
        {
            get => _currentView;
            private set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }

        public void navigateTo(string viewKey)
        {
            CurrentView = viewKey switch
            {
                "Overview" => new OverviewView { DataContext = new OverviewViewmodel(this)},
                "Transactionlist" => new TransactionlistView { DataContext = new TransactionlistViewmodel(this) },
                "TransactionForm" => new TransactionFormView { DataContext = new TransactionFormViewmodel(this) },
                "Budget" => new BudgetView { DataContext = new BudgetViewmodel(this) },
                "Settings" => new SettingsView { DataContext = new SettingsViewmodel(this) },
                _ => throw new ArgumentException("Invalid view key: {viewKey}", nameof(viewKey))
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
