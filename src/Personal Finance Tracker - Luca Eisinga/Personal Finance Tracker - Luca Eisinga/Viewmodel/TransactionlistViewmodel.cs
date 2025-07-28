using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class TransactionlistViewmodel
    {
        // Services for navigation, settings, and data management
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        // Commands for navigation and actions
        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand applyFilterCommand { get; }
        public ICommand editTransactionCommand { get; }

        // List of all transactions and filtered transactions
        public List<Transaction> allTransactions { get; private set; }
        public ObservableCollection<TransactionDisplay> filteredTransactions { get; set; }

        // List of categories for filtering
        public ObservableCollection<Category> categoryFilter { get; set; }
        public Category selectedCategory { get; set; }

        // Sorting options and selected sort option
        public List<string> sortByOptions { get; } = new() { "Amount", "Date", "Category", "Transaction type" };
        public string selectedSortOption { get; set; }
        public List<TransactionType> transactionTypes { get; } = Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>().ToList();
        public TransactionType? selectedTransactionType { get; set; }

        public TransactionlistViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            // Initialize services and commands
            _navigationService = navigationService;
            _settingsService = settingsService;
            _dataService = dataService;

            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            applyFilterCommand = new RelayCommand(_ => applyFilter());
            editTransactionCommand = new RelayCommand(tx => editTransaction(tx as TransactionDisplay));

            // Initialize properties and load data
            categoryFilter = new ObservableCollection<Category>(this._dataService.loadCategories()); 
            allTransactions = _dataService.loadTransactions();
            filteredTransactions = new ObservableCollection<TransactionDisplay>();

            // Format and filter transactions for display
            foreach (var tx in allTransactions)
            {
                filteredTransactions.Add(new TransactionDisplay(tx, _settingsService));
            }


            
        }

        private void applyFilter()
        {
            // Apply filters based on selected category and transaction type
            var filtered = allTransactions.AsEnumerable();

            if (selectedCategory != null)
                filtered = filtered.Where(t => t.category?.guid == selectedCategory.guid);

            if (selectedTransactionType != null)
                filtered = filtered.Where(t => t.transactionType == selectedTransactionType);

            // Sort the filtered transactions based on the selected sort option
            filtered = selectedSortOption switch
            {
                "Amount" => filtered.OrderByDescending(t => t.amount),
                "Date" => filtered.OrderByDescending(t => t.date),
                "Category" => filtered.OrderBy(t => t.category.name),
                "Transaction type" => filtered.OrderBy(t => t.transactionType),
                _ => filtered
            };

            // Clear the existing filtered transactions and add the newly filtered ones
            filteredTransactions.Clear();
            foreach (var tx in filtered)
            {
                var txFormatted = new TransactionDisplay(tx, _settingsService);
                filteredTransactions.Add(txFormatted);
            }
        }

        private void editTransaction(TransactionDisplay? transaction)
        {
            // Navigate to the TransactionForm with the selected transaction for editing
            if (transaction != null);
                _navigationService.navigateTo("TransactionForm", transaction.transaction);
        }
    }
}
