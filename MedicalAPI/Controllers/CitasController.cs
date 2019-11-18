
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using MedicalRepos;
using MedicalRepos.Contracts;
using DataAccess.Models;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : Controller
    {
        private readonly UnitOfWork _UOW;

        public CitasController(IUnitOfWork uOW)
        {
            _UOW = uOW as UnitOfWork;
        }




        [HttpGet]
        public ActionResult Get()
        {
            dynamic model = new ExpandoObject();
            model.Citas = this._UOW.CitasRepository.GetAll().Where(x => x.Estado).ToList();

          /* model.Citas = from c in Data
                          where c.Estado  
                          select c;*/

            return Ok(model.Citas);



        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Citas citas)
        {
            dynamic model = new ExpandoObject();
            // model.Citas = this._UOW.CitasRepository.GetAll();
            var dato = this._UOW.CitasRepository.GetAll().Where(x => x.Estado && x.Fecha.Equals(citas.Fecha) && x.IdPaciente.Equals(citas.IdPaciente)).ToList();
          //  where c.Estado.Equals(true) && c.
            //           select c;


            if (dato != null)
            {
                if (dato.Any())
                {
                    return BadRequest($"No se puede crear otra cita para el mismo paciente en el mismo día");
                }
            }

            this._UOW.CitasRepository.Add(citas);
            await _UOW.Commit();
            return Ok();

            //   this._UOW.CitasRepository.Add(paciente);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> CancelAsync([FromBody] Citas citas)
        {
            dynamic model = new ExpandoObject();
            // model.Citas = this._UOW.CitasRepository.GetAll();
            var dato = this._UOW.CitasRepository.GetAll().Where(x => x.Estado && x.IdPaciente.Equals(citas.IdPaciente)).ToList();
                    //   where c.Estado.Equals(true) && c.IdPaciente.Equals(citas.IdPaciente)
                      // select c;


            if (dato != null)
            {
                if (dato.Any())
                {
                    if (dato.FirstOrDefault().Fecha < citas.Fecha.AddHours(24))
                    {
                        return BadRequest($"Las citas se deben cancelar con mínimo 24 horas de antelación");
                    }


                    this._UOW.CitasRepository.Update(citas);
                    await _UOW.Commit();
                    return Ok("Cita cancelada exitosamente!");
                }
                else
                {
                    return BadRequest($"Sin citas a cancelar");
                }


            }
            return BadRequest($"Sin citas a cancelar");



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
