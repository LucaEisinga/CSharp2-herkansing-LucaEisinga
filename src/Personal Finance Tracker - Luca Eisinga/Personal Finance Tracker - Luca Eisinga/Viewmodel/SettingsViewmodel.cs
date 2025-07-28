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
        // Services for navigation, settings, and data management
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        // Commands for navigation and actions
        public ICommand openBudgetCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand exportCommand { get; }
        public ICommand importCommand { get; }
        public ICommand resetCommand { get; }
        public ICommand saveSettingsCommand { get; }

        // Export formats
        public List<string> exportFormats { get; } = new() { "JSON"};
        public string selectedExportFormat { get; set; } = "JSON";

        // Currency settings
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
            // Initialize services and commands
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
            // Open a save file dialog to select the location for export
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                FileName = "export.json",
                Title = "Save Exported Data"
            };

            // Check if the user selected a file
            if (saveFileDialog.ShowDialog() == true)
            {
                // Create a JsonSerializerOptions instance to handle serialization settings
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
                };

                // Prepare the data to export
                var exportData = new
                {
                    transactions = _dataService.loadTransactions(),
                    categories = _dataService.loadCategories()
                };

                // Serialize the data to JSON
                var exportJson = JsonSerializer.Serialize(exportData, options);
                File.WriteAllText(saveFileDialog.FileName, exportJson);

                MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void import()
        {
            // Open a file dialog to select the JSON file for import
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Select Data File to Import"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Read the JSON file and deserialize it into the ImportWrapper class
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var importData = JsonSerializer.Deserialize<ImportWrapper>(json);

                    // Check if the import data is valid
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
            // Confirm with the user before resetting all data
            var result = MessageBox.Show(
                "Are you sure you want to delete all data? This action cannot be undone.",
                "Confirm Reset",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            // If the user confirms, delete the transactions file and reset categories
            if (result == MessageBoxResult.Yes)
            {
                File.Delete("transactions.json");

                // Load existing categories and filter out those that cannot be deleted
                var categories = _dataService.loadCategories().Where(c => !c.canDelete);

                _dataService.saveCategories(categories.ToList());

                _navigationService.navigateTo("Overview");
            }

            
        }

        // Wrapper class for import data to match the expected structure
        private class ImportWrapper
        {
            public List<Transaction> transactions { get; set; }
            public List<Category> categories { get; set; }
        }
    }
}

