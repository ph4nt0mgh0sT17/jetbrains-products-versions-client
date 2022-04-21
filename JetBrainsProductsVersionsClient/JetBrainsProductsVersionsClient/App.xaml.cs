using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using JetBrainsProductsVersionsClient.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace JetBrainsProductsVersionsClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(ConfigureServices());
            ToolTipServiceExtensions.SetupToolTipService();
        }

        private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddLogger()
                .AddAllRepositories()
                .AddAllServices()
                .AddAllViewModels()
                .BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var productsDashboardWindow = new ProductsDashboardWindow();
            productsDashboardWindow.Show();
        }
    }
}