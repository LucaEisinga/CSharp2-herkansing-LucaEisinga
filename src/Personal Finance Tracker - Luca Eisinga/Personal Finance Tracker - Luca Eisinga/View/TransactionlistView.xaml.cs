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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personal_Finance_Tracker___Luca_Eisinga.View
{
    /// <summary>
    /// Interaction logic for TransactionlistView.xaml
    /// </summary>
    public partial class TransactionlistView : UserControl
    {
        public TransactionlistView()
        {
            InitializeComponent();
            DataContext = new Viewmodel.TransactionlistViewmodel();
        }
    }
}
