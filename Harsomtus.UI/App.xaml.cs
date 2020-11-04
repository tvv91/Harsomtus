using Harsomtus.Implementation;
using Harsomtus.Models;
using Harsomtus.Services;
using Harsomtus.UI.ViewModels;
using Harsomtus.UI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using UIC = Harsomtus.Constants.UI;

namespace Harsomtus.UI
{
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); }).Build();
            ServiceProvider = host.Services;
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton(typeof(INavigationService<Album>), typeof(NavigationService));
            services.AddTransient<MainWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Width = UIC.WINDOW_WIDTH;
            window.Height = UIC.WINDOW_HEIGHT;
            window.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
