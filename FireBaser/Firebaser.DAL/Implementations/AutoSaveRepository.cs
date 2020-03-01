using Firebaser.DAL.Contracts;
using Firebaser.DAL.Models;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firebaser.DAL.Implementations
{
    /// <summary>
    /// Implement functionality for interacting with fire base
    /// </summary>
    public class AutoSaveRepository : IAutoSaveRepository
    {
        private readonly CollectionReference _collection;
        public AutoSaveRepository()
        {
            var _database = FirestoreDb.Create("ehrautosave"); //get a reference to the data base
            _collection = _database.Collection("AutoSaveRepo"); //get a reference to the auto save collection (table)
        }

        public async Task<bool> Create(AutoSaveInfo data)
        {
            //add created time
            data.CreatedAt = Timestamp.GetCurrentTimestamp();
            //create a new document with backup data
            var result = await _collection.AddAsync(data);
            //the result will have the newly created document's id if the save is successful. we can derive the save status based on that
            var status = !string.IsNullOrEmpty(result.Id);
            return status;
        }

        public async Task<List<AutoSaveInfo>> Read(string id)
        {
            //create a query to extract all the records that have the provided id, sorted in descending order by created time
            var query = _collection.WhereEqualTo("Id", id).OrderByDescending("CreatedAt");
            //extract data
            var data = await query.GetSnapshotAsync();
            //convert the firebase document to AutoSaveInfo model
            var converted = data.Documents.Select(x => x.ConvertTo<AutoSaveInfo>()).ToList();
            //return data as a lit of AutoSaveInfo
            return converted;
        }
    }
}
