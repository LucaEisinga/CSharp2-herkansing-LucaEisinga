using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personal_Finance_Tracker___Luca_Eisinga.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var settingsService = new Service.SettingsService();
            var dataService = new Service.DataService();
            var navigationService = new Service.NavigationService(settingsService, dataService);

            var data = dataService.loadCategories();

            if (data.Count == 0)
            {
                var categories = new List<Model.Category>
                {
                    new Model.Category("Other", 1000, false),
                    new Model.Category("Food", 1000, false),
                    new Model.Category("Transport", 1000, false),
                    new Model.Category("Entertainment", 1000, false)
                };

                dataService.saveCategories(categories);
            }

            navigationService.navigateTo("Overview");

            DataContext = new { Navigation = navigationService };
        }
    }
}
