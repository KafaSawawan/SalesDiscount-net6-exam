using Microsoft.Extensions.DependencyInjection;
using SaveMoneyApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SalesDiscountFrontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceCollection collection = new ServiceCollection();

            // Configuration
            collection.AddTransient<MainWindow>();
            collection.AddSingleton<ISalesDiscountService, SalesDiscountService>();

            var serviceProvider = collection.BuildServiceProvider();
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.ShowDialog();
        }
        
    }
}
