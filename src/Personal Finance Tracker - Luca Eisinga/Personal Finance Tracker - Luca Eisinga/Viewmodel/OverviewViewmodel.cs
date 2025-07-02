using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Personal_Finance_Tracker___Luca_Eisinga.Commands;
using Personal_Finance_Tracker___Luca_Eisinga.Service;
using SkiaSharp;
using System.Windows.Input;

namespace Personal_Finance_Tracker___Luca_Eisinga.Viewmodel
{
    internal class OverviewViewmodel
    {
        private readonly INavigationService _navigationService;

        public ICommand openTransactionlistCommand { get; }
        public ICommand openBudgetCommand { get; }
        public ICommand openTransactionformCommand { get; }
        public ICommand openSettingsCommand { get; }
        public ICommand openOverviewCommand { get; }

        public ISeries[] series { get; set; }
        public Axis[] xAxis { get; set; }
        public Axis[] yAxis { get; set; }

        public OverviewViewmodel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.openBudgetCommand = new RelayCommand(_ => _navigationService.navigateTo("Budget"));
            this.openTransactionlistCommand = new RelayCommand(_ => _navigationService.navigateTo("Transactionlist"));
            this.openTransactionformCommand = new RelayCommand(_ => _navigationService.navigateTo("TransactionForm"));
            this.openSettingsCommand = new RelayCommand(_ => _navigationService.navigateTo("Settings"));
            this.openOverviewCommand = new RelayCommand(_ => _navigationService.navigateTo("Overview"));

            var data = GenerateMonthlyData(); // replace with real data source

            series = new ISeries[]
            {
            new StackedColumnSeries<double>
            {
                Name = "Income",
                Values = data.Select(x => x.income).ToArray()
            },
            new StackedColumnSeries<double>
            {
                Name = "Expense",
                Values = data.Select(x => x.expense).ToArray()
            }
            };

            xAxis = new Axis[]
            {
            new Axis
            {
                Labels = data.Select(x => x.month).ToArray(),
                LabelsRotation = 15
            }
            };

            yAxis = new Axis[]
            {
            new Axis
            {
                Labeler = value => $"{value:C0}"
            }
            };
        }

        private List<MonthlyFinance> GenerateMonthlyData()
        {
            return new List<MonthlyFinance>
        {
            // TODO: Automatically pick last 12 months
        };
        }
    }

    public class MonthlyFinance
    {
        public string month { get; set; }
        public double income { get; set; }
        public double expense { get; set; }
    }
}
