using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class TransactionlistViewmodel
    {
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand applyFilterCommand { get; }
        public ICommand editTransactionCommand { get; }

        public List<Transaction> allTransactions { get; private set; }
        public ObservableCollection<Transaction> filteredTransactions { get; set; }
        public ObservableCollection<Category> categoryFilter { get; set; }
        public Category selectedCategory { get; set; }


        public List<string> sortByOptions { get; } = new() { "Amount", "Date", "Category", "Transaction type" };
        public string selectedSortOption { get; set; }
        public List<TransactionType> transactionTypes { get; } = Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>().ToList();
        public TransactionType? selectedTransactionType { get; set; }

        public TransactionlistViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
            _dataService = dataService;

            categoryFilter = new ObservableCollection<Category>(this._dataService.loadCategories()); 
            allTransactions = _dataService.loadTransactions();
            filteredTransactions = new ObservableCollection<Transaction>(allTransactions);

            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            applyFilterCommand = new RelayCommand(_ => applyFilter());
            editTransactionCommand = new RelayCommand(tx => editTransaction(tx as Transaction));
        }

        private void applyFilter()
        {
            var filtered = allTransactions.AsEnumerable();

            if (selectedCategory != null)
                filtered = filtered.Where(t => t.category?.guid == selectedCategory.guid);

            if (selectedTransactionType != null)
                filtered = filtered.Where(t => t.transactionType == selectedTransactionType);

            filtered = selectedSortOption switch
            {
                "Amount" => filtered.OrderByDescending(t => t.amount),
                "Date" => filtered.OrderByDescending(t => t.date),
                "Category" => filtered.OrderBy(t => t.category.name),
                "Transaction type" => filtered.OrderBy(t => t.transactionType),
                _ => filtered
            };

            filteredTransactions.Clear();
            foreach (var tx in filtered)
                filteredTransactions.Add(tx);
        }

        private void editTransaction(Transaction? transaction)
        {
            if (transaction != null)
                _navigationService.navigateTo("TransactionForm", transaction);
        }
    }
}
