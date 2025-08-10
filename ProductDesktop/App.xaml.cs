using ProductDesktop.Database;
using ProductDesktop.Pages;

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
            var loginPage = Services.GetRequiredService<LoginPage>();

            return new Window(new NavigationPage(loginPage));
            //return new Window(new AppShell());
        }
    }
}