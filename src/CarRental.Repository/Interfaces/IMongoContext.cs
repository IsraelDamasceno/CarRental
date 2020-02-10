using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CarRental.Repository.Interfaces
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
