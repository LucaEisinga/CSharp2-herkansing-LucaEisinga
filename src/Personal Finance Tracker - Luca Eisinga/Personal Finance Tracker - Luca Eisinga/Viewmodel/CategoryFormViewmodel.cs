using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public CategoryFormViewmodel(INavigationService navigation, DataService data, Category? editingCatagory)
        {
            _navigationService = navigation;
            _dataService = data;
            _editingCategory = editingCatagory;

            saveCategoryFormCommand = new RelayCommand(_ => saveCategory());
            cancelCategoryFormCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview")); 
            deleteCategoryFormCommand = new RelayCommand(_ => deleteCategory(), _ => _editingCategory != null);
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
                var newCategory = new Category(name, budgetLimit);
                _dataService.addCategory(newCategory);
            }

            _navigationService.navigateTo("Overview");
        }

        private void deleteCategory()
        {
            if (_editingCategory != null)
            {
                _dataService.deleteCategory(_editingCategory);
                _navigationService.navigateTo("Transactionlist");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
