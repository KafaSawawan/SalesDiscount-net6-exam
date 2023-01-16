using Microsoft.Extensions.DependencyInjection;
using SalesDiscountFrontend.ViewModels;
using SaveMoneyApp.Models;
using SaveMoneyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesDiscountFrontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISalesDiscountService _salesDiscountService;
        private readonly IServiceProvider _serviceProvider;
        private ObservableCollection<SalesDiscountViewModel> _salesDiscountViewModels;

        public MainWindow(ISalesDiscountService salesDiscountService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            _salesDiscountService = salesDiscountService;
            _serviceProvider = serviceProvider;
            _salesDiscountViewModels = new ObservableCollection<SalesDiscountViewModel>();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModels = (await _salesDiscountService.GetTasksAsync())
                .Select(sd => new SalesDiscountViewModel
                {
                    ID = sd.ID,
                    Name = sd.Name,
                    Description = sd.Description,
                    Avavible = sd.Avavible
                });
            _salesDiscountViewModels = new ObservableCollection<SalesDiscountViewModel>(viewModels);
            var collection = _salesDiscountViewModels;
            SalesDiscountList.ItemsSource = collection;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = SalesDiscountList.SelectedItem as SalesDiscountViewModel;
            if(selectedItem != null)
            {
                await _salesDiscountService.DeleteTaskAsync(selectedItem.ID);
                _salesDiscountViewModels.Remove(selectedItem);
            }
        }
    }
}
