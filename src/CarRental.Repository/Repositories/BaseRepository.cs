using CarRental.Domain.Interfaces;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;
using CarRental.Repository.Interfaces;
using CarRental.Repository.Context;

namespace CarRental.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly IMongoContext _context;
        protected IMongoCollection<T> DbSet;

        protected BaseRepository(IMongoContext context)
        {
            _context = context;
        }
        private void ConfigDbSet()
        {
            DbSet = _context.GetCollection<T>(typeof(T).Name);
        }
        public Task DeleteAsync(Guid id) => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));

        public async Task<T> InsertAsync(T item)
        {
            _context.AddCommand(async () => await DbSet.InsertOneAsync(item));
            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }
        public async Task Update(T item)
        {
             _context.AddCommand(async () =>
            {
                await DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", item.GetType()), item);
            });
        }
    }
}
