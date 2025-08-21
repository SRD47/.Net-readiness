using ProductDesktop.Pages;
using ProductDesktop.Service;

namespace ProductDesktop
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public App(IServiceProvider services)
        {
            InitializeComponent();
            

            Services = services;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var loginPage = App.Services.GetRequiredService<LoginPage>();
            return new Window(new NavigationPage(loginPage));
        }
    }
}