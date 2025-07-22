using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Personal_Finance_Tracker___Luca_Eisinga.Service
{
    internal interface INavigationService : INotifyPropertyChanged
    {
        UserControl? CurrentView { get; }

        void navigateTo(string viewKey, object? parameter = null);
    }
}
