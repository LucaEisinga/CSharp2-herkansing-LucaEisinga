using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class SettingsViewmodel
    {
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand exportCommand { get; }
        public ICommand importCommand { get; }
        public ICommand resetCommand { get; }
        public ICommand saveSettingsCommand { get; }

        public List<string> exportFormats { get; } = new() { "JSON"};
        public string selectedExportFormat { get; set; } = "JSON";

        public List<Currency> currencies { get; } = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();
        public Currency selectedCurrency
        {
            get => _settingsService.settings.currency;
            set
            {
                _settingsService.settings.currency = value;
                _settingsService.saveSettings();
            }
        }
        

        public SettingsViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;
            _dataService = dataService;

            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            exportCommand = new RelayCommand(_ => export());
            importCommand = new RelayCommand(_ => import());
            resetCommand = new RelayCommand(_ => resetAll());
        }

        private void export()
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                FileName = "export.json",
                Title = "Save Exported Data"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
                };

                var exportData = new
                {
                    transactions = _dataService.loadTransactions(),
                    categories = _dataService.loadCategories()
                };

                var exportJson = JsonSerializer.Serialize(exportData, options);
                File.WriteAllText(saveFileDialog.FileName, exportJson);

                MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void import()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Select Data File to Import"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var importData = JsonSerializer.Deserialize<ImportWrapper>(json);

                    if (importData != null)
                    {
                        _dataService.saveTransactions(importData.transactions ?? new List<Transaction>());
                        _dataService.saveCategories(importData.categories ?? new List<Category>());

                        MessageBox.Show("Data imported successfully.", "Import Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                        _navigationService.navigateTo("Overview");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Import failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void resetAll()
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete all data? This action cannot be undone.",
                "Confirm Reset",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                File.Delete("transactions.json");

                var categories = _dataService.loadCategories().Where(c => !c.canDelete);

                _dataService.saveCategories(categories.ToList());

                _navigationService.navigateTo("Overview");
            }

            
        }

        private class ImportWrapper
        {
            public List<Transaction> transactions { get; set; }
            public List<Category> categories { get; set; }
        }
    }
}

