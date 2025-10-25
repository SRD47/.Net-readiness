using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProductDesktop.Database;
using ProductDesktop.Pages;
using ProductDesktop.Repository;
using ProductDesktop.Validation;
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
