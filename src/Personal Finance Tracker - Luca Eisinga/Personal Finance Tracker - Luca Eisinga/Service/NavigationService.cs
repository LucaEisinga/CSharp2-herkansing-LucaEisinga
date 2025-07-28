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
using Personal_Finance_Tracker___Luca_Eisinga.Model;

namespace Personal_Finance_Tracker___Luca_Eisinga.Service
{
    internal class NavigationService : INavigationService, INotifyPropertyChanged
    {
        // Services for settings and data management
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        public NavigationService(SettingsService settingsService, DataService dataService)
        {
            // Initialize services
            _settingsService = settingsService;
            _dataService = dataService;
        }

        // Current view being displayed in the application
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

        public void navigateTo(string viewKey, object? parameter = null)
        {
            // Validate the viewKey and set the CurrentView based on it
            CurrentView = viewKey switch
            {
                "Overview" => new OverviewView { DataContext = new OverviewViewmodel(this, this._settingsService, this._dataService)},
                "Transactionlist" => new TransactionlistView { DataContext = new TransactionlistViewmodel(this, this._settingsService, this._dataService) },
                "TransactionForm" => new TransactionFormView { DataContext = new TransactionFormViewmodel(this, this._settingsService, this._dataService, parameter as Transaction) },
                "Budget" => new BudgetView { DataContext = new BudgetViewmodel(this, this._settingsService, this._dataService) },
                "Settings" => new SettingsView { DataContext = new SettingsViewmodel(this, this._settingsService, this._dataService) },
                "CategoryForm" => new CategoryFormView { DataContext = new CategoryFormViewmodel(this, this._dataService, parameter as Category) },
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
