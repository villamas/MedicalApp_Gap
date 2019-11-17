using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using MedicalRepos;
using MedicalRepos.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAPI.Controllers
{
    [Route("api/[controller]")]
    public class TipoCitasController : Controller
    {

        private readonly UnitOfWork _UOW;

        public TipoCitasController(IUnitOfWork uOW)
        {
            _UOW = uOW as UnitOfWork;
        }


        // GET: api/values
      /*  [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public ActionResult Get()
        {
            dynamic model = new ExpandoObject();
            model.TipoCitas = this._UOW.TiposCitaRepository.GetAll();
            return Ok(model.TipoCitas);


        }

      /*  // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        */

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]TipoCitas tipoCitas)
        {
            this._UOW.TiposCitaRepository.Add(tipoCitas);
          await  _UOW.Commit();
            return Ok("Inserción Exitosa");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
