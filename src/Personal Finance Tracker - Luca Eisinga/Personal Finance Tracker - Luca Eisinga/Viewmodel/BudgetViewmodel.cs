using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class BudgetViewmodel
    {
        // Services for navigation, settings, and data management
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        // Commands for navigation and actions
        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand editCategoryCommand { get; }

        // List of budgets to display
        public List<Budget> budgets { get; set; }

        public BudgetViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            // Initialize services and commands
            _navigationService = navigationService;
            _settingsService = settingsService;
            _dataService = dataService;

            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            editCategoryCommand = new RelayCommand(bud => editCategory(bud as Budget));

            // Load categories and transactions from data service
            var categories = _dataService.loadCategories();
            var transactions = _dataService.loadTransactions()
                .Where(t => t.transactionType == TransactionType.EXPENSE)
                .ToList();

            // Build a category lookup by GUID
            var categoryLookup = categories.ToDictionary(c => c.guid, c => c);

            // Rebind category references in transactions to the loaded categories
            foreach (var tx in transactions)
            {
                if (categoryLookup.TryGetValue(tx.category.guid, out var realCategory))
                {
                    tx.category = realCategory; // Fix reference so the GUIDs match
                }
            }

            // Create budgets for each category, calculating spent amounts
            this.budgets = categories
                .Select(cat =>
                {
                    var spent = transactions
                        .Where(t => t.category.guid == cat.guid)
                        .Sum(t => t.amount * _settingsService.getCurrencyMultiplier());

                    return new Budget(cat, cat.budgetLimit * _settingsService.getCurrencyMultiplier(), spent, _settingsService);
                })
                .ToList();

        }

        private void editCategory(Budget budget)
        {
            // Navigate to the CategoryForm with the selected budget's category
            if (budget != null)
            {
                _navigationService.navigateTo("CategoryForm", budget.category);
            }
        }
    }
}
