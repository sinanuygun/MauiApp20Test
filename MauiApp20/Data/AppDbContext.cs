using MauiApp20.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MauiApp20.Data
{
    public class AppDbContext
    {
        private SQLiteAsyncConnection _database;
        public AppDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }
        // TestEntity tablosu
        public AsyncTableQuery<TestEntity> TestEntities => _database.Table<TestEntity>();
        public async Task InitializeAsync()
        {
            await _database.CreateTableAsync<TestEntity>();
        }
        public SQLiteAsyncConnection GetConnection() => _database;
    }
}
