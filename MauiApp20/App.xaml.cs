using MauiApp20.Data;
namespace MauiApp20
{
    public partial class App : Application
    {
        public App(AppDbContext dbContext)
        {
            InitializeComponent();
            // SQLite veritabanını başlat
            InitializeDatabaseAsync(dbContext);
        }
        private async void InitializeDatabaseAsync(AppDbContext dbContext)
        {
            try
            {
                await dbContext.InitializeAsync();
                Console.WriteLine("Database initialized successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization error: {ex.Message}");
            }
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "MauiApp20" };
        }
    }
}