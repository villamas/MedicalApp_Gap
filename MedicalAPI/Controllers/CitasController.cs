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
    public class CitasController : Controller
    {
        private readonly UnitOfWork _UOW;

        public CitasController(IUnitOfWork uOW)
        {
            _UOW = uOW as UnitOfWork;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Citas citas)
        {
            dynamic model = new ExpandoObject();
            // model.Citas = this._UOW.CitasRepository.GetAll();
            var dato = from c in this._UOW.CitasRepository.GetAll()
                       where c.Estado.Equals(true) && c.Fecha.Equals(citas.Fecha) && c.IdPaciente.Equals(citas.IdPaciente)
                       select c;


            if (dato != null)
            {
                if (dato.Any())
                {
                    return BadRequest($"No se puede crear otra cita para el mismo paciente en el mismo día");
                }
            }

            this._UOW.CitasRepository.Add(citas);
            return Ok();

         //   this._UOW.CitasRepository.Add(paciente);
        }


        [HttpPost]
        public ActionResult Cancel([FromBody] Citas citas)
        {
            dynamic model = new ExpandoObject();
            // model.Citas = this._UOW.CitasRepository.GetAll();
            var dato = from c in this._UOW.CitasRepository.GetAll()
                       where c.Estado.Equals(true) && c.IdPaciente.Equals(citas.IdPaciente)
                       select c;


            if (dato != null)
            {
                if (dato.FirstOrDefault().Fecha < citas.Fecha.AddHours(24))
                {
                    return BadRequest($"Las citas se deben cancelar con mínimo 24 horas de antelación");
                }
            }

            this._UOW.CitasRepository.Update(citas);
            return Ok();

        
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
