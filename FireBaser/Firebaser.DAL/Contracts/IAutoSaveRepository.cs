using Firebaser.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firebaser.DAL.Contracts
{
    /// <summary>
    /// Provide functionality to interact with firebase to read and write data
    /// </summary>
    public interface IAutoSaveRepository
    {
        /// <summary>
        /// Create a new document in firebase with the provided id
        /// </summary>
        /// <param name="data">document to save</param>
        /// <returns>save status</returns>
        Task<bool> Create(AutoSaveInfo data);

        /// <summary>
        /// Read a document fro firebase using the id field of the document
        /// </summary>
        /// <param name="id">id field value of the document</param>
        /// <returns>all the documents that have the given id</returns>
        Task<List<AutoSaveInfo>> Read(string id);
    }
}
