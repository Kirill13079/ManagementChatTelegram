using System.Collections;
using System.Collections.Generic;
using LiteDB;

namespace ManagementChatTelegram.Services
{
    public class RepositoryService
    {
        private readonly LiteDatabase _db;

        public RepositoryService(LiteDatabase db)
        {
            _db = db;
        }

        public IEnumerable<T> FindAll<T>() => GetCollection<T>().FindAll();

        public void Save<T>(T item) => GetCollection<T>().Upsert(item);

        public ILiteCollection<T> GetCollection<T>() => _db.GetCollection<T>();
    }
}
