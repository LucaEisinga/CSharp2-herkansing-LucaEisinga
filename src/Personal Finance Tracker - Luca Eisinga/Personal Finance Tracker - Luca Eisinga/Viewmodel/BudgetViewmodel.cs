using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class BudgetViewmodel
    {
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }

        public List<Budget> budgets { get; private set; }

        public BudgetViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            this._navigationService = navigationService;
            this._settingsService = settingsService;
            this._dataService = dataService;

            this.openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            this.openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            this.openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));

            var categories = this._dataService.loadCategories();
            var transactions = this._dataService.loadTransactions()
                .Where(t => t.transactionType == TransactionType.EXPENSE)
                .ToList();

            this.budgets = categories
                .Select(cat =>
                    {
                        var spent = transactions
                            .Where(t => t.category.guid == cat.guid)
                            .Sum(t => t.amount);

                        return new Budget(cat.name, cat.budgetLimit, spent);                       
                    })
                .ToList();
        }
    }
}
