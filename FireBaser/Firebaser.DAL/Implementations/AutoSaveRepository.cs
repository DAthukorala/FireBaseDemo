using Firebaser.DAL.Contracts;
using Firebaser.DAL.Models;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firebaser.DAL.Implementations
{
    public class AutoSaveRepository : IAutoSaveRepository
    {
        private readonly CollectionReference _collection;
        public AutoSaveRepository()
        {
            var _database = FirestoreDb.Create("ehrautosave");
            _collection = _database.Collection("AutoSaveRepo");
        }

        public async Task<bool> Create(AutoSaveInfo data)
        {
            //add create time
            data.CreatedAt = Timestamp.GetCurrentTimestamp();
            var result = await _collection.AddAsync(data);
            var status = !string.IsNullOrEmpty(result.Id);
            return status;
        }

        public async Task<List<AutoSaveInfo>> Read(string id)
        {
            var query = _collection.WhereEqualTo("Id", id).OrderByDescending("CreatedAt");
            var data = await query.GetSnapshotAsync();
            var converted = data.Documents.Select(x => x.ConvertTo<AutoSaveInfo>()).ToList();
            return converted;
        }
    }
}
