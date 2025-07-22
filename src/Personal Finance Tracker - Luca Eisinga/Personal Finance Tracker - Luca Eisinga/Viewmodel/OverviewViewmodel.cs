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
        private readonly INavigationService _navigationService;
        private readonly SettingsService _settingsService;
        private readonly DataService _dataService;

        public ICommand openTransactionlistCommand { get; }
        public ICommand openBudgetCommand { get; }
        public ICommand openTransactionformCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }
        public ICommand openCategoryFormCommand { get; } 

        public ObservableCollection<Transaction> recentTransactions { get; set; }

        public ISeries[] series { get; set; }
        public Axis[] xAxis { get; set; }
        public Axis[] yAxis { get; set; }

        public decimal totalIncome { get; private set; }
        public decimal totalExpenses { get; private set; }
        public decimal balance { get { return totalIncome - totalExpenses; } }

        public OverviewViewmodel(INavigationService navigationService, SettingsService settingsService, DataService dataService)
        {
            this._navigationService = navigationService;
            this._settingsService = settingsService;
            this._dataService = dataService;

            this.openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            this.openTransactionlistCommand = new RelayCommand(_ => _navigationService.navigateTo("Transactionlist"));
            this.openTransactionformCommand = new RelayCommand(_ => _navigationService.navigateTo("TransactionForm"));
            this.openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            this.openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));
            this.openCategoryFormCommand = new RelayCommand(_ => _navigationService.navigateTo("CategoryForm"));

            var data = this._dataService.loadTransactions();

            this.totalIncome = data
                .Where(t => t.transactionType == Enums.TransactionType.INCOME)
                .Sum(t => t.amount);

            this.totalExpenses = data
                .Where(t => t.transactionType == Enums.TransactionType.EXPENSE)
                .Sum(t => t.amount);

            recentTransactions = new ObservableCollection<Transaction>(
                data.OrderByDescending(t => t.date).Take(20)
            );

            var grouped = data
            .Where(t => t.date >= DateTime.Now.AddMonths(-11)) // Last 12 months
            .GroupBy(t => new DateTime(t.date.Year, t.date.Month, 1))
            .OrderBy(g => g.Key)
            .ToList();

            var months = grouped.Select(g => g.Key).ToList();
            var income = grouped.Select(g => g.Where(t => t.transactionType == Enums.TransactionType.INCOME).Sum(t => t.amount)).ToList();
            var expenses = grouped.Select(g => g.Where(t => t.transactionType == Enums.TransactionType.EXPENSE).Sum(t => t.amount)).ToList();

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
