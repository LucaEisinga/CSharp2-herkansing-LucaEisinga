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
    internal class CategoryFormViewmodel
    {
        private readonly INavigationService _navigationService;
        private readonly DataService _dataService;
        private readonly Category? _editingCategory;

        public string name { get; set; } = "";
        public decimal budgetLimit { get; set; }

        public ICommand saveCategoryFormCommand { get; }
        public ICommand cancelCategoryFormCommand { get; }
        public ICommand deleteCategoryFormCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand openBudgetCommand { get; }


        public CategoryFormViewmodel(INavigationService navigation, DataService data, Category? editingCatagory)
        {
            _navigationService = navigation;
            _dataService = data;
            _editingCategory = editingCatagory;

            saveCategoryFormCommand = new RelayCommand(_ => saveCategory());
            cancelCategoryFormCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview")); 
            deleteCategoryFormCommand = new RelayCommand(_ => deleteCategory(), _ => _editingCategory != null && _editingCategory.canDelete);
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));

            if (_editingCategory != null)
            {
                // Editing: populate fields with existing data
                name = _editingCategory.name;
                budgetLimit = _editingCategory.budgetLimit;
            }
        }

        private void saveCategory()
        {
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
