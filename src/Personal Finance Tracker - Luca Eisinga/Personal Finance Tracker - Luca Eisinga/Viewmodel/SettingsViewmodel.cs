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

        public List<string> exportFormats { get; } = new() { "JSON", "CSV" };
        public string selectedExportFormat { get; set; } = "JSON";

        public List<Currency> Currencies { get; } = Enum.GetValues(typeof(Currency)).Cast<Currency>().ToList();
        public Currency SelectedCurrency
        {
            get => _settingsService.settings.currency;
            set
            {
                _settingsService.settings.currency = value;
                _settingsService.saveSettings();
            }
        }
        public bool isDarkTheme
        {
            get => _settingsService.settings.theme == Theme.DARK;
            set
            {
                _settingsService.settings.theme = value ? Theme.DARK : Theme.LIGHT;
                _settingsService.applyTheme();
                _settingsService.saveSettings();
            }
        }

        public SettingsViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            this._navigationService = navigationService;
            this._settingsService = settingsService;
            this._dataService = dataService;

            this.openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            this.openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            this.openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            this.exportCommand = new RelayCommand(_ => export());
            this.importCommand = new RelayCommand(_ => import());
            this.resetCommand = new RelayCommand(_ => resetAll());
        }

        private void export()
        {
            var exportDir = "export";
            Directory.CreateDirectory(exportDir);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            var transactions = _dataService.loadTransactions();
            var categories = _dataService.loadCategories();

            var transactionsJson = JsonSerializer.Serialize(transactions, options);
            File.WriteAllText(Path.Combine(exportDir, "transactions.json"), transactionsJson);

            var categoriesJson = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(Path.Combine(exportDir, "categories.json"), categoriesJson);

        }

        private void import()
        {
            // You can load JSON files from the "import" folder
            if (File.Exists("import/transactions.json"))
            {
                var tx = JsonSerializer.Deserialize<List<Transaction>>(File.ReadAllText("import/transactions.json"));
                _dataService.saveTransactions(tx);
            }

            if (File.Exists("import/categories.json"))
            {
                var cat = JsonSerializer.Deserialize<List<Category>>(File.ReadAllText("import/categories.json"));
                _dataService.saveCategories(cat);
            }
        }

        private void resetAll()
        {
            File.Delete("transactions.json");
            File.Delete("categories.json");
        }
    }
}

