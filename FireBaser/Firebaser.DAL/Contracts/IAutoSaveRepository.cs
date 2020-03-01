using Firebaser.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firebaser.DAL.Contracts
{
    public interface IAutoSaveRepository
    {
        Task<bool> Create(AutoSaveInfo data);
        Task<List<AutoSaveInfo>> Read(string id);
    }
}
