using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProductDesktop.Database;
using ProductDesktop.Pages;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
using ProductDesktop.ViewModel;
using Microsoft.Maui.Hosting;
using Serilog;
using Serilog.Events;


namespace ProductDesktop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\.."));
            var logPath = Path.Combine(projectDir, "Logging", "Logs.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Filter.ByExcluding(logEvent => logEvent.Level == LogEventLevel.Warning)
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
                .WriteTo.Debug()
                .CreateLogger();

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

            builder.Logging.ClearProviders();

            builder.Logging.AddSerilog();

            //For Repo, services...
            builder.Services.AddScoped<DatabaseContext>();
            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<ProductRepository>();
            builder.Services.AddSingleton<SupplierRepo>();
            builder.Services.AddSingleton<OrderRepo>();
            builder.Services.AddSingleton<DuplicateValidation>();

            //For ViewModels
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddScoped<StaffViewModel>();
            builder.Services.AddTransient<EnumViewModel>();


            //For Pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignupPage>();
            builder.Services.AddTransient<ForgetPasswordPage>();
            builder.Services.AddTransient<AdminDashboard>();
            builder.Services.AddTransient<CustomerDashboard>();
            builder.Services.AddTransient<OrderProcessor>();
            builder.Services.AddTransient<InventoryManager>();
            builder.Services.AddTransient<ChangeRolesPopup>();
            builder.Services.AddTransient<AddProductPopup>();
            builder.Services.AddTransient<ProductPage>();
            builder.Services.AddTransient<SupplierPage>();
            builder.Services.AddTransient<AddSupplierPopup>();
            builder.Services.AddTransient<OrderPagePopup>();
            builder.Services.AddTransient<EditSupplierPopup>();
            builder.Services.AddTransient<EditProductPopup>();

#endif

            return builder.Build();
        }
    }
}
