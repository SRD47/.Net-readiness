using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProductDesktop.Database;
using ProductDesktop.Pages;
using ProductDesktop.Repository;
using ProductDesktop.ViewModel;
namespace ProductDesktop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<ProductRepository>();

            builder.Services.AddSingleton<StaffViewModel>();
            builder.Services.AddSingleton<ProductViewModel>();
            

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignupPage>();
            builder.Services.AddTransient<AdminDashboard>();
            builder.Services.AddTransient<CustomerDashboard>();
            builder.Services.AddTransient<ChangeRoles>();

#endif

            return builder.Build();
        }
    }
}
