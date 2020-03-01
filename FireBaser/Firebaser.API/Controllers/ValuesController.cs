﻿using Firebaser.DAL.Contracts;
using Firebaser.DAL.Implementations;
using Firebaser.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Firebaser.API.Controllers
{
    //dont use origins * here. add the correct client url
    //you wont have a CORS problem since both the client and api are in the same origin
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private readonly IAutoSaveRepository _repository;
        public ValuesController()
        {
            //use dependency injection here
            _repository = new AutoSaveRepository();
        }

        public async Task<List<AutoSaveInfo>> Get(string id)
        {
            var data = await _repository.Read(id);
            return data;
        }

        public async Task<bool> PostAsync([FromBody]AutoSaveInfo data)
        {
            var status = await _repository.Create(data);
            return status;
        }
    }
}
