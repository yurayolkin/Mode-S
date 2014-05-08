using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ModeS.ViewModel;
using ModeS.ViewModel.Core;

namespace ModeS.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Messager.Register(this, "AircraftHistory", s =>
            {
                var historyView = new HistoryView();
                historyView.Show();
            });

        }
    }
}
