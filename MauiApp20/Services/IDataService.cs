using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MauiApp20.Services
{
    public interface IDataService<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> SaveAsync(T item);
        Task<int> DeleteAsync(T item);
        Task SyncFromApiAsync(); // API'den veri çekip SQLite'a kaydeder
    }
}
