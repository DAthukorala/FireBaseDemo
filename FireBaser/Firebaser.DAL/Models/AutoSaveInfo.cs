using Google.Cloud.Firestore;

namespace Firebaser.DAL.Models
{
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
