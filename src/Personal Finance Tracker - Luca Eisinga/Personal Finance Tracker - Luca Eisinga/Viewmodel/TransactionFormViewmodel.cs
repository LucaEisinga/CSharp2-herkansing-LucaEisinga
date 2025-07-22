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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class TransactionFormViewmodel
    {
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand saveTransactionFormCommand { get; }
        public ICommand cancelTransanctionFormCommand { get; }
        public ICommand deleteTransactionFormCommand { get; }

        private readonly Transaction? _editingTransaction;

        public List<Category> categories { get; set; }
        public Category selectedCategory { get; set; }

        public List<TransactionType> transactionTypes { get; set; }
        public TransactionType selectedTransactionType { get; set; }

        public string description { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }

        public TransactionFormViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService, Transaction? transaction)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
            _dataService = dataService;
            _editingTransaction = transaction;

            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            saveTransactionFormCommand = new RelayCommand(_ => saveTransaction());
            cancelTransanctionFormCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            deleteTransactionFormCommand = new RelayCommand(_ => deleteTransaction(), _ => _editingTransaction != null);

            categories = _dataService.loadCategories();
            transactionTypes = Enum.GetValues(typeof(TransactionType))
                .Cast<TransactionType>()
                .ToList();

            if (_editingTransaction != null)
            {
                // Pre-fill form values
                date = _editingTransaction.date;
                amount = _editingTransaction.amount;
                description = _editingTransaction.description;
                selectedCategory = categories.FirstOrDefault(c => c.guid == _editingTransaction.category.guid);
                selectedTransactionType = _editingTransaction.transactionType;
            }
            else
            {
                date = DateTime.Now;
            }
        }

        private void saveTransaction()
        {
            if (_editingTransaction != null)
            {
                _editingTransaction.date = date;
                _editingTransaction.amount = amount;
                _editingTransaction.description = description;
                _editingTransaction.category = selectedCategory;
                _editingTransaction.transactionType = selectedTransactionType;

                _dataService.updateTransaction(_editingTransaction);
            }
            else
            {
                var newTransaction = new Transaction(date, amount, description, selectedCategory, selectedTransactionType);
                _dataService.addTransaction(newTransaction);
            }

            _navigationService.navigateTo("Overview");
        }

        private void deleteTransaction()
        {
            if (_editingTransaction != null)
            {
                _dataService.deleteTransaction(_editingTransaction);
                _navigationService.navigateTo("Transactionlist"); // Navigate to transaction list after deletion
            } 
            else
            {
                _navigationService.navigateTo("Overview");// If no transaction is being edited, just navigate back
            }

            
        }
    }
}
