using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class TransactionFormViewmodel : INotifyPropertyChanged
    {
        // Services for navigation, settings, and data management
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        // Commands for navigation and actions
        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand saveTransactionFormCommand { get; }
        public ICommand cancelTransanctionFormCommand { get; }
        public ICommand deleteTransactionFormCommand { get; }

        // The transaction being edited, if any
        private readonly Transaction? _editingTransaction;

        // List of categories for the dropdown
        public List<Category> categories { get; set; }
        public Category selectedCategory { get; set; }

        // List of transaction types (income/expense)
        public List<TransactionType> transactionTypes { get; set; }
        public TransactionType selectedTransactionType { get; set; }

        // Form fields
        public string description { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }

        // Error messages for validation
        private string _categoryError;
        public string categoryError
        {
            get => _categoryError;
            set
            {
                _categoryError = value;
                OnPropertyChanged(nameof(categoryError));
            }
        }

        private string _amountError;
        public string amountError
        {
            get => _amountError;
            set
            {
                _amountError = value;
                OnPropertyChanged(nameof(amountError));
            }
        }

        private string _dateError;
        public string dateError
        {
            get => _dateError;
            set
            {
                _dateError = value;
                OnPropertyChanged(nameof(dateError));
            }
        }

        private string _descriptionError;
        public string descriptionError
        {
            get => _descriptionError;
            set
            {
                _descriptionError = value;
                OnPropertyChanged(nameof(descriptionError));
            }
        }


        public TransactionFormViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService, Transaction? transaction)
        {
            // Initialize services and commands
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

            // Load categories and transaction types
            categories = _dataService.loadCategories();
            transactionTypes = Enum.GetValues(typeof(TransactionType))
                .Cast<TransactionType>()
                .ToList();

            // Check if we are editing an existing transaction
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
            bool hasError = false;

            // Clear previous errors
            categoryError = amountError = dateError = descriptionError = "";

            // Validate form fields
            if (selectedCategory == null)
            {
                categoryError = "Please select a category.";
                hasError = true;
            }

            if (amount <= 0)
            {
                amountError = "Amount must be a positive number.";
                hasError = true;
            }

            if (date == default)
            {
                dateError = "Please select a valid date.";
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                descriptionError = "Description is required.";
                hasError = true;
            }

            // Stop if validation failed
            if (hasError) return;

            // If we reach here, all validations passed
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
            // If we are editing a transaction, delete it
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
