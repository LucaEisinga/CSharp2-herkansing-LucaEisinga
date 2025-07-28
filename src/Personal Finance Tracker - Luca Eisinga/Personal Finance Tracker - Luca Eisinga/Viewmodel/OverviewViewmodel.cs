using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Model;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class OverviewViewmodel
    {
        // Services for navigation, settings, and data management
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        // Commands for navigation and actions
        public ICommand openTransactionlistCommand { get; }
        public ICommand openBudgetCommand { get; }
        public ICommand openTransactionformCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand openCategoryFormCommand { get; }

        // Collection of recent transactions for display
        public ObservableCollection<TransactionDisplay> recentTransactions { get; set; }

        // Properties for charting data
        public ISeries[] series { get; set; }
        public Axis[] xAxis { get; set; }
        public Axis[] yAxis { get; set; }

        // Financial summary properties
        public decimal totalIncome { get; private set; }
        public decimal totalExpenses { get; private set; }
        public decimal balance { get { return totalIncome - totalExpenses; } }
        public string totalIncomeFormatted => totalIncome.ToString("C", _settingsService.getCultureInfo());
        public string totalExpensesFormatted => totalExpenses.ToString("C", _settingsService.getCultureInfo());
        public string balanceFormatted => balance.ToString("C", _settingsService.getCultureInfo());

        public OverviewViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            // Initialize services and commands
            _navigationService = navigationService;
            _settingsService = settingsService;
            _dataService = dataService;

            openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            openTransactionlistCommand = new RelayCommand(_ => _navigationService.navigateTo("Transactionlist"));
            openTransactionformCommand = new RelayCommand(_ => _navigationService.navigateTo("TransactionForm"));
            openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            openCategoryFormCommand = new RelayCommand(_ => _navigationService.navigateTo("CategoryForm"));

            // Retrieve and process data
            var data = _dataService.loadTransactions();

            totalIncome = data
                .Where(t => t.transactionType == Enums.TransactionType.INCOME)
                .Sum(t => t.amount * _settingsService.getCurrencyMultiplier());

            totalExpenses = data
                .Where(t => t.transactionType == Enums.TransactionType.EXPENSE)
                .Sum(t => t.amount * _settingsService.getCurrencyMultiplier());

            // Create recent transactions collection
            recentTransactions = new ObservableCollection<TransactionDisplay>(
                data
                    .OrderByDescending(t => t.date)
                    .Take(20)
                    .Select(t => new TransactionDisplay(t, _settingsService))
            );

            // Prepare chart data
            var grouped = data
            .Where(t => t.date >= DateTime.Now.AddMonths(-11)) // Last 12 months
            .GroupBy(t => new DateTime(t.date.Year, t.date.Month, 1))
            .OrderBy(g => g.Key)
            .ToList();

            var months = grouped.Select(g => g.Key).ToList();
            var income = grouped.Select(g => g.Where(t => t.transactionType == Enums.TransactionType.INCOME).Sum(t => t.amount)).ToList();
            var expenses = grouped.Select(g => g.Where(t => t.transactionType == Enums.TransactionType.EXPENSE).Sum(t => t.amount)).ToList();

            // Create series and axes for the chart and format the values
            series = new ISeries[]
            {
                new StackedColumnSeries<decimal>
                {
                    Name = "Income",
                    Values = income
                },
                new StackedColumnSeries<decimal>
                {
                    Name = "Expense",
                    Values = expenses
                }
            };

            xAxis = new Axis[]
            {
                new Axis
                {

                    Labels = months.Select(d => d.ToString("MMM yyyy", CultureInfo.InvariantCulture)).ToArray(),
                    LabelsRotation = 15
                }
            };

            yAxis = new Axis[]
            {
                new Axis
                {
                    Labeler = value => value.ToString("C", _settingsService.getCultureInfo()),
                }
            };
        }
    } 
}
