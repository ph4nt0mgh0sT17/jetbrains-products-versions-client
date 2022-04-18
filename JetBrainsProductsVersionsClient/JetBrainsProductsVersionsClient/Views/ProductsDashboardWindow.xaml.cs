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
using CommunityToolkit.Mvvm.DependencyInjection;
using JetBrainsProductsVersionsClient.ViewModels;

namespace JetBrainsProductsVersionsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProductsDashboardWindow : Window
    {
        public ProductsDashboardWindow()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ProductsDashboardViewModel>();
        }

        public ProductsDashboardViewModel ViewModel
        {
            get
            {
                if (DataContext is ProductsDashboardViewModel productsDashboardViewModel)
                    return productsDashboardViewModel;

                throw new InvalidOperationException("DataContext of this windows must be ProductsDashboardViewModel.");
            }
        }
    }
}