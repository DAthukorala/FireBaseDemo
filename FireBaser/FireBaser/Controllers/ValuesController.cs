using Firebaser.DAL.Contracts;
using Firebaser.DAL.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace FireBaser.Controllers
{
    public class ValuesController : ApiController
    {
        private IAutoSaveRepository _repository;
        public ValuesController(IAutoSaveRepository repository)
        {
            _repository = repository;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public async Task<bool> PostAsync([FromBody]AutoSaveInfo data)
        {
            var status = await _repository.Create(data);
            return status;
        }
    }
}
