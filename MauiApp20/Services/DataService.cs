using MauiApp20.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
namespace MauiApp20.Services
{
    public class DataService<T> : IDataService<T> where T : class, new()
    {
        private readonly AppDbContext _dbContext;
        private readonly IConnectivityService _connectivityService;
        private readonly HttpClient _httpClient;
        private readonly string _apiEndpoint;
        public DataService(
            AppDbContext dbContext,
            IConnectivityService connectivityService,
            HttpClient httpClient,
            string apiEndpoint)
        {
            _dbContext = dbContext;
            _connectivityService = connectivityService;
            _httpClient = httpClient;
            _apiEndpoint = apiEndpoint;
        }
        public async Task<List<T>> GetAllAsync()
        {
            var connection = _dbContext.GetConnection();
            return await connection.Table<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var connection = _dbContext.GetConnection();
            return await connection.FindAsync<T>(id);
        }
        public async Task<int> SaveAsync(T item)
        {
            var connection = _dbContext.GetConnection();
            // PrimaryKey kontrolü yapılabilir, şimdilik basit insert/update
            return await connection.InsertOrReplaceAsync(item);
        }
        public async Task<int> DeleteAsync(T item)
        {
            var connection = _dbContext.GetConnection();
            return await connection.DeleteAsync(item);
        }
        public async Task SyncFromApiAsync()
        {
            if (!_connectivityService.IsConnected)
                return;
            try
            {
                var response = await _httpClient.GetAsync(_apiEndpoint);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<List<T>>();
                if (data != null && data.Any())
                {
                    var connection = _dbContext.GetConnection();
                    // Düzeltme: Tek tek insert/replace yap
                    foreach (var item in data)
                    {
                        await connection.InsertOrReplaceAsync(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sync error: {ex.Message}");
            }
        }
    }
}
