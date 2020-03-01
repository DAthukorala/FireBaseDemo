using Google.Cloud.Firestore;

namespace Firebaser.DAL.Models
{
    /// <summary>
    /// the backup data model
    /// Id-> practiceid_ezformid
    /// FormData -> all the data in the form as a stringified json object
    /// CreatedAt -> time the document is created in firebase
    /// </summary>
    [FirestoreData]
    public class AutoSaveInfo
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string FormData { get; set; }

        [FirestoreProperty]
        public Timestamp CreatedAt { get; set; }
    }
}
