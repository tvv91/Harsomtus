using Harsomtus.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Harsomtus.UI.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
    }
}
