using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class CategoryFormViewmodel : INotifyPropertyChanged
    {
        // Services for navigation and data management
        private readonly INavigationService _navigationService;
        private readonly DataService _dataService;
        private readonly Category? _editingCategory;

        // Commands for navigation and actions
        public ICommand saveCategoryFormCommand { get; }
        public ICommand cancelCategoryFormCommand { get; }
        public ICommand deleteCategoryFormCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand openBudgetCommand { get; }

        // Form fields
        public string name { get; set; } = "";
        public decimal budgetLimit { get; set; }

        // Error messages for validation
        private string _nameError;
        public string nameError
        {
            get => _nameError;
            set
            {
                _nameError = value;
                OnPropertyChanged(nameof(nameError));
            }
        }

        private string _limitError;
        public string limitError
        {
            get => _limitError;
            set
            {
                _limitError = value;
                OnPropertyChanged(nameof(limitError));
            }
        }

        public CategoryFormViewmodel(INavigationService navigation, DataService data, Category? editingCatagory)
        {
            // Initialize services and commands
            _navigationService = navigation;
            _dataService = data;
            _editingCategory = editingCatagory;

            saveCategoryFormCommand = new RelayCommand(_ => saveCategory());
            cancelCategoryFormCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview")); 
            deleteCategoryFormCommand = new RelayCommand(_ => deleteCategory(), _ => _editingCategory != null && _editingCategory.canDelete);
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));

            // Check if we are editing an existing category
            if (_editingCategory != null)
            {
                // Editing: populate fields with existing data
                name = _editingCategory.name;
                budgetLimit = _editingCategory.budgetLimit;
            }
        }

        private void saveCategory()
        {
            bool hasError = false;

            // Reset error messages
            nameError = limitError = "";

            // Validate form fields
            if (string.IsNullOrWhiteSpace(name))
            {
                nameError = "Name cannot be empty.";
                hasError = true;
            }
            else if (name.Length > 50)
            {
                nameError = "Name cannot exceed 50 characters.";
                hasError = true;
            }
            if (budgetLimit < 1)
            {
                limitError = "Budget limit must be 1 or higher.";
                hasError = true;
            }
            else if (budgetLimit > 1000000)
            {
                limitError = "Budget limit cannot exceed 1,000,000.";
                hasError = true;
            }

            // Stop if validation failed
            if (hasError) return;

            // If we reach here, all validations passed
            if (_editingCategory != null)
            {
                // Editing: update existing fields
                _editingCategory.name = name;
                _editingCategory.budgetLimit = budgetLimit;

                _dataService.updateCategory(_editingCategory);
            }
            else
            {
                var newCategory = new Category(name, budgetLimit, true);
                _dataService.addCategory(newCategory);
            }

            _navigationService.navigateTo("Overview");
        }

        private void deleteCategory()
        {
            // If we are deleting a category, we need to reassign its transactions to "Other" (A.K.A. the default) and then delete the category
            if (_editingCategory != null)
            {
                var transactions = _dataService.loadTransactions();
                var category = _dataService.loadCategories().Where(c => c.name == "Other");

                foreach (var tx in transactions)
                {
                    if (tx.category.guid == _editingCategory.guid)
                    {
                        tx.category = category.FirstOrDefault();
                    }
                }

                _dataService.saveTransactions(transactions.ToList());
                _dataService.deleteCategory(_editingCategory);
                _navigationService.navigateTo("Budget");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
