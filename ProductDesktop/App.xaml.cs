using ProductDesktop.Database;
using ProductDesktop.Pages;

namespace ProductDesktop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var dbcontext = new DatabaseContext();
            return new Window(new NavigationPage(new LoginPage(dbcontext)));
        }
    }
}