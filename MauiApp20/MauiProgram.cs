using MauiApp20.Data;
using MauiApp20.Models;
using MauiApp20.Services;
using Microsoft.Extensions.Logging;
namespace MauiApp20
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
                });
            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            // SQLite Database Path
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
            // Services
            builder.Services.AddSingleton(new AppDbContext(dbPath));
            builder.Services.AddSingleton<IConnectivityService, ConnectivityService>();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<JsInteropService>();
            // Generic DataService (Entity belirleyince buraya eklenecek)
            // Örnek: builder.Services.AddSingleton<IDataService<Product>>(sp => 
            //     new DataService<Product>(
            //         sp.GetRequiredService<AppDbContext>(),
            //         sp.GetRequiredService<IConnectivityService>(),
            //         sp.GetRequiredService<HttpClient>(),
            //         "https://api.example.com/products"
            //     ));
            builder.Services.AddSingleton<IDataService<TestEntity>>(sp =>
                                                                        new DataService<TestEntity>(
                                                                            sp.GetRequiredService<AppDbContext>(),
                                                                            sp.GetRequiredService<IConnectivityService>(),
                                                                            sp.GetRequiredService<HttpClient>(),
                                                                            "https://jsonplaceholder.typicode.com/users" // Test API
                                                                        ));
            return builder.Build();
        }
    }
}
